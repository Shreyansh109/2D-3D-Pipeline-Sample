using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector2 movementInput;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Run();
    }

    void Run()
    {
        rb.AddForce(new Vector3(movementInput.x * 3f, 0, movementInput.y * 3f), ForceMode.Force);
    }
    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}
