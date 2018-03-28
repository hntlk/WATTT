using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAT
{
    public class BruteForce
    {
        //List chứa chuỗi con
        List<double[]> Sub;
        //Số lần tính khoảng cách Euclean
        public int countB = 0;

        #region Extract
        /// <summary>
        /// Rút trích chuỗi các chuỗi con-> chuẩn hóa-> Haartransform
        /// </summary>
        private void Extract(double[] D, int LengthSub, int typeNor,double min, double max)
        {
            int n = D.Length - LengthSub + 1;
            Sub = new List<double[]>();
            for (int i = 0; i < n; i++)
            {
                double[] a = new double[LengthSub];
                int u = 0;
                for (int j = i; j < i + LengthSub; j++, u++)
                {
                    a[u] = D[j];
                }
                if (typeNor == 0)
                    Zcord(a);
                else MinMax(a, min, max);
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
        private double Normalization_Z_Score(double v_int, double giatritb, double phuongsai)
        {
            // chuan hoa Z_Score
            double v_out = (v_int - giatritb) / (phuongsai);
            return v_out;
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

        #region BRUTEFORCE
        ///<summary>
        ///DISTAIN EUCLEAN Hàm tính khoảng cách
        ///</summary>
        private double DistTest(double[] a, double[] b)
        {
            countB++;
            double tong = 0;
            int dem = a.Length;
            double tp = 0;
            for (int i = 0; i < dem; i++)
            {
                tp = a[i] - b[i];
                tong = tong + tp*tp;
            }
            return Math.Sqrt(tong); 
        }
        public int Brute(double[] B, int n, int nortype, double min, double max)
        {

            Extract(B, n, nortype, min, max);
            /*Mang danh dau tinh roi*/
            //mark = new double[B.Length,B.Length];
            double best_so_far_Dist = 0;
            int best_so_far_Location = 0;
            double distCal = 0;
            for (int i = 0; i < B.Length - n + 1; i++)
            {
                double nearest_neighbor_Dist = 9999;//B.Max()*n*2;
                for (int j = 0; j < B.Length - n + 1; j++)
                    if (Math.Abs(i - j) >= n)
                    {
                        //if (mark[i,j] == 0)
                        //{
                            //distCal = Dist(Sub, i, j);
                        distCal = DistTest(Sub[i], Sub[j]);
                            //mark[j, i] = distCal;
                        //}
                        //else distCal = mark[i, j];
                        if (distCal < nearest_neighbor_Dist)
                            nearest_neighbor_Dist = distCal;
                    }
                if (nearest_neighbor_Dist > best_so_far_Dist)
                {
                    best_so_far_Dist = nearest_neighbor_Dist;
                    best_so_far_Location = i;
                }
            }
            return best_so_far_Location;
        }
    }
        #endregion
}
