using System;

namespace MyDataStructures.DataStructures
{
    public class MyListBase<T>
    {
        internal T[] _myListItems;
        internal int _listSizeCurrent;
        internal int _listSizeCapacity;
        internal const int ListSizeCapacityToResizeWith = 2;

        public MyListBase()
        {
            _myListItems = new T[0];
            _listSizeCurrent = 0;
            _listSizeCapacity = 0;

        }

        public int Length {
            get { return _listSizeCurrent; }
        }

        public T[] Items 
        {
            get
            {
                T[] tempItems = new T[Length];
                tempItems = CopyArrayValues(_myListItems, tempItems);
                return tempItems;
            }
        }

        public T this[int itemPosition]
        {
            get
            {
                if (itemPosition < 0 || itemPosition >= _listSizeCurrent)
                    throw new IndexOutOfRangeException();

                return _myListItems[itemPosition];
            }
            set
            {
                if (itemPosition < 0 || itemPosition >= _listSizeCurrent)
                    throw new IndexOutOfRangeException();

                _myListItems[itemPosition] = value;
            }
        }

        

        public bool Exists(T itemValueToFind)
        {
            return BinarySearch(itemValueToFind, Items) >= 0;
        }

        internal int BinarySearch(T itemValueToFind, T[] arrayToSearch)
        {
            int positionFound = -1;
            var sortedList = Sort(Items);
            //var sortedListWithIntValues = ConvertAllItemsToNumbers(sortedList); 
            int itemValueToFindNumber = GetNumericValue(itemValueToFind.ToString());

            int lowPosition = 0;
            int highPosition = sortedList.Length - 1;
            while (highPosition >= lowPosition)
            {
                //correct calculation for the midpoint
                int position = lowPosition + ((highPosition - lowPosition) / 2);

                if (GetNumericValue(sortedList[position].ToString()) < itemValueToFindNumber)
                {
                    lowPosition = position + 1;
                }
                else if (GetNumericValue(sortedList[position].ToString()) > itemValueToFindNumber)
                {
                    highPosition = position - 1;
                }
                else if (sortedList[position].ToString() == itemValueToFind.ToString())
                {
                    positionFound = position;
                    break;
                }
            }
            //value not found
            return positionFound;
        }

        internal int GetNumericValue(string itemValue)
        {
            int calcValue = 0;
            foreach (char item in itemValue)
            {
                calcValue = calcValue + (int)item;
            }

            return calcValue;
        }

        public static T[] Sort(T[] inputArray)
        {
            T tempVal;

            for (int sortedItems = 0; sortedItems < inputArray.Length; sortedItems++)
            {
                for (int itemBusy = 0; itemBusy < inputArray.Length - 1; itemBusy++)
                {
                    string itemCurrent = inputArray[itemBusy].ToString();
                    string itemNext = inputArray[itemBusy + 1].ToString();


                    if (itemCurrent.CompareTo(itemNext) > 0)
                    {
                        T temp = inputArray[itemBusy];
                        inputArray[itemBusy] = inputArray[itemBusy + 1];
                        inputArray[itemBusy + 1] = temp;
                    }                  
                }
            }

            return inputArray;
        }

        internal void ResizeArrayIfNeeded()
        {
            int oldSize = _listSizeCapacity;
            int newSize = GetNewArraySize();

            if (oldSize != newSize)
            {
                _listSizeCapacity = newSize;
                var newArray = new T[_listSizeCapacity];
                _myListItems = CopyArrayValues(_myListItems, newArray);
            }
        }

        internal int GetNewArraySize()
        {
            int calcSize = 0;

            if (_listSizeCapacity == 0)
            {
                calcSize = ListSizeCapacityToResizeWith;
            }
            else if (_listSizeCurrent + 1 > _listSizeCapacity)
            {
                calcSize = _listSizeCapacity + ListSizeCapacityToResizeWith;
            }
            else
            {
                calcSize = _listSizeCapacity;
            }

            return calcSize;
        }

        public static T[] CopyArrayValues(T[] oldArray, T[] newArray, int itemToSkip = -1)
        {
            int maxNewArrayLenghToCopy = oldArray.Length;
            if (newArray.Length < oldArray.Length)
            {
                maxNewArrayLenghToCopy = newArray.Length;
            }

            for (int itemPos = 0; itemPos < maxNewArrayLenghToCopy; itemPos++)
            {
                if (itemToSkip >= 0 && itemPos == itemToSkip)
                {
                    newArray[itemPos] = oldArray[itemPos+1];
                    itemPos++;
                }
                else
                {
                    newArray[itemPos] = oldArray[itemPos];
                }
            }

            return newArray;
        }
    }
}