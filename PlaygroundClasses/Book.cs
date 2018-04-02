using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public class PetDog
    {
        public string Name { get; set; }
    }

    public class Author
    {
        public PetDog PetDog { get; set; }
        public string Name { get; set; }

        public int? Age { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
    }

    public class BookVM
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string DogName { get; set; }
        public int? AuthorAge { get; set; }
        public string Afterwards { get; set; }
    }
}
