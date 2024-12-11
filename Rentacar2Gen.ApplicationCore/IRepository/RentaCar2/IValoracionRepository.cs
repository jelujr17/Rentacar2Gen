
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface IValoracionRepository
{
void setSessionCP (GenericSessionCP session);

ValoracionEN ReadOIDDefault (int idValoracion
                             );

void ModifyDefault (ValoracionEN valoracion);

System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size);



int NuevaValoracion (ValoracionEN valoracion);

void Modificar (ValoracionEN valoracion);


void EliminarValoracion (int idValoracion
                         );


ValoracionEN ObtenValoracionId (int idValoracion
                                );


System.Collections.Generic.IList<ValoracionEN> ObtenerValoraciones (int first, int size);
}
}
