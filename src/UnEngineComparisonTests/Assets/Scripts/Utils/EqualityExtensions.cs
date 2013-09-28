using System;
using UnityEngine;

public static class Vector3Extensions
{
    public static bool DoesEqual(this Vector3 unityVector3, UnEngine.Vector3 unVector3)
    {
        //TODO: better comparison. Do we want some fudge room, or should they be identical?
        return (unityVector3.x == unVector3.x && unityVector3.y == unVector3.y && unityVector3.z == unVector3.z);
    }

    public static void AssertEquals(this Vector3 unityVector3, UnEngine.Vector3 unVector3, string identifier = "")
    {
        if (!unityVector3.DoesEqual(unVector3))
            throw new AssertException(string.Format("{2} unity vector3 not equal to unengine vector3! unity: {0} unegine: {1}", unityVector3, unVector3, identifier));
    }
}

public class AssertException : Exception
{
    public AssertException(string format) : base(format)
    {
        
    }
}

public static class QuaternionExtensions
{
    public static bool DoesEqual(this Quaternion uyQuat, UnEngine.Quaternion unQuat)
    {
        return (uyQuat.x == unQuat.x && uyQuat.y == unQuat.y && uyQuat.z == unQuat.z && uyQuat.w == unQuat.w);
    }

    public static void AssertEquals(this Quaternion uyQuat, UnEngine.Quaternion unQuat, string identifier = "")
    {
        if (!uyQuat.DoesEqual(unQuat))
            throw new AssertException(string.Format("{2} Unity quaternion not equal to unEngine quaternion! unity: {0} unengine: {1}", uyQuat, unQuat, identifier));
    }
}