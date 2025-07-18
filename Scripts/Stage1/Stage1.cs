using UnityEngine;

public class Stage1 : MonoBehaviour
{
    public TriggerDoor lockedDoor; 
    private bool isStageCompleted = false;
    private int keyCount = 0; 

    void Start()
    {
        
        keyCount = PlayerPrefs.GetInt("Stage1KeyCount", 0);
        if (lockedDoor != null)
        {
            lockedDoor.LockDoor();
        }
        else
        {
            Debug.LogWarning("No locked door assigned to this stage!");
        }
    }

    // collect keys
    public void AddKey()
    {
        keyCount++;
        PlayerPrefs.SetInt("Stage1KeyCount", keyCount);
        PlayerPrefs.Save();
        Debug.Log("Key collected! Total keys: " + keyCount);
    }

    public bool UseKey()
    {
        if (keyCount > 0)
        {
            keyCount--;
            PlayerPrefs.SetInt("Stage1KeyCount", keyCount);
            PlayerPrefs.Save();
            Debug.Log("Key used! Remaining keys: " + keyCount);
            return true;
        }
        Debug.LogWarning("No keys available!");
        return false;
    }

  
    public int GetKeyCount()
    {
        return keyCount;
    }

  
    public bool CheckKeyAndUnlock()
    {
        if (lockedDoor != null && lockedDoor.IsLocked()) // one key for openning door
        {
            if (UseKey()) 
            {
                lockedDoor.UnlockDoor();
                Debug.Log($"Door {lockedDoor.gameObject.name} unlocked with a key. Remaining keys: " + keyCount);
                CompleteStage(); 
                return true; // sucess
            }
        }
        else if (lockedDoor != null && lockedDoor.IsLocked())
        {
            Debug.LogWarning("Need at least 1 key to unlock the door! Current keys: " + keyCount);
        }
        return false; // failed
    }

  
    public void CompleteStage()
    {
        if (!isStageCompleted)
        {
            isStageCompleted = true;
            if (lockedDoor != null)
            {
                lockedDoor.UnlockDoor(); // unlocked the door
            }
            GameObject.FindObjectOfType<GameManager>().StageCompleted(); // To GameManager
            Debug.Log("Stage completed!");
        }
    }
}