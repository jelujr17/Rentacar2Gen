

using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository.RentaCar2;
using Rentacar2Gen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rentacar2Gen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override ICocheRepository CocheRepository {
        get
        {
                this.cocherepository = new CocheRepository ();
                this.cocherepository.setSessionCP (session);
                return this.cocherepository;
        }
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IMarcaRepository MarcaRepository {
        get
        {
                this.marcarepository = new MarcaRepository ();
                this.marcarepository.setSessionCP (session);
                return this.marcarepository;
        }
}

public override IReservaRepository ReservaRepository {
        get
        {
                this.reservarepository = new ReservaRepository ();
                this.reservarepository.setSessionCP (session);
                return this.reservarepository;
        }
}

public override INotificacionesRepository NotificacionesRepository {
        get
        {
                this.notificacionesrepository = new NotificacionesRepository ();
                this.notificacionesrepository.setSessionCP (session);
                return this.notificacionesrepository;
        }
}

public override IMensajesRepository MensajesRepository {
        get
        {
                this.mensajesrepository = new MensajesRepository ();
                this.mensajesrepository.setSessionCP (session);
                return this.mensajesrepository;
        }
}

public override IValoracionRepository ValoracionRepository {
        get
        {
                this.valoracionrepository = new ValoracionRepository ();
                this.valoracionrepository.setSessionCP (session);
                return this.valoracionrepository;
        }
}
}
}

