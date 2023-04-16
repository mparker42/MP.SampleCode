using MP.SampleCode.LinkedList.Tests.Models;

namespace MP.SampleCode.LinkedList.Tests
{
    [TestClass]
    public class PrintLinkedListTests
    {
        private void TestSingleValue<T>(T valueToInsert, string valueToInsertAsString)
        {
            var list = new CustomLinkedList<T>();

            list.Insert(valueToInsert);

            Assert.AreEqual(1, list.Count());

            var output = list.Print(0);

            Assert.AreEqual(1, output.Count());
            Assert.AreEqual(valueToInsertAsString, output[0]);
        }

        [TestMethod]
        public void PrintIntFromListTest()
        {
            TestSingleValue(144, "144");
        }

        [TestMethod]
        public void PrintStringFromListTest()
        {
            TestSingleValue("Some Value", "Some Value");
        }

        [TestMethod]
        public void PrintReferenceTypeFromListTest()
        {
            TestSingleValue(new ListTestClass { ExampleProperty = "1332" }, "1332");
        }

        private void TestManyValues<T>(IEnumerable<T> valuesToInsert)
        {
            var list = new CustomLinkedList<T>();

            foreach (var value in valuesToInsert)
            {
                list.Insert(value);
            }

            Assert.AreEqual(valuesToInsert.Count(), list.Count());

            var output = list.Print(0);

            for (var i = 0; i < valuesToInsert.Count(); i++)
            {
                Assert.AreEqual(valuesToInsert.ElementAt(i).ToString(), output[0]);
            }
        }

        [TestMethod]
        public void PrintIntsFromListTest()
        {
            TestManyValues(new[] { 1557, 144, 52, 4862 });
        }

        [TestMethod]
        public void PrintStringsFromListTest()
        {
            TestManyValues(new[] { "Lemon", "", "Some Value" });
        }

        [TestMethod]
        public void PrintReferenceTypesFromListTest()
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
    }
}