using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector2 movementInput;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Run()
    {
        rb.AddForce(new Vector2(movementInput.x * 3f, movementInput.y * 3f), ForceMode.Force);
    }
    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}
