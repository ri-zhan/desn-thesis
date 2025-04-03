using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Mono.Cecil.Cil;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour

{
    [SerializeField] private PlayerPickUpDrop playerPickUpDrop;
    [SerializeField] private OpenDoor openDoor;
    [SerializeField] private TMP_Text itemCountText;
    [SerializeField] private GameObject containerBig;
    private GameObject doorColliderChanger;
    private ObjectGrabbable objectGrabbable;
    public List<int> itemIdList;
    private int itemCount; // Item count
    public int itemTotal; 
    public GameObject[] photoFramesInScene;


    private void Awake() 
    {
        doorColliderChanger = GameObject.FindGameObjectWithTag("doorColliderChanger");
        doorColliderChanger.SetActive(false);

        // itemIdList.Clear();

        countItemTotal();
        updateText();
        // SceneManager.sceneLoaded
    }

    public void countItemTotal() {
        if ((SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 3)) == "Van") {
            photoFramesInScene = GameObject.FindGameObjectsWithTag("photoFrameVan");
        } else {
            photoFramesInScene = GameObject.FindGameObjectsWithTag("photoFrameTor");
        }
        
        for(var i = 0; i < photoFramesInScene.Length; i++)
        {
            itemTotal++;
        }
    }

    private void Update()
    {
        if (playerPickUpDrop.GetObjectGrabbable() != null) {
            addToList();
        } 
    }

    public void addToList()
    {
        if (itemIdList.Count != (itemTotal)) {
            if (itemIdList.Contains(playerPickUpDrop.itemId) == false) {
                itemIdList.Add(playerPickUpDrop.itemId);
            }
            updateText();
            if (itemCount == itemTotal) {
                doorColliderChanger.SetActive(true);
            }
        } 
    }

    public void updateText() {
        itemCount = itemIdList.Count;
        itemCountText.text = itemCount + "/" + itemTotal;
    }
}
