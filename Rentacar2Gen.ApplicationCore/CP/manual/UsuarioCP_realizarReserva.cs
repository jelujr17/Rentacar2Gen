using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using System.Linq;

namespace Rentacar2Gen.ApplicationCore.CP.RentaCar2
{
    public partial class UsuarioCP : GenericBasicCP
    {
        private readonly ICocheRepository _cocheRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IReservaRepository _reservaRepository;

        // Constructor que recibe las dependencias
        public UsuarioCP(ICocheRepository cocheRepository, IUsuarioRepository usuarioRepository, IReservaRepository reservaRepository)
        {
            _cocheRepository = cocheRepository;
            _usuarioRepository = usuarioRepository;
            _reservaRepository = reservaRepository;
        }

        public int realizarReserva(int p_oid, int c_oid, DateTime fechaInicio, DateTime fechaFinal, DateTime fechaPago)
        {
            // Obtener el usuario por su ID
            UsuarioEN usuario = _usuarioRepository.ObtenUsuarioId(p_oid);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            // Obtener el coche por su ID
            CocheEN coche = _cocheRepository.ObtenCocheId(c_oid);

            if (coche == null)
            {
                throw new Exception("Coche no encontrado.");
            }

            // Verificar que el coche esté disponible
            if (coche.Disponible == Enumerated.RentaCar2.EstadoEnum.reservado)
            {
                throw new Exception("El coche no está disponible en estos momentos.");
            }

            // Crear una reserva del coche disponible
            ReservaEN nuevaReserva = new ReservaEN
            {
                FechaInicio = fechaInicio,
                FechaFin = fechaFinal,
                FechaPago = fechaPago,
                Usuario = usuario,
                Coche = coche
            };

            int reserva = _reservaRepository.NuevaReserva(nuevaReserva);
            return reserva;
        }
    }
}