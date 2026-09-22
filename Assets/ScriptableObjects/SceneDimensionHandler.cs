using UnityEngine;

[CreateAssetMenu(fileName = "SceneDimensionHandler", menuName = "Scriptable Objects/SceneDimensionHandler")]
public class SceneDimensionHandler : ScriptableObject
{
    // Shared state: true represents 3D mode, while false represents 2D mode.
    [SerializeField] private bool _sceneDimensions; //true for 3D, false for 2D

    void OnStart()
    {
        // Set the default scene dimension when this handler is initialized.
        _sceneDimensions = true;
    }

    public void SetSceneDimensions(bool dimensions)
    {
        // Update the shared dimension state for every system using this asset.
        _sceneDimensions = dimensions;
    }

    public bool GetSceneDimensions()
    {
        // Return true when the scene is in 3D mode.
        return _sceneDimensions;
    }
}
