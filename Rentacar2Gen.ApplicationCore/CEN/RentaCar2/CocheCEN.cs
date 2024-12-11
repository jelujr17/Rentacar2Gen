

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class CocheCEN
 *
 */
public partial class CocheCEN
{
private ICocheRepository _ICocheRepository;

public CocheCEN(ICocheRepository _ICocheRepository)
{
        this._ICocheRepository = _ICocheRepository;
}

public ICocheRepository get_ICocheRepository ()
{
        return this._ICocheRepository;
}

public void Modificar (int p_Coche_OID, string p_matricula, string p_imagenes, double p_precio, int p_plazas, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum p_tipo, string p_descripcion, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoEnum p_disponible)
{
        CocheEN cocheEN = null;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.Id = p_Coche_OID;
        cocheEN.Matricula = p_matricula;
        cocheEN.Imagenes = p_imagenes;
        cocheEN.Precio = p_precio;
        cocheEN.Plazas = p_plazas;
        cocheEN.Tipo = p_tipo;
        cocheEN.Descripcion = p_descripcion;
        cocheEN.Disponible = p_disponible;
        //Call to CocheRepository

        _ICocheRepository.Modificar (cocheEN);
}

public void EliminarCoche (int id
                           )
{
        _ICocheRepository.EliminarCoche (id);
}

public System.Collections.Generic.IList<CocheEN> ObtenerCoches (int first, int size)
{
        System.Collections.Generic.IList<CocheEN> list = null;

        list = _ICocheRepository.ObtenerCoches (first, size);
        return list;
}
public CocheEN ObtenCocheId (int id
                             )
{
        CocheEN cocheEN = null;

        cocheEN = _ICocheRepository.ReadOIDDefault(id);
        return cocheEN;
}

public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXTipo (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum ? tipo)
{
        return _ICocheRepository.FiltroXTipo (tipo);
}
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXMarca (string marca)
{
        return _ICocheRepository.FiltroXMarca (marca);
}
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXPlazas (int ? plazas)
{
        return _ICocheRepository.FiltroXPlazas (plazas);
}
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXPrecio (double ? precio)
{
        return _ICocheRepository.FiltroXPrecio (precio);
}
}
}
