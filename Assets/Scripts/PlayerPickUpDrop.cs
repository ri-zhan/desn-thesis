using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private LayerMask pickUpLayerMask;

    // Update is called once per frame
    private void Update()
    {
        float pickUpDistance = 2f;
        if (Input.GetKeyDown(KeyCode.E)) {
            Physics.Raycast(transform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask);
        }
    }
}
