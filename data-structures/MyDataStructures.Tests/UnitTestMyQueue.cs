using MyDataStructures.DataStructures;
using System;
using NUnit.Framework;

namespace MyDataStructures.Tests
{
    [TestFixture]
    public class UnitTestMyQueue
    {
        [Test]
        public void LastItemPushedToListShouldBeAtPosition0()
        {
            var myQueue = new MyQueue<string>();
           
            myQueue.Push("Test1");
            myQueue.Push("Test2");
            myQueue.Push("Test3");

            Assert.That(myQueue[0], Is.EqualTo("Test3"));
        }

        [Test]
        public void PopItemShouldBeLastItemPushed()
        {
            var myQueue = new MyQueue<string>();

            myQueue.Push("Test1");
            myQueue.Push("Test2");
            myQueue.Push("Test3");
            var item = myQueue.Pop();

            Assert.That(item, Is.EqualTo("Test3"));
            Assert.That(myQueue[0], Is.EqualTo("Test2"));
        }
    }
}
