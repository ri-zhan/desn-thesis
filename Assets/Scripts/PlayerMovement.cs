using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    // movement speed
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    // Keyboard inputs
    float horizontalInput;
    float verticalInput;

    // movement direction;
    Vector3 moveDirection;

    Rigidbody rb;
    void Start()
    {
        // assign rigid body
        rb = GetComponent<Rigidbody>();

        // free rotation, otherwise play falls over
        rb.freezeRotation = true;
    }



    // Input function for keyboard inputs
    // Update is called once per frame
    void Update()
    {
        // ground check, raycast from center of play then divide by half
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        // call input function 
        MyInput();

        SpeedControl();

        // handle drag (apply the drag)
        if(grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

    }
    
    private void FixedUpdate() 
    {
        MovePlayer();
    }

    private void MyInput() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() 
    {
        // calculate movement direction, always walk in direction you're looking
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // add force to player
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl() 
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit velocity if needed. if you go faster than moveSpeed,
        if(flatVel.magnitude > moveSpeed)
        {
            // calculate what your max velocity would be
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            // then apply it;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}
