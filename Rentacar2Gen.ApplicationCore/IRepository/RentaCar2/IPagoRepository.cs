
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface IPagoRepository
{
void setSessionCP (GenericSessionCP session);

PagoEN ReadOIDDefault (int idReserva
                       );

void ModifyDefault (PagoEN pago);

System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size);



int NuevoPago (PagoEN pago);

void Modificar (PagoEN pago);


void EliminarPago (int idReserva
                   );
}
}
