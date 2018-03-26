using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Mappers;

namespace PlaygroundClasses
{
    public class AutoMapDemo
    {
        public static void Demo()
        {
            Book book = new Book()
            {
                Title = "Under the Sea",
                Author = new Author { Name = "Jules" }
            };
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Book, BookVM>()
                .ForMember(dest => dest.Author, opts =>
                {
                    opts.MapFrom(src => src.Author.Name);
                })
                .ForMember(dest => dest.DogName, opts => opts.MapFrom(src => src.Author.PetDog.Name))
                .ForMember(dest => dest.AuthorAge, opts => { opts.MapFrom(src => src.Author.Age); })
                .ForAllMembers(opts => opts.NullSubstitute("")));
            BookVM bvm = AutoMapper.Mapper.Map<BookVM>(book);

            Book book2 = new Book
            {
                Title = "The Earth",
                Author = null
            };

            BookVM bvm2 = AutoMapper.Mapper.Map<BookVM>(book2);
        }
    }
}
