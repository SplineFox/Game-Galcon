using UnityEngine;

public class PrefabProvider
{
    public TPrefab Load<TPrefab>(string prefabPath) where TPrefab : Object
    {
        var prefab = Resources.Load<TPrefab>(prefabPath);
        return prefab;
    }
}