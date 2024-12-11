using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using System.Linq;

namespace Rentacar2Gen.ApplicationCore.CP.RentaCar2
{
    public partial class ReservaCP : GenericBasicCP
    {
        private readonly ICocheRepository _cocheRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IReservaRepository _reservaRepository;

        // Constructor que recibe las dependencias
        public ReservaCP(ICocheRepository cocheRepository, IUsuarioRepository usuarioRepository, IReservaRepository reservaRepository)
        {
            _cocheRepository = cocheRepository;
            _usuarioRepository = usuarioRepository;
            _reservaRepository = reservaRepository;
        }

        public string finalizarReserva(int r_oid, DateTime fechaFinal)
        {
            ReservaEN reserva = _reservaRepository.ObtenReservaId(r_oid);

            //Comprobar si hoy es el dia final de la reserva o posterior
            int resultado = DateTime.Compare(fechaFinal, (DateTime)reserva.FechaFin);
            CocheEN coche = _cocheRepository.ObtenCocheId(reserva.Coche.Id);

            if (resultado >= 0 )
            {
                _cocheRepository.DesreservarCoche(coche);
            }
            
            return "Reserva finalizada: ";
        }
    }
}
