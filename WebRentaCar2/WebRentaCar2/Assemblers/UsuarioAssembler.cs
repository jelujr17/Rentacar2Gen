using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentaCar2.Models;

namespace WebRentaCar2.Assemblers
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel ConvertirENToViewModel (UsuarioEN en)
        {
            UsuarioViewModel usu = new UsuarioViewModel();

           
            usu.Correo = en.Correo;


            usu.Foto = en.Foto;

            usu.FechaNacimiento = en.FechaNacimiento;

            usu.Telefono = en.Telefono;

            usu.Direccion = en.Direccion;

            usu.Favoritos = en.Favoritos;

            return usu;
        }

        public IList<UsuarioViewModel> ConvertirListENToViewModel (IList<UsuarioEN> ens)
        {
            IList<UsuarioViewModel> arts = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                arts.Add(ConvertirENToViewModel(en));
            }
            return arts;
        }


    }
}
