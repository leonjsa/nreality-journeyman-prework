using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace MyDataStructures.DataStructures
{
    public class MyList<T> : MyListBase<T>
    {
        public virtual void Add(T myListItem)
        {
            ResizeArrayIfNeeded();

            _myListItems[_listSizeCurrent] = myListItem;
            _listSizeCurrent++;
        }

        public void Remove(int itemPosition)
        {
            if (itemPosition < 0 || itemPosition >= _listSizeCurrent)
                throw new IndexOutOfRangeException();

            var newArray = new T[_listSizeCapacity];

            _myListItems = CopyArrayValues(_myListItems, newArray, itemPosition);

            _listSizeCurrent--;

            ResizeArrayIfNeeded();
        }
    }
}
