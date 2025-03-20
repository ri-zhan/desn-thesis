using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CaptionDisplay : MonoBehaviour
{
    [SerializeField] private GameObject containerForUI;
    // [SerializeField] private Rigidbody ;
    private ObjectGrabbable objectGrabbable;
    [SerializeField] private PlayerPickUpDrop playerPickUpDrop;
    [SerializeField] private TMP_Text objectCaptionTMP;

    private void Update()
    {
        if (playerPickUpDrop.GetObjectGrabbable() != null) {
            showCaption(playerPickUpDrop.GetObjectGrabbable());
        } else {
            hideCaption();
        }
    }

    public void showCaption(ObjectGrabbable objectGrabbable) 
    {   
        containerForUI.SetActive(true);
        objectCaptionTMP.text = objectGrabbable.GetObjectCaption();
    }

    public void hideCaption() 
    {
        containerForUI.SetActive(false);
    }
}
