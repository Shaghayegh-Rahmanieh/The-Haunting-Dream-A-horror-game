using UnityEngine;
using TMPro;

public class TeddyController : MonoBehaviour
{
    public TMP_Text interactionText; 
    public GameObject teddytalk; 
    private bool isPlayerInTrigger = false;
    private Stage4 stage4; 
    private bool hasTimelineStarted = false; 

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

        if (teddytalk == null)
        {
            Debug.LogError("teddytalk is not assigned in Inspector!");
        }

        // Refrence to Stage4
        stage4 = FindObjectOfType<Stage4>();
        if (stage4 == null)
        {
            Debug.LogError("Stage4 script not found in the scene!");
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && !hasTimelineStarted)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (teddytalk != null && stage4 != null)
                {
                    teddytalk.SetActive(true); 
                    stage4.StartTimeline(); 
                    hasTimelineStarted = true; 
                }
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
            }
        }
    }
}