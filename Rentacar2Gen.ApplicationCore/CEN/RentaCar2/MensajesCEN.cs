

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class MensajesCEN
 *
 */
public partial class MensajesCEN
{
private IMensajesRepository _IMensajesRepository;

public MensajesCEN(IMensajesRepository _IMensajesRepository)
{
        this._IMensajesRepository = _IMensajesRepository;
}

public IMensajesRepository get_IMensajesRepository ()
{
        return this._IMensajesRepository;
}

public int NuevoMensaje (int p_usuario, int p_usuarioReceptor, string p_mensaje, Nullable<DateTime> p_fecha)
{
        MensajesEN mensajesEN = null;
        int oid;

        //Initialized MensajesEN
        mensajesEN = new MensajesEN ();

        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids idMensaje
                mensajesEN.Usuario = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN ();
                mensajesEN.Usuario.IdUsuario = p_usuario;
        }

        mensajesEN.UsuarioReceptor = p_usuarioReceptor;

        mensajesEN.Mensaje = p_mensaje;

        mensajesEN.Fecha = p_fecha;



        oid = _IMensajesRepository.NuevoMensaje (mensajesEN);
        return oid;
}

public void Modificar (int p_Mensajes_OID, int p_usuarioReceptor, string p_mensaje, Nullable<DateTime> p_fecha)
{
        MensajesEN mensajesEN = null;

        //Initialized MensajesEN
        mensajesEN = new MensajesEN ();
        mensajesEN.IdMensaje = p_Mensajes_OID;
        mensajesEN.UsuarioReceptor = p_usuarioReceptor;
        mensajesEN.Mensaje = p_mensaje;
        mensajesEN.Fecha = p_fecha;
        //Call to MensajesRepository

        _IMensajesRepository.Modificar (mensajesEN);
}

public void EliminarMensaje (int idMensaje
                             )
{
        _IMensajesRepository.EliminarMensaje (idMensaje);
}
}
}
