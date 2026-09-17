using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector2 movementInput;
    Animator animator;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 20f;
    [SerializeField] float deceleration = 25f;

    [Header("Jump")]
    [SerializeField] float jumpForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("isRunningForward", movementInput.y > 0f);
        animator.SetBool("isRunningBackward", movementInput.y < 0f);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 targetDirection = new Vector3(
            movementInput.x,
            0f,
            movementInput.y
        ).normalized;

        Vector3 targetVelocity = targetDirection * moveSpeed;

        Vector3 currentHorizontalVelocity = new Vector3(
            rb.linearVelocity.x,
            0f,
            rb.linearVelocity.z
        );

        float currentAcceleration =
            movementInput != Vector2.zero ? acceleration : deceleration;

        Vector3 newVelocity = Vector3.MoveTowards(
            currentHorizontalVelocity,
            targetVelocity,
            currentAcceleration * Time.fixedDeltaTime
        );

        rb.linearVelocity = new Vector3(
            newVelocity.x,
            rb.linearVelocity.y,
            newVelocity.z
        );
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
