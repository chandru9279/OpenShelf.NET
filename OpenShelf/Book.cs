//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenShelf
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.borrow_details = new HashSet<BorrowDetails>();
        }
    
        public decimal bookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public long NumberOfCopies { get; set; }
        public string Authors { get; set; }
    
        public virtual ICollection<BorrowDetails> borrow_details { get; set; }
    }
}