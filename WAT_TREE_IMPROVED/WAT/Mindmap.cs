using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WAT
{
    ///<summary>
    ///Cấu trúc package của hàm băm
    ///</summary>
    public class Mindmap
    {
        //mảng chứa chỉ số chuỗi
        int[] _index;
        //chuỗi ký tự khi chuyển qua SAX 
        string _label;
        //số lần xuất hiện của chuỗi
        int _count;
        public Mindmap()
        {
            this._label = "";
            this._count = 0;
            this._index = new int[_count];
        }
        public int[] Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
}
