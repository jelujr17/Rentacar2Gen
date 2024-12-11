
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CEN.RentaCar2_Coche_reservarCoche) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
public partial class CocheCEN
{
public void ReservarCoche (int p_id)
{
            /*PROTECTED REGION ID(Rentacar2Gen.ApplicationCore.CEN.RentaCar2_Coche_desreservarCoche_customized) ENABLED START*/


            CocheEN cocheEN = null;

            // Obtener el coche con el id proporcionado
            cocheEN = _ICocheRepository.ObtenCocheId(p_id);

            if (cocheEN == null)
            {
                throw new Exception("Coche no encontrado");
            }

            // Comprobar el estado del coche
            if (cocheEN.Disponible == Enumerated.RentaCar2.EstadoEnum.disponible)
            {
                cocheEN.Disponible = Enumerated.RentaCar2.EstadoEnum.reservado;

                _ICocheRepository.ModifyDefault(cocheEN);
            }
            else
            {
                throw new Exception("El coche ya esta reservado.");
            }

            /*PROTECTED REGION END*/
        }
    }
}
