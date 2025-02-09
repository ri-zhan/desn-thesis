using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenBox : MonoBehaviour
{

    [Header("Movement")]
    // movement speed
    public float openDistance = 2.1f;
    public float moveSpeed = 1f;

    private Vector3 originalPos;
    private Vector3 openPos;
    private bool drawerCurrentlyOpen;
    private bool openningDrawer;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        // initialPosition = transform.position;

        drawerCurrentlyOpen = false;

        originalPos = transform.localPosition;

        openPos = new Vector3(transform.localPosition.x + openDistance,
            transform.localPosition.y,
            transform.localPosition.z);
    }

    void OnMouseDown() 
    {
        openningDrawer = true;
    }

    void Update()
    {
        if (openningDrawer) {
            if (!drawerCurrentlyOpen) {
                transform.localPosition = Vector3.Lerp(originalPos, openPos, Time.deltaTime * moveSpeed);
                drawerCurrentlyOpen = true;
            } else {
                transform.localPosition = Vector3.Lerp(openPos, originalPos, Time.deltaTime * moveSpeed);
                drawerCurrentlyOpen = false;
            }
            openningDrawer = false;
        }

        // if (timer == Time.deltaTime * moveSpeed) {
        // }
    }
}
