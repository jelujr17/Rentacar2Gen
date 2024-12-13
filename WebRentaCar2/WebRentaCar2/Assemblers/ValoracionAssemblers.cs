using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentaCar2.Models;

namespace WebRentaCar2.Assemblers
{
    public class ValoracionAssembler
    {
        public ValoracionViewModel ConvertirENToViewModel(ValoracionEN en)
        {

            ValoracionViewModel valoracion = new ValoracionViewModel();
            valoracion.IdValoracion = en.IdValoracion;
            valoracion.Comentario = en.Comentario;
            valoracion.Valoracion = en.Valoracion;
            valoracion.Tipo = (WebRentaCar2.Models.TipoValoracion)en.TipoValoracion; // Conversión explícita
            valoracion.IdDestinatario = en.IdDestinatario;

            return valoracion;
        }


        public IList<ValoracionViewModel> ConvertirListENToViewModel(IList<ValoracionEN> ens)
        {
            IList<ValoracionViewModel> valoraciones = new List<ValoracionViewModel>();
            foreach (ValoracionEN en in ens)
            {
                valoraciones.Add(ConvertirENToViewModel(en));
            }
            return valoraciones;
        }


    }
}