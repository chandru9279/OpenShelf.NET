using System;

namespace OpenShelf.Models
{
    internal class Employee
    {
        public String Id  { get; set; }
        public String Name  { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", Id, Name);
        }
    }
}