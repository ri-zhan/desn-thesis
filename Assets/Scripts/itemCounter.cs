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

    // public string[,] itemIDs;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private PlayerPickUpDrop playerPickUpDrop;
    [SerializeField] private OpenDoor openDoor;
    [SerializeField] private TMP_Text itemCountText;
    [SerializeField] private GameObject containerBig;
    [SerializeField] private GameObject doorColliderChanger;
    private ObjectGrabbable objectGrabbable;
    private List<int> itemIdList = new List<int>();
    private int itemCount; // Item count
    private int itemTotal; 
    public GameObject[] go;


    private void Start() 
    {
        countItemTotal();
        updateText();
    }

    private void countItemTotal() {
        if ((SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 3)) == "Van") {
            go = GameObject.FindGameObjectsWithTag("photoFrameVan");
        } else {
            go = GameObject.FindGameObjectsWithTag("photoFrameTor");
        }
        
        for(var i = 0; i < go.Length; i++)
        {
            itemTotal++;
        }
    }

    private void Update()
    {
        if (playerPickUpDrop.GetObjectGrabbable() != null) {
            addToList();
        } 
        if (itemCount == itemTotal) {
            if (Input.GetMouseButtonDown(0))  {
                openDoor.Invoke("RunCoroutine", 0f);
            }
            doorColliderChanger.SetActive(true);
        }
    }

    public void addToList()
    {
        if (itemIdList.Count != (itemTotal)) {
            if (itemIdList.Contains(playerPickUpDrop.itemId) == false) {
                itemIdList.Add(playerPickUpDrop.itemId);
            }
            updateText();
        } 
    }

    private void updateText() {
        itemCount = itemIdList.Count;
        itemCountText.text = itemCount + "/" + itemTotal;
    }
}
