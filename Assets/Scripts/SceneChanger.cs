using UnityEngine;
using UnityEngine.InputSystem;
public class SceneChanger : MonoBehaviour
{
    Animator animator;
    [SerializeField] private SceneDimensionHandler sceneData;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnDimensionChanger(InputValue value)
    {
        if (value.isPressed)
        {
            sceneData.SetSceneDimensions(!sceneData.GetSceneDimensions());
        }
        animator.SetBool("is3D", sceneData.GetSceneDimensions());
    }
}
