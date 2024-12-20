using System;
using System.Collections.Generic;
namespace Rentacar2Gen.ApplicationCore.EN.RentaCar2
{
public class CocheEN_OID
{
private string matriculo;
public virtual string Matriculo {
        get { return matriculo; } set { matriculo = value;  }
}




private int id;
public virtual int Id {
        get { return id; } set { id = value;  }
}






public CocheEN_OID()
{
}
public CocheEN_OID(string matriculo, int id)
{
        this.matriculo = matriculo;
        this.id = id;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CocheEN_OID t = obj as CocheEN_OID;
        if (t == null)
                return false;


        if (this.matriculo == t.Matriculo && this.id == t.Id)

                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        // Su tipo es String
        hash = hash +
               (null == matriculo                                                        ? 0 : this.matriculo.GetHashCode ());
        // Su tipo es Autogenerated
        hash = hash +
               (0 == id                                                 ? 0 : this.id.GetHashCode ());
        return hash;
}
}
}
