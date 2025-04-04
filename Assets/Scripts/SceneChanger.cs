using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



// private string currentSceneName;

public class SceneChanger : MonoBehaviour
{
    private GameObject playerInteractUI;
    private ItemCounter itemCounter;
    private GameObject transitionDoor;
    private OpenDoor openDoor;

    
    Scene currentScene;
    public string currentSceneName;
    int currentYear;
    int nextYear;
    Scene nextScene;
    public string nextSceneName;
    public GameObject doorColliderChanger;


    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
        currentYear = int.Parse(currentSceneName.Substring(0,4));

        transitionDoor = GameObject.Find("transitionDoor");
        openDoor = transitionDoor.GetComponent<OpenDoor>();

        // playerInteractUI = GameObject.Find("PlayerInteractUI");
        // itemCounter = playerInteractUI.GetComponent<ItemCounter>();
    }

    public string GetNextSceneName()
    {
        // if it's currently toronto
        if ((currentSceneName.Substring(currentSceneName.Length - 3)) == "Tor")
        {
            // Debug.Log("it's getting here");
            nextYear = currentYear + 1;
            nextSceneName = nextYear.ToString() + "Van";
            return nextSceneName;

        // if its current vancouver
        } 
        else {
            nextSceneName = currentYear.ToString() + "Tor";
            return nextSceneName;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GetNextSceneName();
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
        openDoor.Invoke("RunCoroutine", 0f);
        
        doorColliderChanger.SetActive(false);
    }

}