using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResetValues : MonoBehaviour
{

    private GameObject transitionDoor;
    private OpenDoor openDoor;

    private GameObject doorColliderUnloader;
    private SceneUnloader sceneUnloader;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameObject moveObjectsOver;

    private GameObject playerInteractUI;
    private ItemCounter itemCounter;

    void Start()
    {
        transitionDoor = GameObject.Find("transitionDoor");
        openDoor = transitionDoor.GetComponent<OpenDoor>();

        doorColliderUnloader = GameObject.Find("doorColliderUnloader");
        sceneUnloader = doorColliderUnloader.GetComponent<SceneUnloader>();
        
        moveObjectsOver = GameObject.FindGameObjectWithTag("MoveObjectsOver");

        playerInteractUI = GameObject.Find("PlayerInteractUI");
        itemCounter = playerInteractUI.GetComponent<ItemCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (openDoor.coroutineAllowed == false) {
        //     // do nothing
        // } else {
        //     // SceneManager.UnloadSceneAsync(sceneUnloader.unloadScene);
        //     Reset();
        // }
    }

    public void Reset()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.UnloadSceneAsync(sceneUnloader.unloadScene);
        itemCounter.itemIdList.Clear();
        itemCounter.itemTotal = 0;
        itemCounter.countItemTotal();
        itemCounter.updateText();
        // DontDestroyOnLoad(moveObjectsOver);

    }
}
