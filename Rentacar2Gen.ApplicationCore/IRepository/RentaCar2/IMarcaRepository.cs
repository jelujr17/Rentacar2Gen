
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface IMarcaRepository
{
void setSessionCP (GenericSessionCP session);

MarcaEN ReadOIDDefault (int idMarca
                        );

void ModifyDefault (MarcaEN marca);

System.Collections.Generic.IList<MarcaEN> ReadAllDefault (int first, int size);



int NuevaMarca (MarcaEN marca);

void Modificar (MarcaEN marca);


void EliminarMarca (int idMarca
                    );
}
}
