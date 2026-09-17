using UnityEngine;

[CreateAssetMenu(fileName = "SceneDimensionHandler", menuName = "Scriptable Objects/SceneDimensionHandler")]
public class SceneDimensionHandler : ScriptableObject
{
    [SerializeField] public bool _sceneDimensions; //true for 3D, false for 2D

    public void SetSceneDimensions(bool dimensions)
    {
        _sceneDimensions = dimensions;
    }
}
