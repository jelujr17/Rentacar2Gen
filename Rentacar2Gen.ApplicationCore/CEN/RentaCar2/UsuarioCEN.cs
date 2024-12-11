

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using Newtonsoft.Json;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioRepository _IUsuarioRepository;

public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
{
        this._IUsuarioRepository = _IUsuarioRepository;
}

public IUsuarioRepository get_IUsuarioRepository ()
{
        return this._IUsuarioRepository;
}

public int NuevoUsuario (string p_correo, String p_pass, string p_foto, Nullable<DateTime> p_fechaNacimiento, int p_telefono, string p_direccion, string p_favoritos)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Correo = p_correo;

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        usuarioEN.Foto = p_foto;

        usuarioEN.FechaNacimiento = p_fechaNacimiento;

        usuarioEN.Telefono = p_telefono;

        usuarioEN.Direccion = p_direccion;

        usuarioEN.Favoritos = p_favoritos;



        oid = _IUsuarioRepository.NuevoUsuario (usuarioEN);
        return oid;
}

public void Modificar (int p_Usuario_OID, string p_correo, String p_pass, string p_foto, Nullable<DateTime> p_fechaNacimiento, int p_telefono, string p_direccion, string p_favoritos)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.IdUsuario = p_Usuario_OID;
        usuarioEN.Correo = p_correo;
        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuarioEN.Foto = p_foto;
        usuarioEN.FechaNacimiento = p_fechaNacimiento;
        usuarioEN.Telefono = p_telefono;
        usuarioEN.Direccion = p_direccion;
        usuarioEN.Favoritos = p_favoritos;
        //Call to UsuarioRepository

        _IUsuarioRepository.Modificar (usuarioEN);
}

public void EliminarUsuario (int idUsuario
                             )
{
        _IUsuarioRepository.EliminarUsuario (idUsuario);
}


public UsuarioEN ObtenUsuarioId(int idUsuario
                                    )
{
    UsuarioEN usuarioEN = null;

    usuarioEN = _IUsuarioRepository.ObtenUsuarioId(idUsuario);
    return usuarioEN;
}
public UsuarioEN GetByCorreo (string correo
                            )
{
UsuarioEN usuarioEN = null;

usuarioEN = _IUsuarioRepository.GetByCorreo (correo);
return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ObtenerUsuarios (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioRepository.ObtenerUsuarios (first, size);
        return list;
}


    public string Login(string correo, string p_pass)
    {
        string result = null;
        UsuarioEN en = _IUsuarioRepository.GetByCorreo(correo);

        if (en != null && en.Pass.Equals(Utils.Util.GetEncondeMD5(p_pass)))
            result = this.GetToken(en.Correo);

        return result;
    }




    private string Encode(string correo)
    {
        var payload = new Dictionary<string, object>(){
            { "correo", correo }
    };
        string token = Jose.JWT.Encode(payload, Utils.Util.getKey(), Jose.JwsAlgorithm.HS256);

        return token;
    }

    public string GetToken(string correo)
    {
        UsuarioEN en = _IUsuarioRepository.GetByCorreo(correo);
        string token = Encode(en.Correo);

        return token;
    }
    public string CheckToken(string token)
    {
        string result = null;

        try
        {
            string decodedToken = Utils.Util.Decode(token);



            string correo = (string)ObtenerCorreo(decodedToken);

            UsuarioEN en = _IUsuarioRepository.GetByCorreo(correo);

            if (en != null && ((string)en.Correo).Equals(ObtenerCorreo(decodedToken))
                )
            {
                result = correo;
            }
            else throw new ModelException("El token es incorrecto");
        }
        catch (Exception)
        {
            throw new ModelException("El token es incorrecto");
        }

        return result;
    }


    public string ObtenerCorreo(string decodedToken)
    {
        try
        {
            Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object>>(decodedToken);
            string correo = (string)results["correo"];
            return correo;
        }
        catch
        {
            throw new Exception("El token enviado no es correcto");
        }
    }
}
}
