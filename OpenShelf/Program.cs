using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace OpenShelf
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//            var openShelfContainer = new OpenShelfContainer();
//            int DummyUser = 101010;
//            ThoughtWorker dummyThoughtWorker = openShelfContainer.ThoughtWorkers.Find(DummyUser);
//            IQueryable<Book> books = openShelfContainer.Books.Where(b => (b.NumberOfCopies == 3));
//            foreach (Book selectedBook in books)
//            {
//                openShelfContainer.BookCopies.Add(new BorrowDetails{BookObj = selectedBook, DateOfBorrow = DateTime.Now, CopyOwner = dummyThoughtWorker});
//            }
//            openShelfContainer.SaveChanges();
            Application.Run(new OpenShelf());
        }
    }
}
