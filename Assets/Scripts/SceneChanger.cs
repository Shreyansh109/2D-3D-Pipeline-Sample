using UnityEngine;
using UnityEngine.InputSystem;
public class SceneChanger : MonoBehaviour
{
    // Controls the visual transition between the 2D and 3D states.
    Animator animator;

    // Shared handler that stores which scene dimension is currently active.
    [SerializeField] private SceneDimensionHandler sceneData;


    void Start()
    {
        // Get the Animator attached to this scene transition object.
        animator = GetComponent<Animator>();
        // Match the initial animation state to the active scene dimension.
        animator.SetBool("is3D", sceneData.GetSceneDimensions());
    }

    void OnDimensionChanger(InputValue value)
    {
        // This callback is invoked by the dimension-change input action.
        // Toggle the dimension and immediately update the transition animation.
        sceneData.SetSceneDimensions(!sceneData.GetSceneDimensions());
        animator.SetBool("is3D", sceneData.GetSceneDimensions());
    }
}
