using UnityEngine;

public interface IPrefabProvider
{
    TPrefab Load<TPrefab>(string prefabPath) where TPrefab : Object;
}