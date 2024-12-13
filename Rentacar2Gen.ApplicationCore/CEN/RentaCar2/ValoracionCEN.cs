

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionRepository _IValoracionRepository;

public ValoracionCEN(IValoracionRepository _IValoracionRepository)
{
        this._IValoracionRepository = _IValoracionRepository;
}

public IValoracionRepository get_IValoracionRepository ()
{
        return this._IValoracionRepository;
}

public int NuevaValoracion (string p_comentario, int p_valoracion, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum p_tipoValoracion, int p_usuario, int p_idDestinatario)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Comentario = p_comentario;

        valoracionEN.Valoracion = p_valoracion;

        valoracionEN.TipoValoracion = p_tipoValoracion;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids idValoracion
                valoracionEN.Usuario = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN ();
                valoracionEN.Usuario.IdUsuario = p_usuario;
        }

        valoracionEN.IdDestinatario = p_idDestinatario;



        oid = _IValoracionRepository.NuevaValoracion (valoracionEN);
        return oid;
}

public void Modificar (int p_Valoracion_OID, string p_comentario, int p_valoracion, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum p_tipoValoracion, int p_idDestinatario)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.IdValoracion = p_Valoracion_OID;
        valoracionEN.Comentario = p_comentario;
        valoracionEN.Valoracion = p_valoracion;
        valoracionEN.TipoValoracion = p_tipoValoracion;
        valoracionEN.IdDestinatario = p_idDestinatario;
        //Call to ValoracionRepository

        _IValoracionRepository.Modificar (valoracionEN);
}

public void EliminarValoracion (int idValoracion
                                )
{
        _IValoracionRepository.EliminarValoracion (idValoracion);
}

public ValoracionEN ObtenValoracionId (int idValoracion
                                       )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionRepository.ObtenValoracionId (idValoracion);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ObtenerValoraciones (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionRepository.ObtenerValoraciones (first, size);
        return list;
}

        public System.Collections.Generic.IList<ValoracionEN> ObtenerValoracionesCoche(int id)
        {
            System.Collections.Generic.IList<ValoracionEN> list = null;

            list = _IValoracionRepository.ObtenerValoracionesCoche(id);
            return list;
        }
        
    }
}
