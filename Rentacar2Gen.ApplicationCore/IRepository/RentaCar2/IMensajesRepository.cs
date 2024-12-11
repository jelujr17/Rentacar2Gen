
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface IMensajesRepository
{
void setSessionCP (GenericSessionCP session);

MensajesEN ReadOIDDefault (int idMensaje
                           );

void ModifyDefault (MensajesEN mensajes);

System.Collections.Generic.IList<MensajesEN> ReadAllDefault (int first, int size);



int NuevoMensaje (MensajesEN mensajes);

void Modificar (MensajesEN mensajes);


void EliminarMensaje (int idMensaje
                      );
}
}
