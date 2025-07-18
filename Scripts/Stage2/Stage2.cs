using UnityEngine;
using TMPro; 

public class Stage2 : MonoBehaviour
{
    public TriggerDoor lockedDoor; 
    public bool doorIsLocked = false;
    public GameObject knockTrigger; 
    public AudioSource knockSound; 
    private bool isStageCompleted = false;

    void Start()
    {
   
        if (lockedDoor != null)
        {
            lockedDoor.LockDoor();
            Debug.Log($"Door {lockedDoor.gameObject.name} locked for this stage.");
        }
        else
        {
            Debug.LogWarning("No locked door assigned to this stage!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            knockSound.Play();
        }
    }

    public void CompleteStage()
    {
        if (!isStageCompleted)
        {
            isStageCompleted = true;
            if (lockedDoor != null)
            {
                lockedDoor.UnlockDoor();
                Debug.Log($"Door {lockedDoor.gameObject.name} unlocked after completing Stage2.");
            }
            GameObject.FindObjectOfType<GameManager>().StageCompleted(); 
            Debug.Log("Stage2 completed!");
        }
    }
}