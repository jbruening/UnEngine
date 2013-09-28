using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

abstract class StaticTest
{
    /// <summary>
    /// get all static methods that have the attribute MenuItem, but not SkipTest
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<MethodInfo> GetAllTestMethods<T>()
    {
        return typeof(T).GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public)
                         .Where(info => info.GetCustomAttributes(false).Any(a => a is MenuItem)
                                        && !info.GetCustomAttributes(false).Any(a => a is SkipTest)
                                        && info.GetParameters().Length == 0);
    }

    protected static void RunAllMenuItems<T>()
    {
        foreach (var method in GetAllTestMethods<T>())
        {
            try
            {
                method.Invoke(null, null);
            }
            catch (AssertException)
            {
                throw;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}