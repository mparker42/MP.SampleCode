using MP.SampleCode.LinkedList.Tests.Models;

namespace MP.SampleCode.LinkedList.Tests
{
    [TestClass]
    public unsafe class PrintLinkedListTests
    {
        private void TestSingleValue<T>(T valueToInsert, string valueToInsertAsString)
        {
            var list = new CustomLinkedList<T>();

            list.Insert(&valueToInsert);

            Assert.AreEqual(1, list.Count);

            var output = list.Print();

            Assert.AreEqual(1, output.Count());
            Assert.AreEqual(valueToInsertAsString, output.ElementAt(0));
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

        private void TestManyValues<T>(T*[] valuesToInsert)
        {
            var list = new CustomLinkedList<T>();

            foreach (var value in valuesToInsert)
            {
                list.Insert(value);
            }

            Assert.AreEqual(valuesToInsert.Length, list.Count);

            var output = list.Print();

            for (var i = 0; i < valuesToInsert.Length; i++)
            {
                Assert.AreEqual((*valuesToInsert[i])!.ToString(), output.ElementAt(i));
            }
        }

        [TestMethod]
        public void PrintIntsFromListTest()
        {
            int
                testItem1 = 1557,
                testItem2 = 144,
                testItem3 = 52,
                testItem4 = 4862;

            TestManyValues(new[] { &testItem1, &testItem2, &testItem3, &testItem4 });
        }

        [TestMethod]
        public void PrintStringsFromListTest()
        {
            string
                testItem1 = "Lemon",
                testItem2 = "",
                testItem3 = "Some Value";

            TestManyValues(new[] { &testItem1, &testItem2, &testItem3 });
        }

        [TestMethod]
        public void PrintReferenceTypesFromListTest()
        {
            ListTestClass
                testItem1 = new ListTestClass { ExampleProperty = "548" },
                testItem2 = new ListTestClass { ExampleProperty = "6891" },
                testItem3 = new ListTestClass { ExampleProperty = "7" },
                testItem4 = new ListTestClass { ExampleProperty = "65" },
                testItem5 = new ListTestClass { ExampleProperty = "0" };

            TestManyValues(new[] { &testItem1, &testItem2, &testItem3, &testItem4, &testItem5 });
        }
    }
}