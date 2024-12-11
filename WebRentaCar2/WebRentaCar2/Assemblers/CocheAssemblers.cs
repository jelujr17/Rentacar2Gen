using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentaCar2.Models;

namespace WebRentaCar2.Assemblers
{
    public class CocheAssembler
    {
        public CocheViewModel ConvertirENToViewModel(CocheEN en)
        {

            CocheViewModel coche = new CocheViewModel();
            coche.Id = en.Id;
            coche.Matricula = en.Matricula;
            coche.Precio = en.Precio;
            coche.Plazas = en.Plazas;
            coche.Tipo = (WebRentaCar2.Models.TipoEnum)en.Tipo; // Conversión explícita
            coche.Descripcion = en.Descripcion;
            coche.Disponible = (WebRentaCar2.Models.EstadoEnum)en.Disponible; // Conversión explícita
            coche.ImagenUrl = en.Imagenes; // Asignar a ImagenUrl en lugar de Imagen
            coche.Propietario = en.Propietario.IdUsuario; // Usar Correo en lugar de Nombre
            coche.Marca = en.Marca.IdMarca; // Obtener el nombre de la marca

            return coche;
        }


        public IList<CocheViewModel> ConvertirListENToViewModel(IList<CocheEN> ens)
        {
            IList<CocheViewModel> coches = new List<CocheViewModel>();
            foreach (CocheEN en in ens)
            {
                coches.Add(ConvertirENToViewModel(en));
            }
            return coches;
        }


    }
}