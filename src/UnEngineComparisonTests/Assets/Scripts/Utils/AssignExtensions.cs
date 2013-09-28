using UnityEngine;
using System.Collections;

static class AssignExtensions 
{
    public static UnEngine.Vector3 ToUnEngine(this Vector3 v)
    {
        return new UnEngine.Vector3(v.x, v.y, v.z);
    }
    public static Vector3 ToUnity(this UnEngine.Vector3 v)
    {
        return new Vector3(v.x, v.y, v.z);
    }
}