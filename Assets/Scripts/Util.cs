using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static class Util
{

    public static GameObject FindOrSpawn(string name)
    {
        GameObject gameObject = GameObject.Find(name);
        if (gameObject)
            return gameObject;
        return new GameObject(name);
    }


}
