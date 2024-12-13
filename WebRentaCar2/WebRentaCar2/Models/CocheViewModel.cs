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

    //Ejemplo Enumerador
    public enum EstadoEnum
    {
        disponible,
        reservado
    }

    public enum TipoEnum
    {
        turismo, furgoneta, suv, deportivo
    }

    public class CocheViewModel
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Introduce la matrícula del coche", Description = "Matrícula del coche", Name = "Matrícula")]
        [Required(ErrorMessage = "Debe indicar la matrícula del coche")]
        [StringLength(10, ErrorMessage = "La matrícula no puede tener más de 10 caracteres")]
        public string Matricula { get; set; }

        [Display(Prompt = "Introduce el precio del coche por día", Description = "Precio del coche", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar el precio del coche")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(0, 10000, ErrorMessage = "El precio debe ser mayor o igual a 0 y menor que 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Número de plazas", Description = "Cantidad de plazas del coche", Name = "Plazas")]
        [Required(ErrorMessage = "Debe indicar la cantidad de plazas del coche")]
        [Range(2, 8, ErrorMessage = "El número de plazas debe estar entre 2 y 8")]
        public int Plazas { get; set; }

        [Display(Prompt = "Selecciona el tipo de coche", Description = "Tipo de coche", Name = "Tipo")]
        [Required(ErrorMessage = "Debe seleccionar un tipo para el coche")]
        public TipoEnum Tipo { get; set; }

        [Display(Prompt = "Describe el coche", Description = "Descripción del coche", Name = "Descripción")]
        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Selecciona el estado del coche", Description = "Estado del coche", Name = "Estado")]
        [Required(ErrorMessage = "Debe seleccionar el estado del coche")]
        public EstadoEnum Disponible { get; set; }

        [Display(Prompt = "Selecciona imágenes del coche", Description = "Imágenes del coche", Name = "Imágenes")]
        public IFormFile Imagen { get; set; }

        [ScaffoldColumn(false)]
        public string ImagenUrl { get; set; }

        [Display(Prompt = "Propietario del coche", Description = "Propietario del coche", Name = "Propietario")]
        public int Propietario { get; set; }

        [Display(Prompt = "Marca del coche", Description = "Marca del coche", Name = "Marca")]
        [Required(ErrorMessage = "Debe seleccionar la marca del coche")]
        public int Marca { get; set; }

        [Display(Prompt = "Reservado", Description = "Estado de la reserva activa", Name = "Reserva activa")]
        public bool ReservaActiva { get; set; }

        // Lista de usuarios que marcaron el coche como favorito
        [ScaffoldColumn(false)]
        public List<string> UsuariosFavoritos { get; set; } = new List<string>();

        public int valoracion { get; set; }

        public bool EsUsuarioFavorito(string correoUsuario)
        {
            
            // Verificar si la lista de usuarios favoritos no es nula
            if (UsuariosFavoritos == null)
            {
                return false;
            }

            // Verificar si el coche con el ID especificado está en la lista de coches favoritos
            for (int i = 0; i < UsuariosFavoritos.Count; i++)
            {
                if (UsuariosFavoritos[i] == correoUsuario)
                {
                    return true;

                }
            }
            return false;
        }

        public bool ToggleFavorito(string correoUsuario)
        {
            // Verificar si la lista de usuarios favoritos no es nula
            if (UsuariosFavoritos == null)
            {
                return false;
            }

            bool aux = EsUsuarioFavorito(correoUsuario);

            if (aux)
            {
                UsuariosFavoritos.Add(correoUsuario);
            }
            else
            {
                UsuariosFavoritos.Remove(correoUsuario);
            }
            return false;
        }
    }
}