
using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public abstract class GenericUnitOfWorkRepository
{
protected ICocheRepository cocherepository;
protected IUsuarioRepository usuariorepository;
protected IMarcaRepository marcarepository;
protected IReservaRepository reservarepository;
protected INotificacionesRepository notificacionesrepository;
protected IMensajesRepository mensajesrepository;
protected IValoracionRepository valoracionrepository;


public abstract ICocheRepository CocheRepository {
        get;
}
public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IMarcaRepository MarcaRepository {
        get;
}
public abstract IReservaRepository ReservaRepository {
        get;
}
public abstract INotificacionesRepository NotificacionesRepository {
        get;
}
public abstract IMensajesRepository MensajesRepository {
        get;
}
public abstract IValoracionRepository ValoracionRepository {
        get;
}
}
}
