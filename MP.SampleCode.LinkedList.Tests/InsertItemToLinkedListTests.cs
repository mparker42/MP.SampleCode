using MP.SampleCode.LinkedList.Tests.Models;
using Newtonsoft.Json.Linq;

namespace MP.SampleCode.LinkedList.Tests
{
    [TestClass]
    public class InsertItemToLinkedListTests
    {
        private void TestSingleValue<T>(T valueToInsert)
        {
            var list = new CustomLinkedList<T>();

            list.Insert(valueToInsert);

            Assert.AreEqual(1, list.Count());
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
                Assert.AreEqual(valuesToInsert.ElementAt(i), list[i]);
            }
        }

        [TestMethod]
        public void InsertIntsToListTest()
        {
            TestManyValues(new[] { 1557, 144, 52, 4862 });
        }

        [TestMethod]
        public void InsertStringsToListTest()
        {
            TestManyValues(new[] { "Lemon", "", "Some Value" });
        }

        [TestMethod]
        public void InsertReferenceTypesToListTest()
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

        private void TestInsertAt<T>(IEnumerable<T> valuesToInsert, int insertAt, T fillValue)
        {
            var list = new CustomLinkedList<T>();

            for(var i = 0;i < 100;i++)
            {
                list.Insert(fillValue, 0);
            }

            Assert.AreEqual(100, list.Count());

            foreach (var value in valuesToInsert)
            {
                list.Insert(value, insertAt);
            }

            var valuesToInsertCount = valuesToInsert.Count();

            Assert.AreEqual(100 + valuesToInsertCount, list.Count());

            for (var i = 0; i < valuesToInsertCount; i++)
            {
                // As values are inserted at an exact spot the end order is the reverse of the passed order.
                var expectedValue = valuesToInsert.ElementAt(valuesToInsertCount - i - 1);

                Assert.AreEqual(expectedValue, list[i + insertAt]);
            }
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void InsertIntAtTest(int insertAt)
        {
            TestInsertAt(new[] { 1557, 144, 52, 4862 }, insertAt, 2564);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void InsertStringAtTest(int insertAt)
        {
            TestInsertAt(new[] { "Lemon", "", "Some Value" }, insertAt, "Fill Value");
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(54)]
        public void InsertReferenceTypeAtTest(int insertAt)
        {
            TestInsertAt
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