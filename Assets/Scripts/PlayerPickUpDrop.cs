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
    public int itemId;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (objectGrabbable == null) {
                // not carrying an object, try to grab
                Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask);

                // this line is still returning an error when it's null even though it does not have to
                if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {          
                    objectGrabbable.Grab(objectGrabPointTransform);
                    itemId = objectGrabbable.GetInstanceID();
                    // Debug.Log(itemCounter.itemIdList);
                    // Debug.Log(itemCounter.itemIdList);
                    // itemCounter.itemIdList.Add(itemId);
                    // if (itemCounter.itemIdList.Contains(itemId) == false) {
                    // }
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
