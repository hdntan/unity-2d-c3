using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : ShootableObjectCtrl
{
    protected override string GetObjTypeString()
    {
       return ObjType.Junk.ToString();  
    }
}
