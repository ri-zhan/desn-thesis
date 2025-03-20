using System.Collections.Generic;
using System.Xml;
using Mono.Cecil.Cil;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour

{

    // public string[,] itemIDs;
    [SerializeField] private PlayerPickUpDrop playerPickUpDrop;
    [SerializeField] private TMP_Text itemCountText;
    private ObjectGrabbable objectGrabbable;
    [SerializeField] private GameObject containerBig;

    public List<int> itemIdList = new List<int>();
    // public TMP_Text itemCountText; // UI Text element
    public int itemCount; // Item count
    public int itemTotal;

    private void Start() 
    {
        countItemTotal();
        updateText();
    }

    private void countItemTotal() {

        var go = GameObject.FindGameObjectsWithTag("photoFrame");
        
        for(var i = 0; i < go.Length; i++)
        {
            itemTotal++;
        }
        Debug.Log(itemTotal);
    }

    private void Update()
    {
        if (playerPickUpDrop.GetObjectGrabbable() != null) {
            addToList();
        } else {
            // hideCaption();
        }
    }
    public void addToList()
    {
        if (itemIdList.Count != (itemTotal)) {
            if (itemIdList.Contains(playerPickUpDrop.itemId) == false) {
                itemIdList.Add(playerPickUpDrop.itemId);
            }
            updateText();
        } else {
            Debug.Log("working");
        }

    }

    private void updateText() {
        itemCount = itemIdList.Count;
        itemCountText.text = itemCount + "/" + itemTotal;
    }

    // public void UpdateText()
    // {
    //     if (itemCountText != null)
    //     {
    //         itemCountText.text = itemCount.ToString();
    //         Debug.Log(itemCountText);

    //     }
    // }
}
