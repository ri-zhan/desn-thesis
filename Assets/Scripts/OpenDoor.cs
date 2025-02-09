using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    [Header("Movement")]
    public float openDistance = 45f;
    public float openTime = 3f;


    private bool doorOpened;
    private bool coroutineAllowed;

    // Start is called before the first frame update
    void Start()
    {
        doorOpened = false;
        coroutineAllowed = true;
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
        if (!doorOpened)
        {
            for (float i = 0f; i <= openDistance; i += openTime)
            {
                transform.localRotation = Quaternion.Euler(0f, -i, 0f);
                yield return new WaitForSeconds(0f);
            }
            doorOpened = true;
        }
        else
        {
            for (float i = openDistance; i >= 0f; i -= openTime)
            {
                transform.localRotation = Quaternion.Euler(0f, -i, 0f);
                yield return new WaitForSeconds(0f);
            }
            doorOpened = false;
        }
        coroutineAllowed = true;
    }
}

// from this https://www.youtube.com/watch?v=Y2zdimfoLxA&ab_channel=AlexanderZotov
