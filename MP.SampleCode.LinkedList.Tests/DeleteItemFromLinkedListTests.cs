using MP.SampleCode.LinkedList.Tests.Models;

namespace MP.SampleCode.LinkedList.Tests
{
    [TestClass]
    public unsafe class DeleteItemFromLinkedListTests
    {
        private void TestSingleValue<T>(T valueToInsert)
        {
            var list = new CustomLinkedList<T>();

            list.Insert(&valueToInsert);

            Assert.AreEqual(1, list.Count);

            list.Delete(0);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void DeleteIntFromListTest()
        {
            TestSingleValue(144);
        }

        [TestMethod]
        public void DeleteStringFromListTest()
        {
            TestSingleValue("Some Value");
        }

        [TestMethod]
        public void DeleteReferenceTypeFromListTest()
        {
            TestSingleValue(new ListTestClass { ExampleProperty = "1332" });
        }

        private void TestManyValues<T>(IEnumerable<T> valuesToInsert)
        {
            var list = new CustomLinkedList<T>();

            foreach (var value in valuesToInsert)
            {
                list.Insert(&value);
            }

            Assert.AreEqual(valuesToInsert.Count(), list.Count);

            for (var i = 0; i < valuesToInsert.Count(); i++)
            {
                list.Delete(0);
            }

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void DeleteIntsFromListTest()
        {
            TestManyValues(new[] { 1557, 144, 52, 4862 });
        }

        [TestMethod]
        public void DeleteStringsFromListTest()
        {
            TestManyValues(new[] { "Lemon", "", "Some Value" });
        }

        [TestMethod]
        public void DeleteReferenceTypesFromListTest()
        {
            TestManyValues
            (
                new[]
                {
                    new ListTestClass { ExampleProperty = "548" },
                    new ListTestClass { ExampleProperty = "6891" },
                    new ListTestClass { ExampleProperty = "7" },
                    new ListTestClass { ExampleProperty = "65" },
                    new ListTestClass { ExampleProperty = "0" }
                }
            );
        }

        private void TestDeleteAt<T>(T*[] valuesToInsert, int deleteAt, T* fillValue)
        {
            var list = new CustomLinkedList<T>();

            for (var i = 0; i < 100; i++)
            {
                list.Insert(fillValue, 0);
            }

            var valuesToInsertCount = valuesToInsert.Length;

            for (var i = 0; i < valuesToInsertCount; i++)
            {
                list.Insert(valuesToInsert[i], deleteAt);
            }

            for (var i = 0; i < valuesToInsertCount; i++)
            {
                list.Delete(deleteAt);

                Assert.AreEqual(100 + valuesToInsertCount - i - 1, list.Count);

                if (i + 1 < valuesToInsertCount)
                {
                    var expectedValue = valuesToInsert[valuesToInsertCount - i - 2];

                    Assert.AreEqual(*expectedValue, list[deleteAt]);
                }
            }
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void DeleteIntAtTest(int insertAt)
        {
            int
                testItem1 = 1557,
                testItem2 = 144,
                testItem3 = 52,
                testItem4 = 4862,
                fillValue = 2564;

            TestDeleteAt(new[] { &testItem1, &testItem2, &testItem3, &testItem4 }, insertAt, &fillValue);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void DeleteStringAtTest(int insertAt)
        {
            string
                testItem1 = "Lemon",
                testItem2 = "",
                testItem3 = "Some Value",
                fillValue = "Fill Value";

            TestDeleteAt(new[] { &testItem1, &testItem2, &testItem3 }, insertAt, &fillValue);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void DeleteReferenceTypeAtTest(int insertAt)
        {
            ListTestClass
                testItem1 = new ListTestClass { ExampleProperty = "548" },
                testItem2 = new ListTestClass { ExampleProperty = "6891" },
                testItem3 = new ListTestClass { ExampleProperty = "7" },
                testItem4 = new ListTestClass { ExampleProperty = "65" },
                testItem5 = new ListTestClass { ExampleProperty = "0" },
                fillValue = new ListTestClass();


            TestDeleteAt(new[] { &testItem1, &testItem2, &testItem3, &testItem4, &testItem5 }, insertAt, &fillValue);
        }
    }
}