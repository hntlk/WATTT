using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static public int pos(string a, string b, string[] c)
        {
            
            int i = 0;
            int j = 0;
            int min = 1; 
            int t1 = 0, t2 = 0 ;
            Boolean f_a = false, f_b = false; 
            int minn = c.Length;
            if (a != b)
            {
            do
            {
                for (; i < c.Length; i++)
                {
                    if (c[i] == a)
                    {
                        t1 = i;
                        f_a = true;
                        break;
                    }
                }
                for (; j < c.Length; j++)
                {
                    if (c[j] == b)
                    {
                        t2 = j;
                        f_b = true;
                        break;
                    }
                }
                if (t2 > t1)
                {
                    min = t2 - t1;
                }
                else
                {
                    min = t1 - t2;
                }     
                if (minn > min)
                {
                    minn = min;
                }
                i++; j++;
            }
            while ((i < c.Length) || (j < c.Length));}
            else{
                for (; i < c.Length; i++)
                {
                    if (c[i] == a)
                    {
                        t1 = i;
                        break;
                    }
                }
                i++;
                for (; i < c.Length; i++)
                {
                    if (c[i] == a)
                    {
                        t2 = i;
                        break;
                    }
                }
                minn = t2 - t1;
            }
            if (!(f_a && f_b)) return -1;
            return minn;
        }
        static void Main(string[] args)
        {
            string[] a = { "cat", "dog", "bird", "fish", "cat", "duck", "chicken", "dog" };
            Console.WriteLine("{0}: ",pos("fish","chicken",a));
            Console.ReadLine();
        }
    }
}
