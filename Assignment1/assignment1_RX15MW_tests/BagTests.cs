using assigment1_RX15MW;
using System.Numerics;

namespace assignment1_RX15MW_tests
{
    [TestClass]
    public class BagTests
    {
        [TestMethod]
        public void TestIsEmpty()
        {
            Bag b = new Bag();
            Assert.IsTrue(b.IsEmpty());

            b.InsertElement(1);
            Assert.AreNotEqual(true, b.IsEmpty());
        }

        [TestMethod]
        public void TestInsertSame()
        {
            Bag b = new Bag();
            b.InsertElement(13);
            List<Item> list = b.GetElements();

            Assert.AreEqual(13, list[0].element);
            Assert.AreEqual(1, list[0].frequency);

            b.InsertElement(13);
            b.InsertElement(13);
            b.InsertElement(13);

            Assert.IsTrue(list[0].frequency == 4);
        }

        [TestMethod]
        public void TestInsertDifferent()
        {
            Bag b = new Bag();
            b.InsertElement(27);
            b.InsertElement(38);
            b.InsertElement(46);
            List<Item> list = b.GetElements();

            Assert.AreEqual(1, list[0].frequency);
            Assert.AreEqual(1, list[1].frequency);
            Assert.AreEqual(1, list[2].frequency);

            b.InsertElement(27);
            b.InsertElement(27);
            b.InsertElement(27);
            b.InsertElement(27);

            b.InsertElement(38);
            b.InsertElement(38);
            b.InsertElement(38);
            b.InsertElement(38);
            b.InsertElement(38);
            b.InsertElement(38);

            b.InsertElement(46);
            b.InsertElement(46);
            b.InsertElement(46);
            b.InsertElement(46);
            b.InsertElement(46);

            list = b.GetElements();
            Assert.IsTrue(list[0].frequency == 5);
            Assert.IsTrue(list[1].frequency == 7);
            Assert.IsTrue(list[2].frequency == 6);
        }

        [TestMethod]
        public void TestRemoveSame()
        {
            Bag b = new Bag();

            try
            {
                b.RemoveElement(2);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.EmptyBag);
            }

            try
            {
                b.InsertElement(5);
                b.RemoveElement(2);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.NonExistingElement);
            }

            b.RemoveElement(5);

            // Testing elements
            b.InsertElement(1);
            List<Item> list = b.GetElements();
            Assert.AreEqual(1, list[0].frequency);
            b.RemoveElement(1);
            Assert.IsTrue(b.IsEmpty());

            b.InsertElement(2);
            b.InsertElement(2);
            list = b.GetElements();
            Assert.AreEqual(2, list[0].frequency);
            b.RemoveElement(2);
            list = b.GetElements();
            Assert.AreEqual(1, list[0].frequency);
            b.RemoveElement(2);
            Assert.IsTrue(b.IsEmpty());

            b.InsertElement(3);
            b.InsertElement(3);
            b.InsertElement(3);
            b.RemoveElement(3);
            Assert.IsFalse(b.IsEmpty());
        }

        [TestMethod]
        public void TestRemoveDifferent()
        {
            // White box testing for remove has been performed in the previous TestRemoveSame() method.
            // Testing elements
            Bag b = new Bag();
            b.InsertElement(3);
            b.InsertElement(7);
            //b.InsertElement(10);
            List<Item> list = b.GetElements();
            Assert.AreEqual(1, list[0].frequency);
            Assert.AreEqual(1, list[1].frequency);
            b.RemoveElement(3);
            b.RemoveElement(7);
            Assert.IsTrue(b.IsEmpty());

            b.InsertElement(3);
            b.InsertElement(3);
            b.InsertElement(3);
            b.InsertElement(5);
            b.InsertElement(5);
            list = b.GetElements();
            Assert.AreEqual(3, list[0].frequency);
            Assert.AreEqual(2, list[1].frequency);

            b.RemoveElement(3);
            list = b.GetElements();
            Assert.IsFalse(b.GetLength() == 0);

            b.RemoveElement(3);
            b.RemoveElement(3);
            b.RemoveElement(5);
            b.RemoveElement(5);
            Assert.IsTrue(b.IsEmpty());
        }

        [TestMethod]
        public void TestGetFrequency()
        {
            Bag b = new Bag();
            
            try
            {
                b.GetFrequency(9);
                Assert.Fail("not exception thrown");

            } catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.EmptyBag);
            }

            try
            {
                b.InsertElement(2);
                b.GetFrequency(3);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.NonExistingElement);
            }

            b.RemoveElement(2);

            // Testing elements
            b.InsertElement(17);
            b.InsertElement(23);
            b.InsertElement(61);

            Assert.IsTrue(b.GetFrequency(17) == 1);
            Assert.IsTrue(b.GetFrequency(23) == 1);
            Assert.IsTrue(b.GetFrequency(61) == 1);

            b.InsertElement(23);
            Assert.IsTrue(b.GetFrequency(23) == 2);

            b.RemoveElement(23);
            Assert.IsTrue(b.GetFrequency(23) == 1);
            b.RemoveElement(23);

            b.InsertElement(61);
            Assert.IsTrue(b.GetFrequency(61) == 2);

            b.InsertElement(17);
            b.InsertElement(17);
            Assert.IsTrue(b.GetFrequency(17) == 3);

            b.RemoveElement(17);
            b.RemoveElement(17);
            b.RemoveElement(17);
            b.RemoveElement(61);
            b.RemoveElement(61);
            Assert.AreEqual(0, b.GetLength());
        }

        [TestMethod]
        public void TestGetLargest()
        {
            Bag b = new Bag();

            try
            {
                b.GetLargest();
                Assert.Fail("not exception thrown");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.EmptyBag);
            }

            // Testing elements
            b.InsertElement(5);
            Assert.AreEqual(5, b.GetLargest());

            b.InsertElement(5);
            b.InsertElement(5);
            b.InsertElement(5);
            Assert.AreEqual(5, b.GetLargest());

            b.InsertElement(7);
            Assert.AreEqual(7, b.GetLargest());

            b.InsertElement(19);
            Assert.AreEqual(19, b.GetLargest());

            b.InsertElement(16);
            Assert.AreEqual(19, b.GetLargest());

            b.RemoveElement(19);
            Assert.AreEqual(16, b.GetLargest());
        }
    }
}