using System;

namespace OpenShelf.Models
{
    class Book
    {
        public String Title { get; set; }
        public String Isbn { get; set; }
        public String CopyId { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0}, Isbn: {1}, CopyId: {2}", Title, Isbn, CopyId);
        }
    }
}

