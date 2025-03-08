using System.Collections.Generic;
using System.Xml;
using Mono.Cecil.Cil;
using TMPro; 
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private LayerMask pickUpLayerMask;

    [SerializeField]
    private Transform objectGrabPointTransform;

    public float pickUpDistance = 2f;

    public float rotationSpeed = 5f;

    private ObjectGrabbable objectGrabbable;

    private List<float> photoFrames = new List<float>();
    private itemCounter itemCounter;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (objectGrabbable == null) {
                // not carrying an object, try to grab
                Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask);
                if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {

                    //     void OnTriggerEnter(Collider other)
                    //     {
                    //         if (other.gameObject.CompareTag("CollectableItem")) // Check if the collided object has the "CollectableItem" tag
                    //         {

                    if (objectGrabbable.tag == "photoFrame") {

                        if (photoFrames.Contains(objectGrabbable.GetInstanceID())){
                            // do nothing
                        } else {
                            // add unique id to photoFrame;
                            photoFrames.Add(objectGrabbable.GetInstanceID());

                            // Increment the item counter
                            // if (itemCounter != null)
                            // {
                            itemCounter.IncrementCount();
                            
                            // }
                        }
                    }


                    //             // Destroy the collected item
                    //             Destroy(other.gameObject);
                    //         }
                    //     }

                    // grab object
                    objectGrabbable.Grab(objectGrabPointTransform);
                    Debug.Log(objectGrabbable.tag);  
                    // itemCounter.IncrementCount();                  
                }
            } else {
                // currently carrying something, drop
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
