using MP.SampleCode.LinkedList.Tests.Models;

namespace MP.SampleCode.LinkedList.Tests
{
    [TestClass]
    public unsafe class InsertItemToLinkedListTests
    {
        private void TestSingleValue<T>(T valueToInsert)
        {
            var list = new CustomLinkedList<T>();

            list.Insert(&valueToInsert);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(valueToInsert, list[0]);
        }

        [TestMethod]
        public void InsertIntToEmptyListTest()
        {
            TestSingleValue(144);
        }

        [TestMethod]
        public void InsertStringToEmptyListTest()
        {
            TestSingleValue("Some Value");
        }

        [TestMethod]
        public void InsertReferenceTypeToEmptyListTest()
        {
            TestSingleValue(new ListTestClass { ExampleProperty = "1332" });
        }

        private void TestManyValues<T>(T*[] valuesToInsert)
        {
            var list = new CustomLinkedList<T>();

            foreach (var value in valuesToInsert)
            {
                list.Insert(value);
            }

            Assert.AreEqual(valuesToInsert.Length, list.Count);

            for (var i = 0; i < valuesToInsert.Length; i++)
            {
                Assert.AreEqual(*valuesToInsert[i], list[i]);
            }
        }

        [TestMethod]
        public void InsertIntsToListTest()
        {
            int
                testItem1 = 1557,
                testItem2 = 144,
                testItem3 = 52,
                testItem4 = 4862;

            TestManyValues(new[] { &testItem1, &testItem2, &testItem3, &testItem4 });
        }

        [TestMethod]
        public void InsertStringsToListTest()
        {
            string
                testItem1 = "Lemon",
                testItem2 = "",
                testItem3 = "Some Value";

            TestManyValues(new[] { &testItem1, &testItem2, &testItem3 });
        }

        [TestMethod]
        public void InsertReferenceTypesToListTest()
        {
            ListTestClass
                testItem1 = new ListTestClass { ExampleProperty = "548" },
                testItem2 = new ListTestClass { ExampleProperty = "6891" },
                testItem3 = new ListTestClass { ExampleProperty = "7" },
                testItem4 = new ListTestClass { ExampleProperty = "65" },
                testItem5 = new ListTestClass { ExampleProperty = "0" };

            TestManyValues(new[] { &testItem1, &testItem2, &testItem3, &testItem4, &testItem5 });
        }

        private void TestInsertAt<T>(T*[] valuesToInsert, int insertAt, T* fillValue)
        {
            var list = new CustomLinkedList<T>();

            for (var i = 0; i < 100; i++)
            {
                list.Insert(fillValue, 0);
            }

            Assert.AreEqual(100, list.Count);

            foreach (var value in valuesToInsert)
            {
                list.Insert(value, insertAt);
            }

            var valuesToInsertCount = valuesToInsert.Length;

            Assert.AreEqual(100 + valuesToInsertCount, list.Count);

            for (var i = 0; i < valuesToInsertCount; i++)
            {
                // As values are inserted at an exact spot the end order is the reverse of the passed order.
                var expectedValue = valuesToInsert[valuesToInsertCount - i - 1];

                Assert.AreEqual(*expectedValue, list[i + insertAt]);
            }
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void InsertIntAtTest(int insertAt)
        {
            int
                testItem1 = 1557,
                testItem2 = 144,
                testItem3 = 52,
                testItem4 = 4862,
                fillValue = 2564;

            TestInsertAt(new[] { &testItem1, &testItem2, &testItem3, &testItem4 }, insertAt, &fillValue);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void InsertStringAtTest(int insertAt)
        {
            string
                testItem1 = "Lemon",
                testItem2 = "",
                testItem3 = "Some Value",
                fillValue = "Fill Value";

            TestInsertAt(new[] { &testItem1, &testItem2, &testItem3 }, insertAt, &fillValue);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void InsertReferenceTypeAtTest(int insertAt)
        {
            ListTestClass
                testItem1 = new ListTestClass { ExampleProperty = "548" },
                testItem2 = new ListTestClass { ExampleProperty = "6891" },
                testItem3 = new ListTestClass { ExampleProperty = "7" },
                testItem4 = new ListTestClass { ExampleProperty = "65" },
                testItem5 = new ListTestClass { ExampleProperty = "0" },
                fillValue = new ListTestClass();

            TestInsertAt(new[] { &testItem1, &testItem2, &testItem3, &testItem4, &testItem5 }, insertAt, &fillValue);
        }
    }
}