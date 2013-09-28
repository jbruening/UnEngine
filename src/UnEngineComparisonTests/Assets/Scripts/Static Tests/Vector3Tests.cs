using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

class Vector3Tests : StaticTest 
{
    [MenuItem("Tests/Vector3/All")]
    [SkipTest]
    protected static void AllTests()
    {
        RunAllMenuItems<Vector3Tests>();
    }

    private const int PropertyTestCount = 500000;

    [MenuItem("Tests/Vector3/Properties")]
    static void Properties()
    {
        for (int i = 0; i < PropertyTestCount; i++)
        {
            var x = Random.Range(float.MinValue, float.MaxValue);
            var y = Random.Range(float.MinValue, float.MaxValue);
            var z = Random.Range(float.MinValue, float.MaxValue);

            var expected = new Vector3(x, y, z);
            var actual = new UnEngine.Vector3(x, y, z);

            expected.AssertEquals(actual);
        }

        Debug.Log("Completed Vector3 Properties test");
    }

    private const int OperatorsTestCount = 500000;
    [MenuItem("Tests/Vector3/Operators")]
    static void Operators()
    {
        for (int i = 0; i < OperatorsTestCount; i++)
        {
            var expected = Random.insideUnitSphere;
            var actual = expected.ToUnEngine();

            expected *= 3f;
            actual *= 3f;

            expected.AssertEquals(actual, "float multiplication:");

            expected /= 2.5f;
            actual /= 2.5f;
            
            expected.AssertEquals(actual, "float division:");


            var extra = Random.insideUnitSphere;

            expected -= extra;
            actual -= extra.ToUnEngine();

            expected.AssertEquals(actual, "subtraction:");

            extra = Random.insideUnitSphere;
            
            expected += extra;
            actual += extra.ToUnEngine();

            expected.AssertEquals(actual, "addition:");
        }
        
        Debug.Log("Completed Vector3 Operators test");
    }
}