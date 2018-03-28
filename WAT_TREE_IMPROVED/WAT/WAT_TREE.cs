using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace WAT
{
    class WAT_TREE
    {
        //auto change WORDLENGTH 
        //Ex->No->Ha->Sa->Wa
        double b1 = 0, b2 = 0, b3 = 0, b4 = 0, b5 = 0, b6 = 0, b7 = 0, b8 = 0, b9 = 0;
        //Vị trí bất thường
        int index = 0;
        //Số lần tính khoảng cách Euclean
        public double countE = 0;
        //List chứa chuỗi con
        List<double[]> Sub;
        List<double[]> Sub_Haar;
        //List chuỗi ký tự sau khi rời rạc hóa
        List<string> Sub_Char;
        //Node gốc
        TreeNode<Node> root_OR;
        //List chứa node lá
        List<TreeNode<Node>> ListContainLastNode = new List<TreeNode<Node>>();

        bool stop = false;

        private const double w0 = 0.5;
        private const double w1 = -0.5;
        private const double s0 = 0.5;
        private const double s1 = 0.5;

        public int iWAT(double[] T, int LengthSub, int x, int nortype, double min, double max, int decrease, int wordlength)
        {
            //Hover mouse to view Summary of each function
            Extract(T, LengthSub, nortype, min, max);

            if (wordlength == 0)
            {
                DecleaChar();
                int i = 1;
                for (; i <= LengthSub / decrease; i = i * 2)
                {
                    if (stop) break;
                    Restone(i);
                    ConvertPlusChar(x);
                    Create_tree();
                }
                for (; i <= LengthSub / decrease; i = i * 2)
                    Restone(i);
            }
            else
            {
                int i = 1;
                for (; i <= wordlength; i = i * 2)
                {
                    Restone(i);
                    Convert(x);
                }
                Create_tree();
                for (; i <= LengthSub / decrease; i = i * 2)
                    Restone(i);
            }
            TWAT(LengthSub, T.Length);
            return index;
        }

        #region Extract
        /// <summary>
        /// Rút trích chuỗi các chuỗi con-> chuẩn hóa-> Haartransform
        /// </summary>
        private void Extract(double[] D, int LengthSub, int typeNor, double min, double max)
        {
            int n = D.Length - LengthSub + 1;
            Sub = new List<double[]>();
            for (int i = 0; i < n; i++)
            {
                double[] a = new double[LengthSub];
                a = D.Skip(i).Take(LengthSub).ToArray();
                if (typeNor == 0)
                    Zcord(a);
                else MinMax(a, min, max);
                HWT(Sub[i]);
            }
        }
        #endregion

        #region Nomalization
        /// <summary>
        /// Chuẩn hóa minmax
        /// </summary>
        private double NormalizeMinMax(double minn, double maxx, double v, double min, double max)
        {
            double x = 0;
            x = (((v - min) * (maxx - minn)) / (max - min)) + minn;
            return x;
        }
        private void MinMax(double[] B, double minn, double maxx)
        {
            double max = B.Max();
            double min = B.Min();
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = NormalizeMinMax(minn, maxx, B[i], min, max);
            }
            Sub.Add(B);
        }
        /// <summary>
        /// Chuẩn hóa zero
        /// </summary>
        private double Normalization_Z_Score(double v_int, double giatritb, double phuongsai)
        {
            return (v_int - giatritb) / (phuongsai);
        }
        private void Zcord(double[] B)
        {
            double giatritb = B.Average();
            double tu = 0.0;
            double pow = 0;
            for (int i = 0; i < B.Length; i++)
            {
                pow = (B[i] - giatritb);
                tu += pow * pow;
            }
            double phuongsai = 0.0;
            phuongsai = Math.Sqrt(tu / (B.Length - 1));
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = Normalization_Z_Score(B[i], giatritb, phuongsai);
            }
            Sub.Add(B);
        }
        #endregion

        #region HAAR WAVELET TRANSFORM
        /// <summary>
        /// HAAR WAVELET TRANSFORM
        /// </summary>
        /*      
        f(x) = (9 7 3 5)
        Độ phân giải	Giá trị tnmg bình	Hệ sỏ khác biệt
	        4	         (9   7   3   5)	
	        2	           (8       4)	        (1   -1)
	        1	               (6)	              (2)
        H(f[1]) = (6 2 1 -1)
        */
        private void HWT(double[] data)
        {
            double[] temp = new double[data.Length];
            
            int h = data.Length;
            while (h > 1)
            {
                //Divide by half giảm 1 nứa
                h = h >> 1;
                for (int i = 0; i < h; i++)
                {
                    int k = (i << 1);
                    temp[i] = (data[k] * s0 + data[k + 1] * s1);
                    temp[i + h] = (data[k] * w0 + data[k + 1] * w1);
                }
                for (int i = 0; i < data.Length; i++)
                    data[i] = temp[i];
            }
        }
        #endregion

        #region INVERT
        /// <summary>
        /// Phục hồi chuỗi (chuỗi cần phục hồi, độ phân giải)
        /// </summary>
        /*      
        f(x) = (9 7 3 5)
        Độ phân giải	Giá trị tnmg bình	Hệ sỏ khác biệt
            4	         (9   7   3   5)	
            2	           (8       4)	        (1   -1)
            1	               (6)	              (2)
        H(f[1]) = (6 2 1 -1)  
        Restone(1) --> 6
        Restone(2) --> 8 4
        Restone(4) --> 9 7 3 5
        */
        public void Restone(int i)
        {
            Sub_Haar = new List<double[]>();
            foreach (var j in Sub)
            {
                Sub_Haar.Add(IWT(j, i));
            }
        }
        /// <summary>
        /// INVERT WAVELET TRANSFORM
        /// </summary>
        public double[] IWT(double[] data, int h)
        {
            double[] temp = new double[h];
            int u = h;
            h = h >> 1;
            for (int i = 0; i < h; i++)
            {
                int k = (i << 1);
                temp[k] = (data[i] * s0 + data[i + h] * w0) / w0;
                temp[k + 1] = (data[i] * s1 + data[i + h] * w1) / s0;
            }
            if (u != 1)
            {
                for (int i = 0; i < u; i++)
                    data[i] = temp[i];
            }
            return data.Take(u).ToArray();
        }
        #endregion

        #region Convert AUTO WORDLENGTH
        /// <summary>
        /// Khởi tạo list chuỗi ký tự AUTO WORDLENGTH
        /// </summary>
        private void DecleaChar()
        {
            Sub_Char = new List<string>();
            for (int i = 0; i < Sub.Count; i++)
            {
                string b = "";
                Sub_Char.Add(b);
            }
        }
        /// <summary>
        /// Chuyển chuỗi con sang chuỗi ký tự AUTO WORDLENGTH
        /// </summary>
        private void ConvertPlusChar(int numberofchar)
        {
            cutpoint(numberofchar);
            for (int i = 0; i < Sub_Haar.Count; i++)
            {
                string b = iSAX(numberofchar, Sub_Haar[i]);
                Sub_Char[i] = Sub_Char[i] + b;
            }
        }
        /// <summary>
        /// Chuyển chuỗi con sang chuỗi ký tự
        /// </summary>
        /// <param name="numberofchar"></param>
        private void Convert(int numberofchar)
        {
            Sub_Char = new List<string>();
            cutpoint(numberofchar);
            foreach (var i in Sub_Haar)
            {
                Sub_Char.Add(iSAX(numberofchar, i));
            }
        }
        /// <summary>
        /// Gauß
        /// </summary>
        private void cutpoint(int x)
        {
            if (x == 3)
            {
                b1 = -0.43;
                b2 = 0.43;
            }
            else if (x == 4)
            {
                b1 = -0.67;
                b2 = 0;
                b3 = 0.67;
            }
            else if (x == 5)
            {
                b1 = -0.84;
                b2 = -0.25;
                b3 = 0.25;
                b4 = 0.84;
            }
            else if (x == 6)
            {
                b1 = -0.97;
                b2 = -0.43;
                b3 = 0;
                b4 = 0.43;
                b5 = 0.97;
            }
            else if (x == 7)
            {
                b1 = -1.07;
                b2 = -0.57;
                b3 = -0.18;
                b4 = 0.18;
                b5 = 0.57;
                b6 = 1.07;
            }
            else if (x == 8)
            {
                b1 = -1.15;
                b2 = -0.67;
                b3 = -0.32;
                b4 = 0;
                b5 = 0.32;
                b6 = 0.67;
                b7 = 1.15;
            }
            else if (x == 9)
            {
                b1 = -1.22;
                b2 = -0.76;
                b3 = -0.43;
                b4 = -0.14;
                b5 = 0.14;
                b6 = 0.43;
                b7 = 0.76;
                b8 = 1.22;
            }
            else
            {
                b1 = -1.28;
                b2 = -0.84;
                b3 = -0.52;
                b4 = -0.25;
                b5 = 0;
                b6 = 0.25;
                b7 = 0.52;
                b8 = 0.84;
                b9 = 1.28;
            }
        }
        /// <summary>
        /// SAX Rời rạc hóa
        /// </summary>
        private string iSAX(int x, double[] D)
        {
            string E = "";
            if (x == 3) //lấy 3 ký tự alphabeth {a,b,c}
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                        E = E + "a";
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E = E + "b";
                    }
                    else E = E + "c";
                }
            }
            else if (x == 4) //lấy 4 ký tự alphabeth {a,b,c,d}
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                        E += "a";
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E += "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E += "c";
                    }
                    else E += "d";
                }
            }
            else if (x == 5)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                        E += "a";
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E += "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E += "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E += "d";
                    }
                    else E += "e";
                }
            }
            else if (x == 6)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                        E += "a";
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E += "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E += "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E += "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E += "e";
                    }
                    else E += "f";
                }
            }
            else if (x == 7)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                        E += "a";
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E += "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E += "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E += "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E += "e";
                    }
                    else if ((b5 < D[i]) && (D[i] <= b6))
                    {
                        E += "f";
                    }
                    else E += "g";
                }
            }
            else if (x == 8)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                        E += "a";
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E += "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E += "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E += "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E += "e";
                    }
                    else if ((b5 < D[i]) && (D[i] <= b6))
                    {
                        E += "f";
                    }
                    else if ((b6 < D[i]) && (D[i] <= b7))
                    {
                        E += "g";
                    }
                    else E += "h";
                }
            }
            else if (x == 9)
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                        E += "a";
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E += "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E += "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E += "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E += "e";
                    }
                    else if ((b5 < D[i]) && (D[i] <= b6))
                    {
                        E += "f";
                    }
                    else if ((b6 < D[i]) && (D[i] <= b7))
                    {
                        E += "g";
                    }
                    else if ((b7 < D[i]) && (D[i] <= b8))
                    {
                        E += "h";
                    }
                    else E += "i";
                }
            }
            else
            {
                for (int i = 0; i < D.Length; i++)
                {
                    if (D[i] <= b1)
                        E += "a";
                    else if ((b1 < D[i]) && (D[i] <= b2))
                    {
                        E += "b";
                    }
                    else if ((b2 < D[i]) && (D[i] <= b3))
                    {
                        E += "c";
                    }
                    else if ((b3 < D[i]) && (D[i] <= b4))
                    {
                        E += "d";
                    }
                    else if ((b4 < D[i]) && (D[i] <= b5))
                    {
                        E += "e";
                    }
                    else if ((b5 < D[i]) && (D[i] <= b6))
                    {
                        E += "f";
                    }
                    else if ((b6 < D[i]) && (D[i] <= b7))
                    {
                        E += "g";
                    }
                    else if ((b7 < D[i]) && (D[i] <= b8))
                    {
                        E += "h";
                    }
                    else if ((b8 < D[i]) && (D[i] <= b9))
                    {
                        E += "i";
                    }
                    else E += "j";
                }
            }
            return E;
        }
        #endregion

        #region Tree
        ///<summary>
        ///Xây cây
        ///</summary>
        private void Create_tree()
        {
            //node gốc
            root_OR = new TreeNode<Node>(new Node { Label = "root" });
            //node current - node dùng để xét
            TreeNode<Node> root = new TreeNode<Node>(new Node { });
            int i = 0;
            foreach (var str in Sub_Char)// Với mỗi chuỗi ký tự trong list chuỗi ký tự ta lần lượt đưa từng ký tự vào node
            {
                root = root_OR;
                int len = str.Length;// Độ dài chuỗi ký tự (abc -> length: 3)
                for (int j = 0; j < len; j++)
                {
                    //Khởi tạo node từ ký tự thứ j đang xét trong chuỗi ký tự
                    TreeNode<Node> a = new TreeNode<Node>(new Node { Label = str[j].ToString() });
                    //Hover mouse into HasNodeChild(a) function
                    int current = root.HasNodeChild(a);
                    if (current == -1) { root.AddChild(a); root = root.Children[root.HasNodeChild(a)]; } //Không tìm thấy node thì add node và chuyển sang node đã add
                    else { root = root.Children[current]; }
                    //Chỉ số chuỗi được đưa vào node lá của cây
                    if (j == len - 1)
                    {
                        root.Data.AddIndex(i);
                    }
                }
                i++;
            }
            //Lấy node lá đưa vào list
            ListContainLastNode = root_OR.ListHeuristic().ToList();
            if (ListContainLastNode.Any(x => x.Data.Index.Count == 1)) stop = true;
        }
        //FIND OUTER HEURISTIC
        public List<TreeNode<Node>> Outer()
        {
            return ListContainLastNode.OrderBy(x => x.Data.Index.Count).ToList();
        }
        //FIND INNER HEURISTIC
        private IEnumerable<int> FindLongestPath(TreeNode<Node> key)
        {
            //TreeNode<Node> f = new TreeNode<Node>(new Node { });
            //f = root_OR.ParentHasOneMoreChild(root_OR, key);
            //IEnumerable<int> list;
            //if (f != null)
            //{
            //    list = f.ListHeuristic().SelectMany(x => x.Data.Index);
            //    return list;
            //}
            IEnumerable<int> list = key.Data.Index;
            if (list != null)
            {
                return list;
            }
            return null;
        }
        private static Random rng = new Random();
        public void Shuffle(List<int> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        #endregion

        #region WAT_TREE
        ///<summary>
        ///DISTAIN EUCLEAN Hàm tính khoảng cách
        ///</summary>
        private double DistTest(double[] a, double[] b)
        {
            countE++;
            double tong = 0;
            int dem = a.Length;
            double tp = 0;
            for (int i = 0; i < dem; i++)
            {
                tp = a[i] - b[i];
                tong = tong + tp * tp;
            }
            return Math.Sqrt(tong); ;
        }

        ///<summary>
        ///WAT_Tree
        ///</summary>
        private void TWAT(int LengthSub, int LengthTimeSeries)
        {
            //Length of subsequence
            double best_so_far_Dist = 0;
            int best_so_far_Location = 0;
            double distCal = 0;
            int oo = LengthTimeSeries - LengthSub + 1;
            List<int> total = new List<int>();
            for (int j = 0; j < oo; j++)
            {
                total.Add(j);
            }
            Shuffle(total);
            List<TreeNode<Node>> outer = new List<TreeNode<Node>>();
            outer = Outer();
            IEnumerable<int> inner;
            //Outer Heurictic      
            foreach (var o in outer)
                foreach (var i in o.Data.Index)
                {
                    double nearest_neighbor_Dist = 9999;
                    //inner = FindLongestPath(o);
                    // if (inner != null) total = inner.Concat(total).Distinct().ToList();

                    foreach (var j in total)
                    {
                        if (Math.Abs(i - j) >= LengthSub)
                        {
                            distCal = DistTest(Sub_Haar[i], Sub_Haar[j]);
                            if (distCal < nearest_neighbor_Dist)
                            {
                                nearest_neighbor_Dist = distCal;
                            }
                            if (distCal < best_so_far_Dist)
                            {
                                break;
                            }
                        }
                    }
                    if (nearest_neighbor_Dist > best_so_far_Dist)
                    {
                        best_so_far_Dist = nearest_neighbor_Dist;
                        best_so_far_Location = i;
                    }
                }
            index = best_so_far_Location;
        }
    }
    #endregion
}