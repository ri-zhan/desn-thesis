using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // x y sensitive
    public float sensY;
    public float sensX;

    // player orientation
    public Transform orientation;

    // xy roation of camera
    float xRotation;
    float yRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // cursor lock in middle of screen
        Cursor.lockState = CursorLockMode.Locked;
        //cursor invisible;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse input * change over time * x sensitiity
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        // cannot look up down more than 90 degrees. 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        // rotate cam on both axis
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        // rotate player on x axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
