using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    // movement speed
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Movement")]
    public KeyCode jumpKey = KeyCode.Space;

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

        // check if jump key is pressed to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded) 
        {
            readyToJump = false;

            Jump();

            // jumpCoolDown for delay
            Invoke(nameof(resetJump), jumpCoolDown);
        } 
    }

    private void MovePlayer() 
    {
        // calculate movement direction, always walk in direction you're looking
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // if on ground (add force to player)
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // if not on ground and in air (change air control)
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
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

    private void Jump()
    {
        // reset y velocity
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // apply force in the upwards direction, use forcemode impulse because force is only applied once
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump() 
    {
        readyToJump = true;
    }
}
