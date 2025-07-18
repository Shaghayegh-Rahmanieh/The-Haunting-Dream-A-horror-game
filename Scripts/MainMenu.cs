using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   void Start()
   {

          Cursor.lockState = CursorLockMode.None; // Free cursor
          Cursor.visible = true; // show cursor
   }
   public void Play()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }

   public void Quit()
   {
    Application.Quit();
    Debug.Log("Player Has Quit The Game");

   }
}
