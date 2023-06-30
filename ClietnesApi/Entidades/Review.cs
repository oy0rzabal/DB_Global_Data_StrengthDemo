﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ClientesAPI.Entidades
{
    public class Review
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        [Range(1,5)]
        public int Puntuacion { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set;}
        public string UsuarioId { get; set; }
        public IdentityUser Usuario { get; set; }
    }
}
