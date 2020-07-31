using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLinkedList.Tests
{
    class AssertExtension
    {
        public static void AreEqual<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            var list1 = collection1.ToList();
            int index = 0;
            foreach (var element in collection2)
            {
                Assert.AreEqual(list1[index++], element);
            }
        }
    }
    [TestClass()]
    public class MyLinkedListTests
    {

        [TestMethod()]
        public void Createできるよね()
        {
            var linkedList = new MyLinkedList<int>();
            Assert.AreEqual(0, linkedList.Count);
            Assert.IsNull(linkedList.First);
            Assert.IsNull(linkedList.Last);
        }

        [TestMethod()]
        public void AddLastできるよね()
        {
            var linkedList = new MyLinkedList<int>();
            linkedList.AddLast(100);
            Assert.AreEqual(1, linkedList.Count);
            Assert.AreEqual(100, linkedList.Last.Item);
            linkedList.AddLast(200);
            Assert.AreEqual(2, linkedList.Count);
            AssertExtension.AreEqual<int>(linkedList, new[] { 100, 200 });

            linkedList.AddLast(300);
            Assert.AreEqual(3, linkedList.Count);
            AssertExtension.AreEqual<int>(linkedList, new[] { 100, 200, 300 });
        }

        [TestMethod()]
        public void AddFirstできるよね()
        {
            var linkedList = new MyLinkedList<int>();
            linkedList.AddFirst(100);
            Assert.AreEqual(1, linkedList.Count);
            linkedList.AddLast(200);
            Assert.AreEqual(2, linkedList.Count);

            linkedList.AddFirst(300);
            AssertExtension.AreEqual<int>(linkedList, new[] { 300, 100, 200 });
        }

        [TestMethod()]
        public void Findできるかな()
        {
            var linkedList = new MyLinkedList<int>();
            linkedList.AddLast(100);
            linkedList.AddLast(200);
            linkedList.AddLast(300);

            var node = linkedList.Find(100);
            Assert.AreSame(node, linkedList.First);
            Assert.AreSame(linkedList.Find(200), linkedList.First.Next);
            Assert.AreSame(linkedList.Find(300), linkedList.Last);

            Assert.IsNull(linkedList.Find(400));
        }

        [TestMethod()]
        public void Removeできるかな()
        {
            var linkedList = new MyLinkedList<int>();
            linkedList.AddLast(100);
            linkedList.AddLast(200);
            linkedList.AddLast(300);
            linkedList.AddLast(400);
            linkedList.AddLast(500);

            linkedList.Remove(linkedList.First);
            AssertExtension.AreEqual(linkedList, new[] { 200, 300, 400, 500 });
            Assert.AreEqual(4, linkedList.Count);
            linkedList.Remove(linkedList.First.Next);
            AssertExtension.AreEqual(linkedList, new[] { 200, 400, 500 });
            Assert.AreEqual(3, linkedList.Count);
            linkedList.Remove(linkedList.Last);
            AssertExtension.AreEqual(linkedList, new[] { 200, 400 });
            Assert.AreEqual(2, linkedList.Count);
        }
    }


}