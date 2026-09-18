using UnityEngine;

[CreateAssetMenu(fileName = "SceneDimensionHandler", menuName = "Scriptable Objects/SceneDimensionHandler")]
public class SceneDimensionHandler : ScriptableObject
{
    [SerializeField] private bool _sceneDimensions; //true for 3D, false for 2D

    void OnStart()
    {
        _sceneDimensions = true;
    }

    public void SetSceneDimensions(bool dimensions)
    {
        _sceneDimensions = dimensions;
    }

    public bool GetSceneDimensions()
    {
        return _sceneDimensions;
    }
}
