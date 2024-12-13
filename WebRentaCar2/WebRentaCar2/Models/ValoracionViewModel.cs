using Microsoft.AspNetCore.Http;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        [Range(0, 5, ErrorMessage = "La valoracion debe de estar ente 0 y 5")]
        public int Valoracion { get; set; }

        [Display(Prompt = "Número de plazas", Description = "Cantidad de plazas del coche", Name = "Plazas")]
        [Required(ErrorMessage = "Debe indicar la cantidad de plazas del coche")]
        [Range(2, 8, ErrorMessage = "El número de plazas debe estar entre 2 y 8")]
        public int Plazas { get; set; }


        [Display(Prompt = "Describe el coche", Description = "Descripción del coche", Name = "Descripción")]
        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string? Descripcion { get; set; }

   
        public TipoValoracion Tipo{ get; set; }


        public int IdDestinatario { get; set; }

    }
}