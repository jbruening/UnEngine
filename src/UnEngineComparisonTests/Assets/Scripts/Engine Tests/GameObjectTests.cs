using System;
using UnityEngine;

public class GameObjectTests : MonoBehaviour
{
    private UnEngine.GameObject _unGobj;

    void Awake()
    {
        _unGobj = new UnEngine.GameObject();

        var trans = _unGobj.transform;
        if (!trans)
        {
            throw new Exception("transform wasn't anything. Supposed to add one at creation");
        }
    }

    void Update()
    {
        UnEngine.InternalEngine.EngineState.Instance.Update(Time.time);

        transform.position = Vector3.forward * Mathf.Sin(Time.time);
        _unGobj.transform.position = UnEngine.Vector3.forward*UnEngine.Mathf.Sin(UnEngine.Time.time);

        transform.position.AssertEquals(_unGobj.transform.position, "gameobject position wiggling");
    }
}