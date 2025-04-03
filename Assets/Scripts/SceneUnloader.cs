using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;


// unload unload scene and enable event system in newActive scene
// 
// detect when player exists collider in new scene, and set this as active scene
// reset item counter

public class SceneUnloader : MonoBehaviour
{
    // [SerializeField] private ItemCounter itemCounter;
    [SerializeField] private SceneChanger sceneChanger;
    private OpenDoor openDoor;
    public GameObject doorColliderUnloader;
    public GameObject transitionDoor;


    // public GameObject unloadDoor;
    public GameObject moveObjectsOver;

    private GameObject playerInteractUI;
    private ItemCounter itemCounter;

    Scene newActiveScene;
    string newActiveSceneName;
    int newActiveYear;
    int unloadYear;
    public Scene unloadScene;
    public string unloadSceneName;

    private GameObject resetValueObject;
    private ResetValues resetValues;

    void Start()
    {
        // unloadScene = SceneManager.GetActiveScene();
        unloadScene = SceneManager.GetActiveScene();
        unloadSceneName = unloadScene.name;
        // unloadScene = SceneManager.SetActiveScene(unla);
        unloadYear = int.Parse(unloadSceneName.Substring(0,4));
        doorColliderUnloader = GameObject.FindGameObjectWithTag("doorColliderUnloader");

        transitionDoor = GameObject.Find("transitionDoor");
        openDoor = transitionDoor.GetComponent<OpenDoor>();

        resetValueObject = GameObject.Find("activeSceneChanged");
        resetValues = resetValueObject.GetComponent<ResetValues>();

        playerInteractUI = GameObject.Find("PlayerInteractUI");
        itemCounter = playerInteractUI.GetComponent<ItemCounter>();
    }

    public string GetNewActiveSceneName()
    {


        // if it's newActively toronto
        if ((unloadSceneName.Substring(unloadSceneName.Length - 3)) == "Tor")
        {
            newActiveYear = unloadYear + 1;
            newActiveSceneName = newActiveYear.ToString() + "Van";
            return newActiveSceneName;

        // if its newActive vancouver
        } 
        else {
            newActiveSceneName = unloadYear.ToString() + "Tor";
            return newActiveSceneName;
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {

        GetNewActiveSceneName();

        newActiveScene.name = newActiveSceneName;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newActiveSceneName));

        // doorColliderUnloader.SetActive(false);

        openDoor.Invoke("RunCoroutine", 0f);
        // itemCounter.itemIdList.Clear();


        //move door, environment prefab, player capsule, scene prefab,  to new active scene
        // SceneManager.MoveGameObjectToScene(moveObjectsOver, SceneManager.GetSceneByName(newActiveSceneName));

        // SceneManager.UnloadSceneAsync(unloadScene);
    }

}