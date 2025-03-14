using System.Collections.Generic;
using System.Xml;
using Mono.Cecil.Cil;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpDrop : MonoBehaviour
{


    [SerializeField] private Transform playerCameraTransform;

    [SerializeField] private LayerMask pickUpLayerMask;

    [SerializeField] private Transform objectGrabPointTransform;

    public float pickUpDistance = 2f;

    public float rotationSpeed = 5f;

    private ObjectGrabbable objectGrabbable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (objectGrabbable == null) {
                // not carrying an object, try to grab
                Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask);
                if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {                    
                    objectGrabbable.Grab(objectGrabPointTransform);
                    GetObjectGrabbable();
                }

            } else {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }

    public ObjectGrabbable GetObjectGrabbable() {
        if (objectGrabbable != null) {                    
            return objectGrabbable = objectGrabbable.GetComponent<ObjectGrabbable>();
        } else {
            return null;
        }
    }

}
