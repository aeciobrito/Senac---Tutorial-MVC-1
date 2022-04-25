using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Models;
using System;
using System.Linq;

namespace MvcMovie.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                if (context.Filme.Any())
                    return;   

                context.Filme.AddRange(
                    new Filme
                    {
                        Titulo = "When Harry Met Sally",
                        DataLancamento = DateTime.Parse("1989-2-12"),
                        Genero = "Romantic Comedy",
                        Preco = 7.99M
                    },

                    new Filme
                    {
                        Titulo = "Ghostbusters ",
                        DataLancamento = DateTime.Parse("1984-3-13"),
                        Genero = "Comedy",
                        Preco = 8.99M
                    },

                    new Filme
                    {
                        Titulo = "Ghostbusters 2",
                        DataLancamento = DateTime.Parse("1986-2-23"),
                        Genero = "Comedy",
                        Preco = 9.99M
                    },

                    new Filme
                    {
                        Titulo = "Rio Bravo",
                        DataLancamento = DateTime.Parse("1959-4-15"),
                        Genero = "Western",
                        Preco = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
