using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenDrawer : MonoBehaviour
{

    [Header("Movement")]
    public float openDistance = 0.1f;
    public float openTime = 1f;

    private bool drawerOpened;
    private bool coroutineAllowed;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        drawerOpened = false;
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
        coroutineAllowed = false;
        if (!drawerOpened)
        {
            for (float i = 0f; i <= openTime; i += openDistance)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + openDistance,
                    transform.localPosition.y,
                    transform.localPosition.z);
                yield return new WaitForSeconds(0f);
            }
            drawerOpened = true;
        }
        else
        {
            for (float i = openTime; i >= 0f; i -= openDistance)
            {
                transform.localPosition = new Vector3(transform.localPosition.x - openDistance,
                    transform.localPosition.y,
                    transform.localPosition.z);
                yield return new WaitForSeconds(0f);
            }
            transform.position = initialPosition;
            drawerOpened = false;
        }
        coroutineAllowed = true;
    }
}

// from this https://www.youtube.com/watch?v=Y2zdimfoLxA&ab_channel=AlexanderZotov
