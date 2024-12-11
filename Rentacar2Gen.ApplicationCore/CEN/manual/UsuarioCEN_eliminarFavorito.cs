
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using System.Linq;



/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CEN.RentaCar2_Usuario_eliminarFavorito) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
    public partial class UsuarioCEN
    {
        public string EliminarFavorito(int p_oid, int c_oid)
        {
            // Obtener el usuario por su ID
            UsuarioEN usuario = ObtenUsuarioId(p_oid);

            if (usuario == null)
            {
                throw new Exception("Usuario no encosadadantrado.");
            }

            // Verificar si el usuario tiene favoritos
            if (string.IsNullOrEmpty(usuario.Favoritos))
            {
                return "El usuario no tiene coches en su lista de favoritos.";
            }

            // Dividir el string de favoritos en una lista
            var matriculasFavoritas = usuario.Favoritos.Split(',').Select(m => m.Trim()).ToList();
            string idCoche = c_oid.ToString();

            // Verificar si la matrícula está en favoritos
            if (!matriculasFavoritas.Contains(idCoche))
            {
                return "El coche no está en la lista de favoritos.";
            }

            // Eliminar la matrícula de la lista de favoritos
            matriculasFavoritas.Remove(idCoche);

            // Actualizar el string de favoritos
            usuario.Favoritos = string.Join(", ", matriculasFavoritas);

            _IUsuarioRepository.ModifyDefault(usuario);

            return usuario.Favoritos;
        }
    }
}