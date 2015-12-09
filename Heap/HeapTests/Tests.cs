using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCoutureAssignment3;
using NUnit.Framework;

namespace HeapTests
{
    class Tests
    {
        Heap<Book> h;
        Book b1;
        Book b2;
        Book b3;
        Book b4;
        Book b5;

        [SetUp]
        public void CreateHeap()
        {
            h = new Heap<Book>(10);

            b1 = new Book("Aardvarks Anonymous", "Larry Purton", "John Freeman", 9.99m);
            b2 = new Book("Aww yiss", "Karl, King of Ducks", "Da Chinz", 4.20m);
            b3 = new Book("Oh hi Mark", "Johnny", "Also Johnny", 8.99m);
            b4 = new Book("How to speling", "Morgan Freeman", "Tom Hanks", 20.99m);
            b5 = new Book("U wot m8", "Britbong Fancypants", "The Queen", 16.91m);
        }

        [Test]
        public void ExceptionOnTooLargeHeap()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => h = new Heap<Book>(101));
        }

        [Test]
        public void ExceptionOnNegativeSizeArray()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => h = new Heap<Book>(-1));
        }

        [Test]
        public void CheckEmpty()
        {
            Assert.IsTrue(h.IsEmpty());
        }

        [Test]
        public void CheckNotEmpty()
        {
            h.Insert(b5);
            Assert.IsFalse(h.IsEmpty());
        }
        
        [Test]
        public void CheckZeroEntries()
        {
            Assert.AreEqual(0, h.Entries());
        }

        [Test]
        public void CheckThreeEntries()
        {
            h.Insert(b1);
            h.Insert(b3);
            h.Insert(b2);
            Assert.AreEqual(3, h.Entries());
        }

        [Test]
        public void CheckCounterAfterRemovingMin()
        {
            h.Insert(b1);
            h.Insert(b4);
            h.Insert(b5);
            h.GetMin();
            Assert.AreEqual(2, h.Entries());
        }

        [Test]
        public void FindBookInsertedInOrder()
        {
            h.Insert(b1);
            h.Insert(b2);
            h.Insert(b3);
            Assert.AreEqual(b1, h.GetMin());
        }

        [Test]
        public void FindBookInsertedNotInOrder()
        {
            h.Insert(b3);
            h.Insert(b2);
            h.Insert(b1);
            Assert.AreEqual(b1, h.GetMin());
        }

        [Test]
        public void FindBookAfterPreviousMinRemoved()
        {
            h.Insert(b1);
            h.Insert(b2);
            h.Insert(b3);
            h.GetMin();
            Assert.AreEqual(b2, h.GetMin());
        }

        [Test]
        public void GetMinFromEmptyArray()
        {
            Assert.IsNull(h.GetMin());
        }

        [Test]
        public void GetMinAfterInsert()
        {
            h.Insert(b1);
            h.Insert(b3);
            h.GetMin();
            h.Insert(b2);
            Assert.AreEqual(b2, h.GetMin());
        }

        [Test]
        public void AttemptInsertOnFullArray()
        {
            h = new Heap<Book>(4);
            h.Insert(b1);
            h.Insert(b2);
            h.Insert(b3);
            h.Insert(b4);
            Assert.Throws<ArgumentOutOfRangeException>(() => h.Insert(b5));
        }

    }
}
