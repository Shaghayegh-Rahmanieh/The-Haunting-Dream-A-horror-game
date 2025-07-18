using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TeddyWin : MonoBehaviour
{
     public TMP_Text interactionText; 
    private bool isPlayerInTrigger = false;

    void Start()
    {
        if (interactionText != null)
        {
            interactionText.enabled = false;
            Debug.Log("interactionText initialized and disabled.");
        }
        else
        {
            Debug.LogWarning("interactionText is not assigned in Inspector!");
        }
        
    }

    void Update()
    {
        if (isPlayerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            if (interactionText != null)
            {
                interactionText.enabled = true;
                Debug.Log("interactionText enabled when player entered trigger.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (interactionText != null)
            {
                interactionText.enabled = false;
                Debug.Log("interactionText disabled when player exited trigger.");
            }
        }
    }
}
