using Microsoft.AspNetCore.Mvc;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebRentaCar2.Models
{
    public class LoginUsuarioViewModel
    {


        [Display(Prompt = "Introduce el correo del Usuario", Description = "Correo Usuario", Name = "Correo del Usuario")]
        [Required(ErrorMessage = "El correo del Usuario es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public string Correo { get; set; }

        [Display(Prompt = "Introduce el Password del Usuario", Description = "Password del Usuario", Name = "Password")]
        [Required(ErrorMessage = "El password del Usuario es obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class UsuarioViewModel
    {
        public int idUsuario { get; set; }

        [Display(Prompt = "Introduce el correo del Usuario", Description = "Correo del Usuario", Name = "Correo")]
        [Required(ErrorMessage = "El correo del Usuario es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public string Correo { get; set; }

        [Display(Prompt = "Introduce el Password del Usuario", Description = "Password del Usuario", Name = "Password")]
        [Required(ErrorMessage = "El password del Usuario es obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Prompt = "Introduce la foto del Usuario", Description = "Foto del Usuario", Name = "Foto")]
        public string Foto { get; set; }

        [Display(Prompt = "Introduce la fecha de nacimiento del Usuario", Description = "Fecha de nacimiento", Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Prompt = "Introduce el teléfono del Usuario", Description = "Teléfono del Usuario", Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public int Telefono { get; set; }

        [Display(Prompt = "Introduce la dirección del Usuario", Description = "Dirección del Usuario", Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Prompt = "Introduce los favoritos del Usuario", Description = "Favoritos del Usuario", Name = "Favoritos")]
        public string Favoritos { get; set; }

        [Display(Prompt = "Introduce los coches propiedad del Usuario", Description = "Coches propiedad del Usuario", Name = "Coches propiedad")]
        public IList<CocheEN> CochePropiedad { get; set; }

        [Display(Prompt = "Introduce los coches favoritos del Usuario", Description = "Coches favoritos del Usuario", Name = "Coches favoritos")]
        public IList<CocheEN> CochesFavoritos { get; set; }

        [Display(Prompt = "Introduce las reservas del Usuario", Description = "Reservas del Usuario", Name = "Reservas")]
        public IList<ReservaEN> Reservas { get; set; }

        [Display(Prompt = "Introduce las notificaciones del Usuario", Description = "Notificaciones del Usuario", Name = "Notificaciones")]
        public IList<NotificacionesEN> Notificaciones { get; set; }

        [Display(Prompt = "Introduce los mensajes del Usuario", Description = "Mensajes del Usuario", Name = "Mensajes")]
        public IList<MensajesEN> Mensajes { get; set; }

        [Display(Prompt = "Introduce las valoraciones del Usuario", Description = "Valoraciones del Usuario", Name = "Valoraciones")]
        public IList<ValoracionEN> Valoracion { get; set; }
               
    }

}
