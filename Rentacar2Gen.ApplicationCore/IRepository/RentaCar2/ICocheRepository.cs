
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface ICocheRepository
{
void setSessionCP (GenericSessionCP session);

CocheEN ReadOIDDefault (int id
                        );

void ModifyDefault (CocheEN coche);

System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size);



void Modificar (CocheEN coche);


void EliminarCoche (int id
                    );


System.Collections.Generic.IList<CocheEN> ObtenerCoches (int first, int size);


CocheEN ObtenCocheId (int id
                      );



int NuevoCoche (CocheEN coche);

System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXTipo (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum ? tipo);


System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXMarca (string marca);


System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXPlazas (int ? plazas);


System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> FiltroXPrecio (double ? precio);


void ReservarCoche (CocheEN coche);


void DesreservarCoche (CocheEN coche);
}
}
