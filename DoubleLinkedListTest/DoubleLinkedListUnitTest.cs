using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DoubleLinkedListTest
{
    [TestClass]
    public class DoubleLinkedListUnitTest
    {
        private DoubleLinkedList<double> List;

        /// <summary>
        /// This will setup the most basic structure of DoubleLinkedList
        /// Additionally it serves the purpose to verify that the constructor
        /// do not fail
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            List = new DoubleLinkedList<double>();
        }

        /// <summary>
        /// Inserts, When retrieve Current and assert they are equal
        /// </summary>
        [TestMethod]
        public void TestInsertRetrieveCurrent()
        {
            List += 13;
            Assert.AreEqual(13, List.Current.Value);
        }

        /// <summary>
        /// Inserts, When retrieve First and assert they are equal
        /// </summary>
        [TestMethod]
        public void TestInsertRetrieveFirst()
        {
            List += 13;
            Assert.AreEqual(13, List.First.Value);
        }

        /// <summary>
        /// Inserts, When retrieve Last and assert they are equal
        /// </summary>
        [TestMethod]
        public void TestInsertRetrieveLast()
        {
            List += 13;
            Assert.AreEqual(13, List.Last.Value);
        }

        /// <summary>
        /// Test If inserting multiple works
        /// Assert for both First, Current and Last
        /// Expected:
        ///  - First : 13
        ///  - Last : 5
        ///  - Current : 13
        /// </summary>
        [TestMethod]
        public void TestMultipleInsert()
        {
            List += 13;
            List += 1;
            List += 5;
            Assert.AreEqual(13, List.First.Value);
            Assert.AreEqual(13, List.Current.Value);
            Assert.AreEqual(5, List.Last.Value);
        }

        [TestMethod]
        public void TestIndex()
        {
            List += 13;
            List += 1;
            List += 5;
            Assert.AreEqual(13, List[0].Value);
            Assert.AreEqual(1, List[1].Value);
            Assert.AreEqual(5, List[2].Value);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexOutOfBound()
        {
            List += 13;
            List += 1;
            List += 5;
            var exception = List[4];
        }

        [TestMethod]
        public void TestEqual()
        {
            List += 13;
            List += 1;
            List += 5;

            DoubleLinkedList<double> List2 = new DoubleLinkedList<double>();
            List2 += 13;
            List2 += 1;
            List2 += 5;
            
            Assert.IsTrue(List == List2);
            Assert.IsFalse(List != List2);
        }

        [TestMethod]
        public void TestNotEqualSize()
        {
            List += 13;
            List += 1;
            List += 5;

            DoubleLinkedList<double> List2 = new DoubleLinkedList<double>();
            List2 += 13;
            List2 += 1;
            List2 += 5;
            List2 += 5;

            Assert.IsFalse(List == List2);
            Assert.IsTrue(List != List2);

            List += 5;
            List += 10;

            Assert.IsFalse(List == List2);
            Assert.IsTrue(List != List2);
        }

        [TestMethod]
        public void TestNotEqualValues()
        {
            List += 137;
            List += 17;
            List += 57;

            DoubleLinkedList<double> List2 = new DoubleLinkedList<double>();
            List2 += 13;
            List2 += 1;
            List2 += 5;

            Assert.IsFalse(List == List2);
            Assert.IsTrue(List != List2);
        }

        [TestMethod]
        public void TestPredecessor()
        {
            List += 5;
            Assert.IsNull(List.First.Predecessor);
            List += 3;
            Assert.IsNotNull(List.Last.Predecessor);
            Assert.AreEqual(List.First, List.Last.Predecessor);
        }

        [TestMethod]
        public void TestSuccessor()
        {
            List += 5;
            List += 3;
            Assert.AreEqual(3, List.First.Successor.Value);
            Assert.AreEqual(List.Last.Value, List.First.Successor.Value);
            Assert.IsNull(List.Last.Successor);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestNegativeIndex()
        {
            List += 5;
            var haha = List[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullInsertException()
        {
            DoubleLinkedList<IComparable> list = new DoubleLinkedList<IComparable>();
            list += null;
        }
    }
}
