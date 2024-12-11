
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2;


/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CEN.RentaCar2_Coche_nuevoCoche) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
public partial class CocheCEN
{
public int NuevoCoche (string p_matricula, string p_imagenes, double p_precio, int p_plazas, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum p_tipo, string p_descripcion, int p_propietario, int p_marca)
{
        /*PROTECTED REGION ID(Rentacar2Gen.ApplicationCore.CEN.RentaCar2_Coche_nuevoCoche_customized) ENABLED START*/

        CocheEN cocheEN = null;

        int oid;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.Matricula = p_matricula;

        cocheEN.Imagenes = p_imagenes;

        cocheEN.Precio = p_precio;

        cocheEN.Plazas = p_plazas;

        cocheEN.Tipo = p_tipo;

        cocheEN.Descripcion = p_descripcion;
        if (!Enum.IsDefined(typeof(TipoEnum), p_tipo))
        {
            throw new ArgumentException("Tipo de coche no válido");
        }

        

        if (p_propietario != -1) {
            cocheEN.Propietario = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.UsuarioEN ();
            cocheEN.Propietario.IdUsuario = p_propietario;
        }


        if (p_marca != -1) {
                cocheEN.Marca = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.MarcaEN ();
                cocheEN.Marca.IdMarca = p_marca;
        }

        cocheEN.Disponible = Enumerated.RentaCar2.EstadoEnum.disponible;

        //Call to CocheRepository

        oid = _ICocheRepository.NuevoCoche (cocheEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
