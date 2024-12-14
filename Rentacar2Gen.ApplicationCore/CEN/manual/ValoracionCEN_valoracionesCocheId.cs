
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CEN.RentaCar2_Valoracion_valoracionesCocheId) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
public partial class ValoracionCEN
{
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ValoracionEN> ValoracionesCocheId (int c_id)
{
            /*PROTECTED REGION ID(Rentacar2Gen.ApplicationCore.CEN.RentaCar2_Valoracion_valoracionesCocheId) ENABLED START*/


            IList<ValoracionEN> valoracionesEN = ObtenerValoraciones(0, -1);
            IList<ValoracionEN> valoracionesCoche = new List<ValoracionEN>();

            foreach (var valoracion in valoracionesEN)
            {
                if (valoracion.IdDestinatario == c_id && valoracion.TipoValoracion == Enumerated.RentaCar2.TipoValoracionEnum.coche) // Verifica que el estado coincide
                {
                    valoracionesCoche.Add(valoracion);
                }
            }
            return valoracionesCoche;
        }

        /*PROTECTED REGION END*/
    }
}
