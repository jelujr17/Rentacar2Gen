
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using System.Linq;





namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
    public partial class UsuarioCEN
    {
        public bool esFavorito(int p_oid, int c_oid)
        {
            // Obtener el usuario por su ID
            UsuarioEN usuario = ObtenUsuarioId(p_oid);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            // Verificar si el usuario tiene favoritos
            if (string.IsNullOrEmpty(usuario.Favoritos))
            {
                return false;
            }

            // Dividir el string de favoritos en una lista
            var matriculasFavoritas = usuario.Favoritos.Split(',').Select(m => m.Trim()).ToList();
            string idCoche = c_oid.ToString();

            // Verificar si la matrícula está en favoritos
            if (!matriculasFavoritas.Contains(idCoche))
            {
                return false;
            }
            return true;
        }
    }
}