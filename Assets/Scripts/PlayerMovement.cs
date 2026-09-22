using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector2 movementInput;
    Animator animator;

    [SerializeField] public SceneDimensionHandler sceneData;
    [SerializeField] GameObject[] buildings;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 20f;
    [SerializeField] float deceleration = 25f;

    [Header("Jump")]
    [SerializeField] float jumpForce = 5f;

    [Header("Rotation")]
    [SerializeField] float rotationSpeed = 3f;
    Vector2 lookInput;
    float yaw;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        buildings = GameObject.FindGameObjectsWithTag("Building");
        print("Buildings length: " + buildings.Length);
        StartCoroutine(DimensionChangeDelayed());
        yaw = transform.eulerAngles.y;
    }

    void Update()
    {
        // Drive the forward and backward animation states from the current input.
        animator.SetBool("isRunningForward", movementInput.y > 0f);
        animator.SetBool("isRunningBackward", movementInput.y < 0f);

        // Rotation is only available while the scene is in its 3D dimension.
        if (sceneData.GetSceneDimensions())
        {
            Rotate();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Rotate()
    {
        yaw += lookInput.x * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
    }

    void Move()
    {
        // Sideways movement is disabled in the 2D dimension.
        float xForce = sceneData.GetSceneDimensions()
            ? movementInput.x
            : 0f;

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 targetDirection = (right * xForce + forward * movementInput.y).normalized;

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

        // Change only horizontal velocity so gravity and jumping remain unaffected.
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

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            StartCoroutine(DelayedJump());
            animator.SetTrigger("Jump");
        }
    }

    void OnDimensionChanger(InputValue value)
    {
        StartCoroutine(DimensionChangeDelayed());
    }
    IEnumerator DimensionChangeDelayed()
    {
        // Wait for the dimension change event to finish before updating buildings.
        yield return new WaitForSeconds(0.01f);

        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i].GetComponent<BuildingRenderer>().DimensionChanger();
        }

        if (!sceneData.GetSceneDimensions())
        {
            // Reset the player orientation when switching back to 2D.
            yaw = 0f;
            transform.rotation = Quaternion.identity;
        }
    }
    IEnumerator DelayedJump()
    {
        // Apply the impulse after the input event has been processed.
        yield return new WaitForSeconds(0.02f);

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}