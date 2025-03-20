using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
using TMPro;

public class ObjectGrabbable : MonoBehaviour
{

    // NPCInteractable

    [SerializeField] private string objectCaption;
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    public float lerpSpeed = 10f;

    public float rotationSpeed = 5f;


    public void Awake() {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform) {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
    }

    public void Drop() {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate() {
        if (objectGrabPointTransform != null) {
            Vector3 newPosition =  Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
            objectRigidbody.transform.rotation = Quaternion.Euler(
                90 + Camera.main.transform.eulerAngles.x, 
                Camera.main.transform.eulerAngles.y, 
                0);
        }
    }

    public string GetObjectCaption() 
    {
        return objectCaption;
    }

}
