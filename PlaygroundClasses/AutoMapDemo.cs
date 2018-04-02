using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

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

        public static void DemoProjectTo()
        {
            Mapper.Initialize(cfg =>
            {
                string placeholder = null;
                cfg.CreateMap<Book, BookVM>()
                .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.DogName, opts => opts.MapFrom(src => src.Author.PetDog.Name))
                .ForMember(dest => dest.AuthorAge, opts => opts.MapFrom(src => src.Author.Age))
                .ForMember(dest => dest.Afterwards, opts => opts.MapFrom(src => string.Format("The Author {0} says,'{1}'",src.Author.Name,placeholder)));
            });
            Author a1 = new Author { Name = "Alfred", Age = 63, PetDog = new PetDog { Name = "Birdman" } };
            Author a2 = new Author { Name = "Roger", Age = 42, PetDog = new PetDog { Name = "Death Becometh" } };
            var books = new Book[] {
                new Book { Title = "Sand", Author = a1 },
                new Book { Title = "The Ocean",Author = a1 },
                new Book { Title = "1001 Ways to die before you die",Author = a2},
                new Book { Title = "Household Appliance Sex Scandals",Author = a2},
                new Book { Title = "The Book of Nothing"},
                new Book { Title = "The 1967 Geese War",Author  = a1}
            }.AsQueryable();

            var booksFinal = books.Where(b => b.Author != null).ProjectTo<BookVM>(new {placeholder = "It is Written" }).ToList();
            //var booksFinal2 = books.Where(b => b.Author != null).ProjectTo<BookVM>(.ToList();
        }

        public static void DemoMapToSelf()
        {
            Mapper.Initialize(cfg =>
           {
           });

            var b1 = new BigHead
            {
                NumberOfBrains = 3,
                DoBrainsGetAlong = false,
            };

            var b2 = Mapper.Map<BigHead>(b1);

            var b3 = new BigHead
            {
                Volume = 5.4,
                CodeName = "Dan"
            };

            var b4 = Mapper.Map<BigHead, BigHead>(b1, b3);

        }
    }

    
}
