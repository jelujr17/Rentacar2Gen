
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface IReservaRepository
{
void setSessionCP (GenericSessionCP session);

ReservaEN ReadOIDDefault (int idReserva
                          );

void ModifyDefault (ReservaEN reserva);

System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size);



int NuevaReserva (ReservaEN reserva);

void Modificar (ReservaEN reserva);


void EliminarReserva (int idReserva
                      );


ReservaEN ObtenReservaId (int idReserva
                          );


System.Collections.Generic.IList<ReservaEN> ObtenerReservas (int first, int size);
}
}
