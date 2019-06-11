using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Business
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string  Phone { get; set; }
        public string WebSite { get; set; }
        public Company Company { get; set; }
    }
}
