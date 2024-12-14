
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository.RentaCar2;
using Rentacar2Gen.Infraestructure.CP;
using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.CP.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository;
using Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using System.Linq;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                CocheRepository cocherepository = new CocheRepository ();
                CocheCEN cochecen = new CocheCEN (cocherepository);
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                MarcaRepository marcarepository = new MarcaRepository ();
                MarcaCEN marcacen = new MarcaCEN (marcarepository);
                ReservaRepository reservarepository = new ReservaRepository ();
                ReservaCEN reservacen = new ReservaCEN (reservarepository);
                NotificacionesRepository notificacionesrepository = new NotificacionesRepository ();
                NotificacionesCEN notificacionescen = new NotificacionesCEN (notificacionesrepository);
                MensajesRepository mensajesrepository = new MensajesRepository ();
                MensajesCEN mensajescen = new MensajesCEN (mensajesrepository);
                ValoracionRepository valoracionrepository = new ValoracionRepository ();
                ValoracionCEN valoracioncen = new ValoracionCEN (valoracionrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
                int usuario1 = usuariocen.NuevoUsuario ("usuario1@gmail.com", "usuario1", "foto1", new DateTime (2024, 11, 7), 123456789, "alicante", "favoritos1");
                int usuario2 = usuariocen.NuevoUsuario ("usuario2@gmail.com", "usuario2", "foto2", new DateTime (2024, 04, 7), 987654321, "valencia", "favoritos2");
                Console.WriteLine ("Usuarios creados");

                int marca1 = marcacen.NuevaMarca ("Mercedes");
                int marca2 = marcacen.NuevaMarca ("Audi");
                Console.WriteLine ("Marcas creadas");

                //OPERACION CRUD CUSTOMIZADA, ATRIBUTO DISPONIBLE POR DEFECTO A DISPONIBLE
                int coche1 = cochecen.NuevoCoche ("a1", "imagen1", 1.1, 1, TipoEnum.turismo, "coche1", usuario1, marca1);
                int coche2 = cochecen.NuevoCoche ("a2", "imagen2", 2.2, 2, TipoEnum.suv, "coche2", usuario2, marca2);
                int coche3 = cochecen.NuevoCoche ("a3", "imagen3", 3.3, 4, TipoEnum.turismo, "coche3", usuario1, marca1);
                int coche4 = cochecen.NuevoCoche ("a4", "imagen4", 4.4, 4, TipoEnum.deportivo, "coche4", usuario2, marca1);
                Console.WriteLine ("Coches creados");

                int reserva1 = reservacen.NuevaReserva (coche1, new DateTime (2024, 11, 7), new DateTime (2024, 11, 13), usuario1, new DateTime (2024, 11, 13));
                int reserva2 = reservacen.NuevaReserva (coche2, new DateTime (2024, 11, 13), new DateTime (2024, 11, 15), usuario2, new DateTime (2024, 11, 13));
                Console.WriteLine ("Reservas creadas");

                IList<int> notificacion_usuarios = new List<int> ();
                notificacion_usuarios.Add (usuario1);
                notificacion_usuarios.Add (usuario2);


                int notificacion1 = notificacionescen.NuevaNotificacion ("mensaje1", new DateTime (2024, 11, 7), notificacion_usuarios);
                int notificacion2 = notificacionescen.NuevaNotificacion ("mensaje2", new DateTime (2024, 11, 13), notificacion_usuarios);
                Console.WriteLine ("Notificacion creada");

                int mensaje1 = mensajescen.NuevoMensaje (usuario1, usuario2, "mensaje1", new DateTime (2024, 11, 7));
                int mensaje2 = mensajescen.NuevoMensaje (usuario2, usuario1, "mensaje2", new DateTime (2024, 11, 7));
                Console.WriteLine ("Mensajes creados");
                UsuarioEN usuer = usuariocen.ObtenUsuarioId(usuario1);
                int valoracion1 = valoracioncen.NuevaValoracion ("valoracion1", 5, TipoValoracionEnum.coche, usuer, coche1);
                int valoracion2 = valoracioncen.NuevaValoracion ("valoracion2", 3, TipoValoracionEnum.coche, usuer, coche1);
                int valoracion3 = valoracioncen.NuevaValoracion ("valoracion3", 3, TipoValoracionEnum.coche, usuer, coche1);
                int valoracion4 = valoracioncen.NuevaValoracion ("valoracion4", 5, TipoValoracionEnum.coche, usuer, coche1);
                Console.WriteLine ("Valoraciones creadas");

                /*FILTROS*/
                /*FILTRO POR TIPO*/
                IList<CocheEN> cochePorTipo = cochecen.FiltroXTipo (TipoEnum.turismo);

                Console.WriteLine ("Consultamos los coches por tipo: " + TipoEnum.turismo);

                foreach (CocheEN coche in cochePorTipo) {
                        Console.WriteLine ("Los coches son: " + coche.Id + ", " + coche.Matricula);
                }

                /*FILTRO POR MARCA*/
                IList<CocheEN> cochePorMarca = cochecen.FiltroXMarca ("Mercedes");

                Console.WriteLine ("Consultamos los coches por marca Mercedes");

                foreach (CocheEN coche in cochePorMarca) {
                        Console.WriteLine ("Los coches son: " + coche.Id + ", " + coche.Matricula);
                }

                /*FILTRO POR PLAZAS*/
                IList<CocheEN> cochePorPlazas = cochecen.FiltroXPlazas (4);

                Console.WriteLine ("Consultamos los coches por que tengan 4 plazas");

                foreach (CocheEN coche in cochePorPlazas) {
                        Console.WriteLine ("Los coches son: " + coche.Id + ", " + coche.Matricula);
                }

                /*FILTRO POR PRECIO*/
                IList<CocheEN> cochePorPrecio = cochecen.FiltroXPrecio (5.5);

                Console.WriteLine ("Consultamos los coches que tengan un precio menor o igual de 5");

                foreach (CocheEN coche in cochePorPrecio) {
                        Console.WriteLine ("Los coches son: " + coche.Id + ", " + coche.Matricula);
                }

                /*FILTROS*/

                //OPERACIONES CRUD CUSTOMIZADAS

                //reservarCoche
                cochecen.ReservarCoche (coche1);
                Console.WriteLine ("El coche ha sido reservado correctamente.");

                //desreservarCoche
                cochecen.DesreservarCoche(coche1);
                Console.WriteLine("El coche ha sido liberado correctamente.");

                //Se vuelve a reservar para futuras comprobaciones
                cochecen.ReservarCoche(coche1);
                Console.WriteLine("El coche ha sido reservado correctamente.");

                //OPERACIONES CUSTOM NO CRUD

                //verDisponibles
                IList<CocheEN> cochesDisponibles = cochecen.VerDisponibles ();
                foreach (CocheEN coche in cochesDisponibles) {
                    Console.WriteLine ("Los coches disponibles son: " + coche.Id + ", " + coche.Matricula);
                }
                
                //valoracionesCocheId
                IList<ValoracionEN> valoracionesCochesId = valoracioncen.ValoracionesCocheId (coche1);
                foreach (ValoracionEN valoracion in valoracionesCochesId) {
                    Console.WriteLine ("Las valoraciones del coche con ID: " + coche1 + " son: " + valoracion.Valoracion);
                }
                 
                //valoracionesUsuariosId
                IList<ValoracionEN> valoracionesUsuariosId = valoracioncen.ValoracionesUsuarioId (usuario1);
                foreach (ValoracionEN valoracion in valoracionesUsuariosId) {
                    Console.WriteLine ("Las valoraciones del usuario con ID: " + usuario1 + " son: " + valoracion.Comentario);
                }

                List<int> cochesFavoritos = new List<int> { coche1, coche2, coche3 };
                string resultadoFinal = "";

                foreach (int cocheId in cochesFavoritos)
                {
                    resultadoFinal = usuariocen.AddFavorito(usuario1, cocheId);

                }
                Console.WriteLine("Lista de favoritos del usuario después de agregar los coches: " + resultadoFinal);

                string favoritosActual = usuariocen.EliminarFavorito(usuario1, coche1);
                Console.WriteLine("Lista de favoritos después de quitar uno: " + favoritosActual);

                // Suponiendo que tienes instancias de los repositorios:
                ICocheRepository cocheRepository = new CocheRepository();
                IUsuarioRepository usuarioRepository = new UsuarioRepository();
                IReservaRepository reservaRepository = new ReservaRepository();

                // Crear la instancia de UsuarioCP con las dependencias
                UsuarioCP usuarioCP = new UsuarioCP(cocheRepository, usuarioRepository, reservaRepository);
                ReservaCP reservaCP = new ReservaCP(cocheRepository, usuarioRepository, reservaRepository);


                DateTime fechaInicio = DateTime.Now;
                DateTime fechaFin = DateTime.Now.AddDays(7);
                DateTime fechaPago = DateTime.Now;

                // Llamar al método realizarReserva
                int resultadoReserva = usuarioCP.realizarReserva(usuario1, coche3, fechaInicio, fechaFin, fechaPago);
                Console.WriteLine("La reserva se ha creado con el ID: " + resultadoReserva);

                string reservaFinalizada = reservaCP.finalizarReserva(resultadoReserva, fechaFin);
                Console.WriteLine("reservaFinalizada: " + resultadoReserva);



                UsuarioEN usuario = usuariocen.GetByCorreo("usuario1@gmail.com");
                if (usuario != null)
                {
                    Console.WriteLine("Usuario con correo usuario1: " + usuario.Correo);
                }
                else
                {
                    Console.WriteLine("Usuario con correo usuario1 no encontrado.");
                }


                UsuarioEN usuarioc = usuariocen.ObtenUsuarioId(usuario1);
                if(usuarioc != null)
                {
                    Console.WriteLine("Favoritos del usuario1" + usuarioc.Favoritos);
                }
                else
                {
                    Console.WriteLine("Coche  no encontrado.");
                }



                int valoracionBusqueda = valoracioncen.ValoracionesCocheId(coche1).Count;

                Console.Write("Numero de valoraciones para el coche 1: "+ valoracionBusqueda);

                /*PROTECTED REGION END*/
            }
            catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
