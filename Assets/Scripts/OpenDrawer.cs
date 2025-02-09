using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{

    [Header("Movement")]
    // movement speed
    public float openDistance = 0.1f;


    private bool boxOpened;
    private bool coroutineAllowed;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        boxOpened = false;
        coroutineAllowed = true;
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        Invoke("RunCoroutine", 0f);
    }

    private void RunCoroutine()
    {
        StartCoroutine("OpenThatDoor");
    }

    private IEnumerator OpenThatDoor()
    {
        // if(Input.GetMouseButtonDown(0)){
        //     Debug.Log("Held");
        // }
        coroutineAllowed = false;

        if (!boxOpened)
        {
            for (float i = 0f; i <= 1f; i += openDistance)
            {
                // go forwards on the x axis
                transform.localPosition = new Vector3(transform.localPosition.x + openDistance,
                    transform.localPosition.y,
                    transform.localPosition.z);
                yield return new WaitForSeconds(0f);
            }
            boxOpened = true;
        }
        else
        {
            for (float i = 1f; i >= 0f; i -= openDistance)
            {
                // go backwards on the x axis
                transform.localPosition = new Vector3(transform.localPosition.x - openDistance,
                    transform.localPosition.y,
                    transform.localPosition.z);
                yield return new WaitForSeconds(0f);
            }
            transform.position = initialPosition;
            boxOpened = false;
        }

        coroutineAllowed = true;
    }
}
