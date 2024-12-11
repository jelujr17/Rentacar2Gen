
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CEN.RentaCar2_Coche_verDisponibles) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
public partial class CocheCEN
{
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> VerDisponibles ()
{
        /*PROTECTED REGION ID(Rentacar2Gen.ApplicationCore.CEN.RentaCar2_Coche_verDisponibles) ENABLED START*/
        // Obtener la lista completa de coches (ajustar el tamaño si es necesario)
        IList<CocheEN> coches = ObtenerCoches(0, int.MaxValue);

        // Filtrar los coches según el estado de disponibilidad
        List<CocheEN> cochesDisponibles = new List<CocheEN>();

        foreach (var coche in coches)
        {
            if (coche.Disponible == Enumerated.RentaCar2.EstadoEnum.disponible) // Verifica que el estado coincide
            {
                cochesDisponibles.Add(coche);
            }
        }
        return cochesDisponibles;

        /*PROTECTED REGION END*/
}
}
}
