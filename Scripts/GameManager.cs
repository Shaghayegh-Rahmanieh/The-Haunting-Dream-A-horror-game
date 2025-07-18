
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] stages; 
    private int currentStageIndex = 0; 
    public TriggerDoor lockedDoor;
    private bool isStageInitialized = false; 
    private bool isGameCompleted = false; 

    void Start()
    {
        PlayerPrefs.DeleteAll(); 
        Debug.Log("PlayerPrefs reset for testing.");

        currentStageIndex = PlayerPrefs.GetInt("CurrentStage", 0);
        Debug.Log($"Loaded currentStageIndex from PlayerPrefs: {currentStageIndex}");

        if (stages == null || stages.Length == 0)
        {
            Debug.LogError("Stages array is null or empty! Please assign stages in Inspector.");
            return;
        }

  
        if (currentStageIndex >= stages.Length || currentStageIndex < 0)
        {
            Debug.LogWarning($"Invalid currentStageIndex: {currentStageIndex}. Resetting to 0.");
            currentStageIndex = 0;
            PlayerPrefs.SetInt("CurrentStage", currentStageIndex);
            PlayerPrefs.Save();
        }

        Debug.Log($"Stages array count: {stages.Length}");
        for (int i = 0; i < stages.Length; i++)
        {
            Debug.Log($"Stage {i}: {(stages[i] != null ? stages[i].name : "null")}");
        }

        PlayerPrefs.Save();
        UpdateStage();
        if (lockedDoor != null)
        {
            lockedDoor.LockDoor(); 
            Debug.Log("Door " + lockedDoor.gameObject.name + " is locked.");
        }
        isStageInitialized = true; 
        Debug.Log($"Initial stage activation check: Starting with Stage {stages[currentStageIndex].name}");
    }

    void UpdateStage()
    {
       
        Debug.Log($"Updating stage, currentStageIndex: {currentStageIndex}, stages length: {stages.Length}");
        if (stages == null || stages.Length == 0)
        {
            Debug.LogError("Stages array is null or empty during UpdateStage!");
            return;
        }

        foreach (GameObject stage in stages)
        {
            if (stage != null && stage != stages[currentStageIndex])
            {
                stage.SetActive(false);
                Debug.Log($"Deactivated stage: {stage.name}");
            }
        }

        if (currentStageIndex >= 0 && currentStageIndex < stages.Length && stages[currentStageIndex] != null)
        {
            stages[currentStageIndex].SetActive(true);
            Stage3 stage3 = stages[currentStageIndex].GetComponent<Stage3>();
            if (stage3 != null)
            {
                stage3.ActivateStage(); 
                Debug.Log($"Activated Stage3 and triggered light color change.");
            }
            else
            {
                Debug.LogWarning("Stage3 component not found on " + stages[currentStageIndex].name);
            }
        }
        else
        {
            Debug.LogError("Failed to activate stage!");
            Debug.LogWarning("No valid stage to activate! Resetting to Stage 0.");
            currentStageIndex = 0;
            PlayerPrefs.SetInt("CurrentStage", currentStageIndex);
            PlayerPrefs.Save();
            if (stages.Length > 0 && stages[0] != null)
            {
                stages[0].SetActive(true);
                Debug.Log("Reset to Stage 0: " + stages[0].name);
            }
        }
    }

    public void StageCompleted()
    {
        if (stages == null || stages.Length == 0)
        {
            Debug.LogError("Cannot complete stage: Stages array is null or empty!");
            return;
        }

        if (!isStageInitialized)
        {
            Debug.LogWarning("StageCompleted called before initialization! Ignoring.");
            return;
        }

        if (!isGameCompleted) 
        {
            currentStageIndex++;
            Debug.Log($"Stage completed, advancing to index: {currentStageIndex}");
            if (currentStageIndex >= stages.Length)
            {
                Debug.Log("All stages completed! Game finished.");
                isGameCompleted = true; 
                return; 
            }
            PlayerPrefs.SetInt("CurrentStage", currentStageIndex);
            PlayerPrefs.Save(); 
            UpdateStage();
        }
    }
}