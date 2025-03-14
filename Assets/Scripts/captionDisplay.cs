using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CaptionDisplay : MonoBehaviour
{


    // playserInteractUI

    // public bool captionVisible;
    // public TextMeshProUGUI textDisplay; // UI Text element

    // public string[] captions;
    // private int index;

    // public float typingSpeed;
    
    // public GameObject framePickedUp;

    [SerializeField] private GameObject containerForUI;
    // [SerializeField] private Rigidbody ;
    private ObjectGrabbable objectGrabbable;
    [SerializeField] private PlayerPickUpDrop playerPickUpDrop;
    [SerializeField] private TMP_Text objectCaptionTMP;

    private void Start()
    {
        playerPickUpDrop = GetComponent<PlayerPickUpDrop>();
        // objectGrabbable = gameObject.AddComponent<ObjectGrabbable>();
    }

    // private void Update()
    // {
    //     // if (Input.GetKeyDown(KeyCode.E)) {
    //         if (playerPickUpDrop.GetObjectGrabbable() != null) {
    //             showCaption(playerPickUpDrop.GetObjectGrabbable());
    //             // Debug.Log(playerPickUpDrop.GetObjectGrabbable());
    //         } else {
    //             hideCaption();
    //         }
    //     // }
    // }

    public void showCaption(ObjectGrabbable objectGrabbable) 
    {   
        containerForUI.SetActive(true);
        // Debug.Log("showing caption");
        // getFrameNum();
        // frameCaption.enabled = false;
        // objectCaptionTMP.text = objectGrabbable.GetObjectCaption();
    }

    public void hideCaption() 
    {
        containerForUI.SetActive(false);
        // frameCaption.enabled = false;
        // frameCaption = null;
    }
}
