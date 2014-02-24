using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MyDataStructures.DataStructures
{
    public class MyQueue<T> : MyListBase<T>
    {
        public void Push(T itemValue)
        {
            ResizeArrayIfNeeded();
            PushAllItemsOnePositionDown();

            _myListItems[0] = itemValue;
            _listSizeCurrent++;
        }

        public T Pop()
        {
            if (Length > 0)
            {
                T itemToReturn = _myListItems[0];

                _listSizeCurrent--;

                PushAllItemsOnePositionUp();

                return itemToReturn;
            }

            return default(T);
        }

        private void PushAllItemsOnePositionDown()
        {
            for (int itemPos = _listSizeCapacity - 1; itemPos > 0; itemPos--)
            {
                _myListItems[itemPos] = _myListItems[itemPos-1];
            }

            _myListItems[0] = default(T);
        }

        private void PushAllItemsOnePositionUp()
        {
            for (int itemPos = 0; itemPos < _listSizeCapacity - 1; itemPos++)
            {
                _myListItems[itemPos] = _myListItems[itemPos + 1];
            }

            _myListItems[_listSizeCurrent] = default(T);
        }                
    }
}
