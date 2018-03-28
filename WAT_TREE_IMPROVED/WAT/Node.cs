using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WAT
{
    ///<summary>
    ///Cấu trúc node để xây dựng list node khi duyệt cây đưa node vào list để sort và xây dựng vong heuristic
    ///</summary>
    public class Node
    {
        List<int> _index;
        string _label;
        int _count;
        public Node()
        {
            this._count = 0;
            this._label = "";
            this._index = new List<int>();
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public List<int> Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
        public void AddIndex(int Index)
        {
            _index.Add(Index);
        }
    }
}
