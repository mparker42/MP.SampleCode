using MP.SampleCode.LinkedList.Tests.Models;

namespace MP.SampleCode.LinkedList.Tests
{
    [TestClass]
    public class DeleteItemToLinkedListTests
    {
        private void TestSingleValue<T>(T valueToInsert)
        {
            var list = new CustomLinkedList<T>();

            list.Insert(valueToInsert);

            Assert.AreEqual(1, list.Count());

            list.Delete(0);

            Assert.AreEqual(0, list.Count());
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
                list.Insert(value);
            }

            Assert.AreEqual(valuesToInsert.Count(), list.Count());

            for (var i = 0; i < valuesToInsert.Count(); i++)
            {
                list.Delete(0);
            }

            Assert.AreEqual(0, list.Count());
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

        private void TestDeleteAt<T>(IEnumerable<T> valuesToInsert, int deleteAt, T fillValue)
        {
            var list = new CustomLinkedList<T>();

            for (var i = 0; i < 100; i++)
            {
                list.Insert(fillValue, 0);
            }

            foreach (var value in valuesToInsert)
            {
                list.Insert(value, deleteAt);
            }

            var valuesToInsertCount = valuesToInsert.Count();

            for (var i = 0; i < valuesToInsertCount; i++)
            {
                list.Delete(deleteAt);

                var expectedItemIndex = valuesToInsertCount - i - 1;

                Assert.AreEqual(100 + expectedItemIndex, list.Count());

                // As values are inserted at an exact spot the end order is the reverse of the passed order.
                var expectedValue = valuesToInsert.ElementAt(expectedItemIndex);

                Assert.AreEqual(expectedValue, list[deleteAt]);
            }
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void InsertIntAtTest(int insertAt)
        {
            TestDeleteAt(new[] { 1557, 144, 52, 4862 }, insertAt, 2564);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void InsertStringAtTest(int insertAt)
        {
            TestDeleteAt(new[] { "Lemon", "", "Some Value" }, insertAt, "Fill Value");
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void InsertReferenceTypeAtTest(int insertAt)
        {
            TestDeleteAt
            (
                new[]
                {
                    new ListTestClass { ExampleProperty = "548" },
                    new ListTestClass { ExampleProperty = "6891" },
                    new ListTestClass { ExampleProperty = "7" },
                    new ListTestClass { ExampleProperty = "65" },
                    new ListTestClass { ExampleProperty = "0" }
                },
                insertAt,
                new ListTestClass()
            );
        }
    }
}