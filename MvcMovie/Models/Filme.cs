using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        public string Genero { get; set; }
        public decimal Preco { get; set; }
    }
}
