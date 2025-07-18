using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneNextLoad : MonoBehaviour
{
   public void NextScene()
   {
    PlayerPrefs.DeleteAll(); 
    Debug.Log("PlayerPrefs reset for testing.");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
}
