using Microsoft.AspNetCore.Http;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebRentaCar2.Models
{
    public enum TipoValoracion
    {
        coche,
        usuario
    }

    public class ValoracionViewModel
    {
        [ScaffoldColumn(false)]
        public int IdValoracion { get; set; }

        [Display(Prompt = "Introduce un comentario", Description = "Comentario de la valoración", Name = "Comentario")]
        [Required(ErrorMessage = "Debe indicar el comentario")]
        public string? Comentario { get; set; }

        [Display(Prompt = "Introduce la valoración", Description = "Valoracion", Name = "Valoracion")]
        [Required(ErrorMessage = "Debe indicar la valoración")]
        [Range(0, 5, ErrorMessage = "La valoración debe de estar entre 0 y 5")]
        public int Valoracion { get; set; }

        public UsuarioEN Usuario { get; set; }
        public TipoValoracion Tipo { get; set; }

        public int IdDestinatario { get; set; }
    }
}
