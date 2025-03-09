using System.Collections.Generic;
using System.Xml;
using Mono.Cecil.Cil;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
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
    private ItemCounter itemCounter;


    [SerializeField]
    public TMP_Text itemCountText; // UI Text element

    [SerializeField]
    public int itemCount; // Item count

    private CaptionDisplay captionDisplay;

    // private GameObject framePickedUp;
    private Rigidbody objectRigidbody;

    private TMP_Text frameCaption;

    private int frameNum;
    private string frameNameStr;

    public bool framePickedUp;

    private void Start() 
    {
        itemCount = 0;
        // itemCounter = new ItemCounter();
        itemCounter = gameObject.AddComponent<ItemCounter>();

        captionDisplay = gameObject.AddComponent<CaptionDisplay>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {

            if (objectGrabbable == null) {
                framePickedUp = true;
                // not carrying an object, try to grab
                Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask);
                if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {
                    // framePickedUp = objectGrabbable.gameObject;
                    // frameCaption = framePickedUp.GetComponentInChildren<TMP_Text>();

                    // captionDisplay.showCaption();
                    // framePickedUp.GetComponentInChildren<TMP_Text>().enabled = true;
                    // Debug.Log(framePickedUp);
                    // Debug.Log(frameCaption);
                    // captionDisplay.displayText();

                    //     void OnTriggerEnter(Collider other)
                    //     {
                    //         if (other.gameObject.CompareTag("CollectableItem")) // Check if the collided object has the "CollectableItem" tag
                    //         {

                    // if (objectGrabbable.tag == "photoFrame") {

                    //     if (photoFrames.Contains(objectGrabbable.GetInstanceID())){
                    //         // do nothing
                    //     } else {
                    //         // add unique id to photoFrame;
                    //         photoFrames.Add(objectGrabbable.GetInstanceID());

                    //         // Increment the item counter
                    //         // if (itemCounter != null)
                    //         // {
                    //         itemCounter.IncrementCount();
                            
                    //         // }
                    //     }
                    // }


                    //             // Destroy the collected item
                    //             Destroy(other.gameObject);
                    //         }
                    //     }

                    // grab object
                    objectGrabbable.Grab(objectGrabPointTransform);
                    // Debug.Log(objectGrabbable.tag);  
                    if (itemCounter == null) {
                        Debug.Log("item counter is null");
                    } else {
                        itemCounter.IncrementCount();
                    }
                } else {
                    framePickedUp = false;   
                }
            } else {
                // currently carrying something, drop
                objectGrabbable.Drop();
                objectGrabbable = null;

                framePickedUp = false;
            }
        }
    }

    public ObjectGrabbable GetObjectGrabbable() 
    {
        Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask);

        if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {
            // framePickedUp = true;
            Debug.Log(objectGrabbable);
            return objectGrabbable;
        } 
        return null;
    }
}
