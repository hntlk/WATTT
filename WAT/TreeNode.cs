using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace WAT
{
    ///<summary>
    ///Cấu trúc xây cây
    ///</summary>
    public class TreeNode<T> where T : Node
    {
        // Khai báo biến kiểu generic.
        public T Data;
        // Khởi tạo list node.
        public List<TreeNode<T>> Children = new List<TreeNode<T>>();
        //Unit
        public TreeNode(T new_data)
        {
            Data = new_data;
        }
        ///<summary>
        ///Thêm node con cho node.
        ///</summary>
        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }
        ///<summary>
        ///Hàm xét có ký tự cần tìm trong các node con của node đang xét hay không. Có trả về thứ tự node con, không trả về -1
        ///</summary>
        public int HasNodeChild(TreeNode<T> target)
        {
            int i = 0;
            foreach (TreeNode<T> child in Children)
            {
                if (child.Data.Label == target.Data.Label)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        ///<summary>
        ///Lấy node lá đưa vào list
        ///</summary>
        public List<TreeNode<T>> ListHeuristic()
        {
            List<TreeNode<T>> list = new List<TreeNode<T>>();
            FindListHeuristic(list);
            return list;
        }
        ///<summary>
        ///Hàm xét node hiện tại có node con hay không.
        ///</summary>
        private List<TreeNode<T>> FindListHeuristic(List<TreeNode<T>> list)
        {
            foreach (TreeNode<T> child in Children)
            {
                if (child.Children.Count == 0)
                {
                    list.Add(child);
                }
                child.FindListHeuristic(list);
            }
            return list;
        }
    }
}
