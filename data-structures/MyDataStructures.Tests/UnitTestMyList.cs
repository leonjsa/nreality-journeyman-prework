using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MyDataStructures.DataStructures;
using NUnit.Framework;

namespace MyDataStructures.Tests
{
    [TestFixture]
    public class UnitTestMyList
    {
        [Test]
        public void ItemsAddedToListShouldExist()
        {
            var testValue1 = "Test value1";
            var testValue2 = "Test value2";
            var testValue3 = "Test value3";
            var testValue4 = "Test value4";
            var testValue5 = "Test value5";

            var myList = new MyList<string>();
            myList.Add(testValue1);
            myList.Add(testValue2);
            myList.Add(testValue3);
            myList.Add(testValue4);
            myList.Add(testValue5);
            Assert.That(myList[0], Is.EqualTo(testValue1));
            Assert.That(myList[1], Is.EqualTo(testValue2));
            Assert.That(myList[2], Is.EqualTo(testValue3));
            Assert.That(myList[3], Is.EqualTo(testValue4));
            Assert.That(myList[4], Is.EqualTo(testValue5));
            Assert.That(myList.Length == 5);
        }

        [Test]
        public void ItemAddedToListAndUpdatedShouldContainNewItem()
        {
            var testValue1 = "Test value1";
            var testValue2 = "Test value2";

            var myList = new MyList<string>();
            myList.Add(testValue1);

            myList[0] = testValue2;

            Assert.That(myList[0], Is.EqualTo(testValue2));
        }

        [Test]
        public void UnsortedListShouldBeInSortedOrderAfterCallingSortFunction()
        {
            var items = new string[] {"Pear", "apple", "Lemon", "Banana"};
            var itemsSorted = new string[] { "apple", "Banana", "Lemon", "Pear" };
            var newItems = MyList<string>.Sort(items);

            Assert.That(newItems, Is.EqualTo(itemsSorted));
        }

        [Test] //Case("Hallo")]
        public void FindItemsWithSpecificStringValue() //string valueToFind)
        {
            string valueToFind = "Hallo";

            var testValue1 = "Test value1";
            var testValue2 = "Hallo";
            var testValue3 = "Test value3";

            var myList = new MyList<string>();
            myList.Add(testValue1);
            myList.Add(testValue2);
            myList.Add(testValue3);

            var itemFound = myList.Exists(valueToFind);

            Assert.IsTrue(itemFound);
        }

        [Test]
        public void ItemAddedToListIsRemovedTheListSizeShouldBeDecremented()
        {
            var testValue1 = "Test value1";
            var testValue2 = "Test value2";
            var testValue3 = "Test value3";

            var myList = new MyList<string>();
            myList.Add(testValue1);
            myList.Add(testValue2);
            myList.Add(testValue3);           

            myList.Remove(1);
            
            Assert.That(myList.Length, Is.EqualTo(2));
            Assert.That(myList[1], Is.EqualTo(testValue3));
        }

        [Test]
        public void ItemCanBeRetrievedUsingItemsProperty()
        {
            var testValue1 = "Test value1";
            var testValue2 = "Test value2";
            var testValue3 = "Test value3";

            var myList = new MyList<string>();
            myList.Add(testValue1);
            myList.Add(testValue2);
            myList.Add(testValue3);

            Assert.That(myList.Items[1], Is.EqualTo(testValue2));
        }

        [Test]
        public void InvalidNewArrayLenghShouldThrowException()
        {
            var oldArray = new string[5];
            var newArray = new string[3];

            newArray = MyList<string>.CopyArrayValues(oldArray, newArray);
            Assert.That(newArray.Length, Is.EqualTo(3));
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ItemPositionSpecifiedIsOutsideBoundsIndexOutOfRangeExceptionShouldBeThrownOnAdd()
        {
            var myList = new MyList<string>();
            myList[0] = myList[1];
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ItemPositionSpecifiedIsOutsideBoundsIndexOutOfRangeExceptionShouldBeThrownOnRemove()
        {
            var myList = new MyList<string>();
            myList.Remove(1);
        }
    }
}
