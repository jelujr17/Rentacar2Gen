

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class MarcaCEN
 *
 */
public partial class MarcaCEN
{
private IMarcaRepository _IMarcaRepository;

public MarcaCEN(IMarcaRepository _IMarcaRepository)
{
        this._IMarcaRepository = _IMarcaRepository;
}

public IMarcaRepository get_IMarcaRepository ()
{
        return this._IMarcaRepository;
}

public int NuevaMarca (string p_nombre)
{
        MarcaEN marcaEN = null;
        int oid;

        //Initialized MarcaEN
        marcaEN = new MarcaEN ();
        marcaEN.Nombre = p_nombre;



        oid = _IMarcaRepository.NuevaMarca (marcaEN);
        return oid;
}

public void Modificar (int p_Marca_OID, string p_nombre)
{
        MarcaEN marcaEN = null;

        //Initialized MarcaEN
        marcaEN = new MarcaEN ();
        marcaEN.IdMarca = p_Marca_OID;
        marcaEN.Nombre = p_nombre;
        //Call to MarcaRepository

        _IMarcaRepository.Modificar (marcaEN);
}

public void EliminarMarca (int idMarca
                           )
{
        _IMarcaRepository.EliminarMarca (idMarca);
}
}
}
