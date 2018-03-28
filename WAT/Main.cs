using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZedGraph;
using System.Diagnostics;

namespace WAT
{
    public partial class Main : Form
    {
        ///<summary>
        ///declare variables
        ///</summary>
        string TEXT = "";//Name file
        string[] A;//test input
        double[] B;//test convert
        double min, max;
        int LengTimeSeries = 0;
        string FileName;

        public Main()
        {
            InitializeComponent();
        }
        ///<summary>
        ///Button for openning file
        ///</summary>
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            btn_Browse.BackColor = Color.Olive;
            string s = "";
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                txt_Browse.Text = open.FileName;
                s = open.SafeFileName.Substring(open.SafeFileName.LastIndexOf("."));
                FileName = open.SafeFileName.Substring(0, open.SafeFileName.LastIndexOf("."));
                s = s.ToLower();
                if (s != ".txt")
                {
                    MessageBox.Show("Support only .txt file!");
                    txt_Browse.ResetText();
                    txt_Browse.Text = "Choose .txt file here";
                    s = "";
                }
                else
                {
                    zedGraphControlMain.GraphPane.CurveList.Clear();
                    TEXT = txt_Browse.Text;
                    ReadFile();
                    LengTimeSeries = B.Length;
                }
            }
            label4.Text = "All: " + LengTimeSeries.ToString();
        }
        ///<summary>
        ///Click đúp vào đường dẫn sẽ mở cửa sổ mới cho chọn tập dữ liệu
        ///</summary>
        private void txt_Browse_DoubleClick(object sender, EventArgs e)
        {
            string s = "";
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                txt_Browse.Text = open.FileName;
                s = open.SafeFileName.Substring(open.SafeFileName.LastIndexOf("."));
                FileName = open.SafeFileName.Substring(0, open.SafeFileName.LastIndexOf("."));
                s = s.ToLower();
                if (s != ".txt")
                {
                    MessageBox.Show("Support only .txt file!");
                    txt_Browse.ResetText();
                    txt_Browse.Text = "Choose .txt file here";
                    s = "";
                }
                else
                {
                    //
                    zedGraphControlMain.GraphPane.CurveList.Clear();
                    TEXT = txt_Browse.Text;
                    ReadFile();
                    LengTimeSeries = B.Length;
                }
            }
        }
        ///<summary>
        ///Funtion readfile
        ///</summary>
        private void ReadFile()
        {
            try
            {
                bool space = false;
                int VT = 0;
                A = File.ReadAllLines(@TEXT);
                B = new double[A.Length];
                double[] M = new double[A.Length];
                for (int i = 0; i < A.Length; i++)
                {
                    A[i] = A[i].Trim();
                    if (A[i] == "")
                    {
                        VT = i;
                        space = true;
                        break;
                    }
                    else
                    {
                        M[i] = double.Parse(A[i]);
                        B[i] = double.Parse(A[i]);
                    }
                }
                if (space == true)
                {
                    B = new double[A.Length - (A.Length - VT)];
                    for (int i = 0; i < B.Length; i++)
                    {
                        B[i] = M[i];
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cann't convert to numbers format!\n Format support: Xe+X");
                txt_Browse.ResetText();
            }
        }
        ///<summary>
        ///xóa dữ liệu khi click vào các ô textBox nhập Min-Max
        ///</summary>
        private void txt_Min_Click(object sender, EventArgs e)
        {
            txt_Min.ResetText();
        }

        private void txt_Max_Click(object sender, EventArgs e)
        {
            txt_Max.ResetText();
        }


        //Hàm main được load khi chạy ứng dụng
        private void Main_Load(object sender, EventArgs e)
        {
            cbPoint.SelectedIndex = 0;     //Set giá trị mặc định cho cutpoint
            cb_length.SelectedIndex = 0;   //Set giá trị mặc định cho đọ dài chuỗi con
            //Add thêm 2 hàng vào dataGridview
            DataGridViewRow g = new DataGridViewRow();
            DataGridViewRow t = new DataGridViewRow();
            dataGridView1.Rows.Add(g);
            dataGridView1.Rows.Add(t);
            dataGridView1.Rows[0].Cells[0].Value = "Vị trí bất thường";
            dataGridView1.Rows[2].Cells[0].Value = "Thời gian chạy";
            dataGridView1.Rows[1].Cells[0].Value = "Số lần gọi hàm tính khoảng cách";
            label4.Text = LengTimeSeries.ToString();
        }
        
        ///<summary>
        ///Sự kiện click bruteforce
        ///</summary>
        private void btn_BruteForce_Click(object sender, EventArgs e)
        {
            zedGraphControlBruteForce.GraphPane.CurveList.Clear();
            int lengthTime = B.Length;
            int nortype = 0;//Z-cord
            if (rdb_MinMax.Checked)
            {
                nortype = 1; //Min-Max normalize
                min = Int32.Parse(txt_Min.Text);  //Lấy giá trị min từ textbox
                max = Int32.Parse(txt_Max.Text);  //Lấy giá trị mã từ textbox
            }
            if (cbb_LengthTime.SelectedItem.ToString() == "All")//Get total length time series
                lengthTime = LengTimeSeries;
            else
                lengthTime = int.Parse(cbb_LengthTime.SelectedItem.ToString());//Extract length of time series
            Stopwatch stNor = new Stopwatch(); //Khởi tạo hàm tính thời gian
            stNor.Start();                     //Bắt đầu tính giờ
            BruteForce b = new BruteForce();   //Khởi tạo class BruteForce
            int locat = b.Brute(B.Take(lengthTime).ToArray(), Int32.Parse(cb_length.Text), nortype, min, max); //Thực thi hàm tính BruteForce kết quả trả về vị trí bất thường
            int countb = b.countB; //Số lần tinh khoảng cách
            stNor.Stop();          //Dừng hàm tính thời gian
            MessageBox.Show("Done"); //Done
            string timeNor = stNor.Elapsed.ToString();  //Lấy thời gian trả về dưới dạng chuỗi
            timeNor = timeNor.Substring(0, 12);      
            DrawingBruteForce(locat);  //Vẽ chuỗi con bất thường cho đò thị nhỏ.
            // Đổ dữ liệu đã tính lên dataGridView
            dataGridView1.Rows[0].Cells[1].Value = locat;    
            dataGridView1.Rows[2].Cells[1].Value = timeNor;
            dataGridView1.Rows[1].Cells[1].Value = countb;
            //
            DrawDiscord(locat); //Vẽ chuỗi con bất thường hiển thị lên toàn chuỗi 
        }

        /// <summary>
        /// Wat_hash Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_watHash_Click(object sender, EventArgs e)
        {
            int lengthTime = B.Length;
            if (cbb_LengthTime.SelectedItem.ToString() == "All")
                lengthTime = LengTimeSeries;
            else
                lengthTime = int.Parse(cbb_LengthTime.SelectedItem.ToString());//Extract length of time series
            int nortype = 0;//Z-cord
            if (rdb_MinMax.Checked)
            {
                nortype = 1;                    //Min-Max normalize
                min = Int32.Parse(txt_Min.Text);//Lấy giá trị min từ textbox
                max = Int32.Parse(txt_Max.Text);//Lấy giá trị max từ textbox
            }
            int decrease = Int32.Parse(cb_des.Text); //Lấy tỉ lệ thu giảm từ combobox
            Stopwatch stNor = new Stopwatch();//Khởi tạo hàm tính thời gian
            stNor.Start();                    ////Bắt đầu tính giờ
            WAT_HASH w = new WAT_HASH();       //Khởi tạo class Wat_hash
            int index = w.iWAT(B.Take(lengthTime).ToArray(), Int32.Parse(cb_length.Text), Int32.Parse(cbPoint.Text), nortype, min, max, decrease, 0);  //Thực thi hàm tính wash-hash kết quả trả về vị trí bất thường
            double count = w.countE;      //Số lần tính khoảng cách
            stNor.Stop();                 //Dừng tính giờ
            MessageBox.Show("Done");
            string timeNor = stNor.Elapsed.ToString();
            timeNor = timeNor.Substring(0, 12);
            //Show thông tin lên dataGridView
            dataGridView1.Rows[0].Cells[3].Value = index;
            dataGridView1.Rows[2].Cells[3].Value = timeNor;
            dataGridView1.Rows[1].Cells[3].Value = count;
            //Vẽ chuỗi con bất thường cho đò thị nhỏ.
            DrawWAT_HASH(index);
            //Vẽ chuỗi con bất thường hiển thị lên toàn chuỗi 
            DrawDiscord(index);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btn_Wattree_Click(object sender, EventArgs e)
        {
            int lengthTime = B.Length;
            if (cbb_LengthTime.SelectedItem.ToString() == "All")
                lengthTime = LengTimeSeries;
            else
                lengthTime = int.Parse(cbb_LengthTime.SelectedItem.ToString());
            int nortype = 0;//Z-cord
            if (rdb_MinMax.Checked)
            {
                nortype = 1;
                min = Int32.Parse(txt_Min.Text);
                max = Int32.Parse(txt_Max.Text);
            }
            int decrease = Int32.Parse(cb_des.Text);
            Stopwatch stNor = new Stopwatch();//Khởi tạo hàm tính thời gian
            stNor.Start();             //Bắt đầu tính giờ
            WAT_TREE w = new WAT_TREE();   //Khởi tạo class Wat_tree
            int index = w.iWAT(B.Take(lengthTime).ToArray(), Int32.Parse(cb_length.Text), Int32.Parse(cbPoint.Text), nortype, min, max, decrease, 0);//Thực thi hàm tính wash-hash kết quả trả về vị trí bất thường
            double count = w.countE; //Số lần tính khoảng cách
            stNor.Stop();
            MessageBox.Show("Done");
            string timeNor = stNor.Elapsed.ToString();
            timeNor = timeNor.Substring(0, 12);
            //Show thông tin lên dataGridView
            dataGridView1.Rows[0].Cells[2].Value = index;
            dataGridView1.Rows[2].Cells[2].Value = timeNor;
            dataGridView1.Rows[1].Cells[2].Value = count;
            //Vẽ bất thường cho khung đò thị nhỏ
            DrawWAT_TREE(index);
            //Vẽ chuỗi con bất thường hiển thị lên toàn chuỗi 
            DrawDiscord(index);
        }

        private void btn_Draw_Click(object sender, EventArgs e)
        {
            if (cbb_LengthTime.Text == "")
            {
                MessageBox.Show("Vui lòng chọn độ dài chuỗi thời gian");
            }
            else
            {
                Drawing();
            }
        }

        ///<summary>
        ///Drawing pot for dataset is inputted with length of time series
        ///</summary>
        private void Drawing()
        {
            zedGraphControlMain.GraphPane.CurveList.Clear();
            GraphPane myPane = zedGraphControlMain.GraphPane;
            myPane.Title.Text = "Time Series " + FileName + " " + LengTimeSeries;
            myPane.XAxis.Title.Text = "Index";// "Thời gian cột X";
            myPane.YAxis.Title.Text = "Value";// "Tiêu đề cột Y";
            myPane.XAxis.Scale.Min = 0;          
            //Vị trí bắt đầu chuỗi thời gian (cho đò thị scale)
            int sopt = 0;
            if (cbb_LengthTime.Text == "All")
            {
                myPane.XAxis.Scale.Max = B.Length;
                sopt = B.Length;
            }
            else if (Int32.Parse(cbb_LengthTime.Text) > LengTimeSeries)
            {
                myPane.XAxis.Scale.Max = LengTimeSeries;  //Vị trí kết thúc chuỗi thời gian (cho đò thị scale)
                sopt = LengTimeSeries;  //Vị trí kết thúc chuỗi thời gian 
            }
            else
            {
                myPane.XAxis.Scale.Max = Int32.Parse(cbb_LengthTime.Text);  //Vị trí kết thúc chuỗi thời gian (cho đò thị scale)
                sopt = Int32.Parse(cbb_LengthTime.Text);  //Vị trí kết thúc chuỗi thời gian 
            }
            zedGraphControlMain.AxisChange();

            PointPairList list = new PointPairList();  //List([x],[y])

            List<double> column1 = new List<double>(); //x
            List<double> column2 = new List<double>(); //y
            for (int i = 0; i < sopt; i++)
            {
                column1.Add(i);        //Cột thời gian x
                column2.Add(B[i]);     //Cột số liệu y
            }
            list.Add(column1.ToArray(), column2.ToArray());
            LineItem myCurve = myPane.AddCurve(FileName, list, Color.Teal, SymbolType.None); //Chú thích cho đường dữ liệu và vẽ đò thị

            zedGraphControlMain.AxisChange(); //Áp dụng thay đổi
            zedGraphControlMain.Invalidate();
           
            zedGraphControlMain.Show();
        }
        ///<summary>
        ///Drawing pot for BruteForce method
        ///</summary>
        private void DrawingBruteForce(int locat)
        {
            int n = int.Parse(cb_length.Text);
            //
            GraphPane myPane = zedGraphControlBruteForce.GraphPane;
            myPane.Title.Text = " Brute Force !!!";
            myPane.XAxis.Title.Text = "Index";// "Thời gian cột X";
            myPane.YAxis.Title.Text = "Value";// "Tiêu đề cột Y";
            myPane.XAxis.Scale.Min = locat;
            myPane.XAxis.Scale.Max = locat + n - 1;

            zedGraphControlBruteForce.AxisChange();

            PointPairList list = new PointPairList(); //list([x],[y])

            List<double> column1 = new List<double>(); //Cột thời gian x
            List<double> column2 = new List<double>(); //Số liệu côt y
            //Add dữ liệu từ timeseris vào các cột tương ứng trên Graph
            for (int i = locat; i < locat + n; i++)
            {
                column1.Add(i);     //Cột thời gian xs
                column2.Add(B[i]);  //Số liệu côt y
            }
            list.Add(column1.ToArray(), column2.ToArray());
            LineItem myCurve = myPane.AddCurve(FileName, list, Color.Red, SymbolType.VDash); //Chú thích cho đường dữ liệu và vẽ đò thị

            zedGraphControlBruteForce.AxisChange(); //Áp dụng thay đổi
            zedGraphControlBruteForce.Invalidate();
        }

        void DrawWAT_HASH(int index)
        {
            zedWat_HASH.GraphPane.CurveList.Clear();
            int n = int.Parse(cb_length.Text);
            min = B.Skip(index).Take(n).Min();
            max = B.Skip(index).Take(n).Max();
            //
            GraphPane myPane = zedWat_HASH.GraphPane;
            myPane.Title.Text = " WAT_IMPROVED ";
            myPane.XAxis.Title.Text = "Index";// "Thời gian cột X";
            myPane.YAxis.Title.Text = "Value";// "Tiêu đề cột Y";
            myPane.XAxis.Scale.Min = index;
            myPane.XAxis.Scale.Max = index + n - 1;

            zedWat_HASH.AxisChange();

            PointPairList list = new PointPairList();

            List<double> column1 = new List<double>(); //Cột thời gian x
            List<double> column2 = new List<double>(); //Số liệu cột y
            for (int i = index; i < index + n; i++)
            {
                column1.Add(i);//Cột thời gian x
                column2.Add(B[i]);//Số liệu cột y
            }
            list.Add(column1.ToArray(), column2.ToArray());
            LineItem myCurve = myPane.AddCurve(FileName, list, Color.Red, SymbolType.VDash); //Chú thích cho đường dữ liệu và vẽ đò thị

            zedWat_HASH.AxisChange(); //Áp dụng thay đổi
            zedWat_HASH.Invalidate();
        }
        void DrawWAT_TREE(int index)
        {
            zedWat_TREE.GraphPane.CurveList.Clear();
            int n = int.Parse(cb_length.Text);
            min = B.Skip(index).Take(n).Min();
            max = B.Skip(index).Take(n).Max();
            //
            GraphPane myPane = zedWat_TREE.GraphPane;
            myPane.Title.Text = " WAT_TRIE ";
            myPane.XAxis.Title.Text = "Index";// "Thời gian cột X";
            myPane.YAxis.Title.Text = "Value";// "Tiêu đề cột Y";
            myPane.XAxis.Scale.Min = index;
            myPane.XAxis.Scale.Max = index + n - 1;

            zedWat_TREE.AxisChange();

            PointPairList list = new PointPairList();

            List<double> column1 = new List<double>();
            List<double> column2 = new List<double>();
            for (int i = index; i < index + n; i++)
            {
                Console.Write(B[i] + " ");
                column1.Add(i);
                column2.Add(B[i]);
            }
            list.Add(column1.ToArray(), column2.ToArray());
            LineItem myCurve = myPane.AddCurve(FileName, list, Color.Red, SymbolType.VDash);

            zedWat_TREE.AxisChange();
            zedWat_TREE.Invalidate();
        }
        private void DrawDiscord(int index)
        {
            zedGraphControlMain.Hide();
            zedGraphControl1.GraphPane.CurveList.Clear();
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Experimental result of WAT on " + FileName + " time series";
            myPane.XAxis.Title.Text = "Index";// "Thời gian cột X";
            myPane.YAxis.Title.Text = "Value";// "Tiêu đề cột Y";           
            myPane.XAxis.Scale.Min = 0;
            if (cbb_LengthTime.Text == "All")
            {
                myPane.XAxis.Scale.Max = B.Length;
            }
            else if (Int32.Parse(cbb_LengthTime.Text) > LengTimeSeries)
            {
                myPane.XAxis.Scale.Max = LengTimeSeries;
            }
            else
            {
                myPane.XAxis.Scale.Max = Int32.Parse(cbb_LengthTime.Text); //Vị trí kết thúc chuỗi thời gian (cho đò thị scale)
            }
            
            int ZedminX = 0, ZedmaxX = index;
            zedGraphControl1.AxisChange();

            PointPairList list1 = new PointPairList();          //Dữ liệu cho đường 1
            PointPairList listabnormal = new PointPairList();   //Dữ liệu cho đường 2 (đường biểu diễn bất thường)
            PointPairList list2 = new PointPairList();          //Dữ liệu cho đường 3

            List<double> column1 = new List<double>();//x - đường 1
            List<double> column2 = new List<double>();//y - đường 1
            List<double> column3 = new List<double>();//x - đường 2
            List<double> column4 = new List<double>();//y - đường 2
            List<double> column5 = new List<double>();//x - đường 3
            List<double> column6 = new List<double>();//y - đường 3
            int Leng = Int32.Parse(cb_length.Text);//độ dài chuỗi con

            for (int i = ZedminX; i < ZedmaxX; i++)
            {
                column1.Add(i);     //x1
                column2.Add(B[i]);  //y1
            }

            for (int i = ZedmaxX; i < ZedmaxX + Leng; i++)
            {
                column3.Add(i);    //x2
                column4.Add(B[i]); //y2
            }
            if (cbb_LengthTime.Text == "All")
            {
                for (int i = Leng; i < LengTimeSeries; i++)
                {
                    column5.Add(i);   //x3
                    column6.Add(B[i]); //y3
                }
            }
            else if (Int32.Parse(cbb_LengthTime.Text) > LengTimeSeries)
            {
                for (int i = Leng; i < LengTimeSeries; i++)
                {
                    column5.Add(i);   //x3
                    column6.Add(B[i]); //y3
                }
            }
            else
            {
                for (int i = Leng; i < Int32.Parse(cbb_LengthTime.Text); i++)
                {
                    column5.Add(i);   //x3
                    column6.Add(B[i]); //y3
                }
            }
            list1.Add(column1.ToArray(), column2.ToArray());      
            listabnormal.Add(column3.ToArray(), column4.ToArray());
            list2.Add(column5.ToArray(), column6.ToArray());
            LineItem myCurve1 = myPane.AddCurve(FileName, list1, Color.Blue, SymbolType.None);  //vẽ đường 1
            LineItem myAbnormal = myPane.AddCurve("Unusual sequence", listabnormal, Color.Red, SymbolType.None);//vẽ đường 2
            LineItem myCurve2 = myPane.AddCurve("", list2, Color.Blue, SymbolType.None);//vẽ đường 3

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }

}





//private void DrawDiscord(int index)
//        {
//            zedGraphControlMain.Hide();
//            zedGraphControl1.GraphPane.CurveList.Clear();
//            GraphPane myPane = zedGraphControl1.GraphPane;
//            myPane.Title.Text = "Experimental result of WAT on " + FileName + " time series";
//            myPane.XAxis.Title.Text = "Index";// "Thời gian cột X";
//            myPane.YAxis.Title.Text = "Value";// "Tiêu đề cột Y";            
//            int ZedminX = 0, ZedmaxX = B.Length;
//            if (B.Length >= 2000)
//            {
//                myPane.XAxis.Scale.Max = 2000;
//                if (index >= 1000)
//                {
//                    ZedminX = index - 1000;
//                    if (index <= (B.Length - 1000))
//                        ZedmaxX = index + 1000;
//                    else ZedmaxX = B.Length;
//                }
//                else
//                {
//                    ZedminX = 0;
//                    ZedmaxX = index + 1000;
//                }
//            }
//            myPane.XAxis.Scale.Min = ZedminX;
//            myPane.XAxis.Scale.Max = ZedmaxX;
//            zedGraphControl1.AxisChange();

//            PointPairList list1 = new PointPairList();
//            PointPairList listabnormal = new PointPairList();
//            PointPairList list2 = new PointPairList();

//            List<double> column1 = new List<double>();
//            List<double> column2 = new List<double>();

//            List<double> column3 = new List<double>();
//            List<double> column4 = new List<double>();
//            List<double> column5 = new List<double>();
//            List<double> column6 = new List<double>();
//            int Leng = Int32.Parse(cb_length.Text);
//            if (index > B.Length - Leng)
//            {
//                for (int i = ZedminX; i < ZedmaxX; i++)
//                {
//                    if (i < index)
//                    {
//                        column1.Add(i);
//                        column2.Add(B[i]);
//                    }
//                    else if (i == index)
//                    {
//                        column1.Add(i);
//                        column2.Add(B[i]);
//                        for (int j = index; j <= B.Length - 1; j++)
//                        {
//                            column3.Add(j);
//                            column4.Add(B[j]);
//                        }
//                    }
//                }
//            }
//            else
//            {
//                for (int i = ZedminX; i < ZedmaxX; i++)
//                {
//                    if (i < index)
//                    {
//                        column1.Add(i);
//                        column2.Add(B[i]);
//                    }
//                    else if (i == index)
//                    {
//                        column1.Add(i);
//                        column2.Add(B[i]);
//                        for (int j = index; j <= index + Leng - 1; j++)
//                        {
//                            column3.Add(j);
//                            column4.Add(B[j]);
//                        }
//                        i = i + Leng - 1;
//                        column5.Add(i);
//                        column6.Add(B[i]);
//                    }
//                    else
//                    {
//                        column5.Add(i);
//                        column6.Add(B[i]);
//                    }
//                }
//            }
//            list1.Add(column1.ToArray(), column2.ToArray());
//            listabnormal.Add(column3.ToArray(), column4.ToArray());
//            list2.Add(column5.ToArray(), column6.ToArray());
//            LineItem myCurve1 = myPane.AddCurve(FileName, list1, Color.Blue, SymbolType.None);
//            LineItem myAbnormal = myPane.AddCurve("Unusual sequence", listabnormal, Color.Red, SymbolType.None);
//            LineItem myCurve2 = myPane.AddCurve("", list2, Color.Blue, SymbolType.None);

//            zedGraphControl1.AxisChange();
//            zedGraphControl1.Invalidate();
//        }