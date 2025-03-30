// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework.Constraints;
// using UnityEngine;
// using UnityEngine.SceneManagement;


// // unload previous scene and enable event system in current scene
// // 
// // detect when player exists collider in new scene, and set this as active scene
// // reset item counter

// public class SceneUnloader : MonoBehaviour
// {
//     [SerializeField] private ItemCounter itemCounter;
//     [SerializeField] private OpenDoor openDoor;

    
//     Scene currentScene;
//     string currentSceneName;
//     int currentYear;
//     int previousYear;
//     Scene previousScene;

//     public string previousSceneName;

//     void Start()
//     {
//         previousScene = SceneManager.GetActiveScene();
//         previousSceneName = previousScene.name;
//         previousYear = int.Parse(currentSceneName.Substring(0,4));
//     }

//     public string GetCurrentSceneName()
//     {
//         // if it's currently toronto
//         if ((previousSceneName.Substring(previousSceneName.Length - 3)) == "Tor")
//         {
//             // Debug.Log("it's getting here");
//             currentYear = currentYear + 1;
//             currentSceneName = currentYear.ToString() + "Van";
//             return currentSceneName;

//         // if its current vancouver
//         } 
//         else {
//             currentSceneName = currentYear.ToString() + "Tor";
//             return currentSceneName;
//         }
        
//     }


//     private void OnTriggerEnter(Collider other)
//     {
//         SceneManager.UnloadSceneAsync(previousSceneName);
//         GetCurrentSceneName();
//         SceneManager.SetActiveScene(currentScene);
//         // SceneManager.LoadScene(currentSceneName, LoadSceneMode.Additive);
//         openDoor.Invoke("RunCoroutine", 0f);
//         // doorColliderUnloader should be active

//     }

// }