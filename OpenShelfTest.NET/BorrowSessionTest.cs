using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using OpenShelf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OpenShelfTest.NET
{
    [TestClass()]
    public class BorrowSessionTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for Decode
        ///</summary>
        [TestMethod()]
        public void DecodeThoughtWorker()
        {
            BorrowSession target = new BorrowSession();
            int empId = 12990;
            string Decoded = "{\"empId\":12990.0,\"Name\":\"Arvind\",\"Role\":\"Developer\",\"borrow_details\":[]}";
            target.Decode(Decoded);
            Assert.AreEqual(empId, target._ChosenThoughtWorker.empId);


//            ThoughtWorker thoughtWorker = new ThoughtWorker();
//            thoughtWorker.empId = 12990;
//            thoughtWorker.Name = "Arvind";
//            thoughtWorker.Role = "Developer";
//            Trace.WriteLine("This is just a test");
//            Trace.WriteLine(JsonConvert.SerializeObject(thoughtWorker));
        }

        [TestMethod()]
        public void DecodeBookCopy()
        {
            BorrowSession target = new BorrowSession();
            string Decoded = "{\"CopyId\":1001.0,\"BookId\":3001.0,\"ThoughtWorkerId\":null,\"DateOfBorrow\":\"\\/Date(1312866974950-0700)\\/\",\"AvailabilityStatus\":null,\"BookObj\":null,\"ThoughtWorker\":null}";
            target.Decode(Decoded);
            Assert.AreEqual(3001, target._ChosenBookCopy.BookId);
            Assert.AreEqual(1001, target._ChosenBookCopy.CopyId);
        }

        [TestMethod()]
        public void ShouldChangeTheAvailabilityStatusToReserved()
        {
            BorrowSession target = new BorrowSession();
            target.Decode("{\"CopyId\":1001.0,\"BookId\":3001.0,\"ThoughtWorkerId\":null,\"DateOfBorrow\":\"\\/Date(1312866974950-0700)\\/\",\"AvailabilityStatus\":null,\"BookObj\":null,\"ThoughtWorker\":null}");
            target.Decode("{\"empId\":12990.0,\"Name\":\"Arvind\",\"Role\":\"Developer\",\"borrow_details\":[]}");
            target.SaveSession();
            var bookCopyId = target._ChosenBookCopy.CopyId;
            BookCopy bookCopy = new OpenShelfContainer().BookCopies.Find(bookCopyId);
            Assert.AreEqual(AvailabilityStatus.RESERVED, bookCopy.AvailabilityStatus);
            Assert.AreEqual(12990, bookCopy.ThoughtWorker.empId);
        }

        [TestMethod()]
        public void ShouldReturnTheReservedBook()
        {
            BorrowSession target = new BorrowSession();
            target.Decode("{\"CopyId\":1001.0,\"BookId\":3001.0,\"ThoughtWorkerId\":null,\"DateOfBorrow\":\"\\/Date(1312866974950-0700)\\/\",\"AvailabilityStatus\":null,\"BookObj\":null,\"ThoughtWorker\":null}");
            target.Decode("{\"empId\":12990.0,\"Name\":\"Arvind\",\"Role\":\"Developer\",\"borrow_details\":[]}");
            target.SaveSession();
            var bookCopyId = target._ChosenBookCopy.CopyId;
            BookCopy bookCopy = new OpenShelfContainer().BookCopies.Find(bookCopyId);
            Assert.AreEqual(AvailabilityStatus.AVAILABLE, bookCopy.AvailabilityStatus);
            Assert.AreEqual(101010, bookCopy.ThoughtWorker.empId);
        }
    }
}
