
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (int idUsuario
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int NuevoUsuario (UsuarioEN usuario);

void Modificar (UsuarioEN usuario);


void EliminarUsuario (int idUsuario
                      );


UsuarioEN ObtenUsuarioId (int idUsuario
                          );

UsuarioEN GetByCorreo(string correo);
System.Collections.Generic.IList<UsuarioEN> ObtenerUsuarios (int first, int size);
        
}
}
