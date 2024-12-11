

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class NotificacionesCEN
 *
 */
public partial class NotificacionesCEN
{
private INotificacionesRepository _INotificacionesRepository;

public NotificacionesCEN(INotificacionesRepository _INotificacionesRepository)
{
        this._INotificacionesRepository = _INotificacionesRepository;
}

public INotificacionesRepository get_INotificacionesRepository ()
{
        return this._INotificacionesRepository;
}

public int NuevaNotificacion (string p_mensaje, Nullable<DateTime> p_fecha, System.Collections.Generic.IList<int> p_usuario)
{
        NotificacionesEN notificacionesEN = null;
        int oid;

        //Initialized NotificacionesEN
        notificacionesEN = new NotificacionesEN ();
        notificacionesEN.Mensaje = p_mensaje;

        notificacionesEN.Fecha = p_fecha;


        notificacionesEN.Usuario = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN>();
        if (p_usuario != null) {
                foreach (int item in p_usuario) {
                        Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN en = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN ();
                        en.IdUsuario = item;
                        notificacionesEN.Usuario.Add (en);
                }
        }

        else{
                notificacionesEN.Usuario = new System.Collections.Generic.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN>();
        }



        oid = _INotificacionesRepository.NuevaNotificacion (notificacionesEN);
        return oid;
}

public void Modificar (int p_Notificaciones_OID, string p_mensaje, Nullable<DateTime> p_fecha)
{
        NotificacionesEN notificacionesEN = null;

        //Initialized NotificacionesEN
        notificacionesEN = new NotificacionesEN ();
        notificacionesEN.IdNotificacion = p_Notificaciones_OID;
        notificacionesEN.Mensaje = p_mensaje;
        notificacionesEN.Fecha = p_fecha;
        //Call to NotificacionesRepository

        _INotificacionesRepository.Modificar (notificacionesEN);
}

public void EliminarNotificacion (int idNotificacion
                                  )
{
        _INotificacionesRepository.EliminarNotificacion (idNotificacion);
}
}
}
