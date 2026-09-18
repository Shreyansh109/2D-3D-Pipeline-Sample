using UnityEngine;
using UnityEngine.InputSystem;
public class SceneChanger : MonoBehaviour
{
    Animator animator;
    [SerializeField] private SceneDimensionHandler sceneData;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("is3D", sceneData.GetSceneDimensions());
    }

    void OnDimensionChanger(InputValue value)
    {
        sceneData.SetSceneDimensions(!sceneData.GetSceneDimensions());
        animator.SetBool("is3D", sceneData.GetSceneDimensions());
    }
}
