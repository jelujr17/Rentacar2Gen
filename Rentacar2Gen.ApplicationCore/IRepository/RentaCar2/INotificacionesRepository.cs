
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface INotificacionesRepository
{
void setSessionCP (GenericSessionCP session);

NotificacionesEN ReadOIDDefault (int idNotificacion
                                 );

void ModifyDefault (NotificacionesEN notificaciones);

System.Collections.Generic.IList<NotificacionesEN> ReadAllDefault (int first, int size);



int NuevaNotificacion (NotificacionesEN notificaciones);

void Modificar (NotificacionesEN notificaciones);


void EliminarNotificacion (int idNotificacion
                           );
}
}
