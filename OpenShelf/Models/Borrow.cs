using System;

namespace OpenShelf.Models
{
    internal class Borrow
    {
        public Book Book { get; set; }
        public Employee Employee { get; set; }
        public DateTime Timestamp { get; set; }
    }
}