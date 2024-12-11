
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using System.Linq;



/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CEN.RentaCar2_Usuario_addFavorito) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
    public partial class UsuarioCEN
    {
        private readonly ICocheRepository _cocheRepository;

        public string AddFavorito(int p_oid, int c_oid)
        {
            // Obtener el usuario por su ID
            UsuarioEN usuario = ObtenUsuarioId(p_oid);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }
            // Crear instancia de CocheCEN si es necesario
            CocheCEN cocheCEN = new CocheCEN(_cocheRepository);

            // Llamar al método público GetCocheById

            // Verificar si la matrícula ya está en favoritos
            if (!string.IsNullOrEmpty(usuario.Favoritos))
            {
                // Dividir el string de favoritos en una lista
                var matriculasFavoritas = usuario.Favoritos.Split(',').Select(m => m.Trim()).ToList();
                string idCoche = "" + c_oid;
                if (matriculasFavoritas.Contains(idCoche))
                {
                    return "El coche ya está en la lista de favoritos.";
                }

                // Si no está, agregar la matrícula al string de favoritos
                matriculasFavoritas.Add(idCoche);
                usuario.Favoritos = string.Join(", ", matriculasFavoritas);
            }
            else
            {
                string idCoche = "" + c_oid;

                // Si no hay favoritos previos, asignar la matrícula directamente
                usuario.Favoritos = idCoche;
            }

            _IUsuarioRepository.ModifyDefault(usuario);
            return usuario.Favoritos;

        }
    }
}
