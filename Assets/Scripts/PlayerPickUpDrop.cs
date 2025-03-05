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


    // Update is called once per frame

    private ObjectGrabbable objectGrabbable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (objectGrabbable == null) {
                // not carrying an object, try to grab
                Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask);
                if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {
                    objectGrabbable.Grab(objectGrabPointTransform);
                    Debug.Log(objectGrabbable); 
                }
            } else {
                // currently carrying something, drop
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
