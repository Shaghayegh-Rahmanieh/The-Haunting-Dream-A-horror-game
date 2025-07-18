using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EndKey : MonoBehaviour
{
   private bool canPressKey = false;

    void Start()
    {
        Invoke("EnableKeyPress", 50f);
    }

    void Update()
    {
        if (canPressKey && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    private void EnableKeyPress()
    {
        canPressKey = true;
    }

}
