using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCoreCF.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
