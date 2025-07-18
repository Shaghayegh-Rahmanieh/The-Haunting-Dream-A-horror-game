using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage4 : MonoBehaviour
{
    private bool isStageCompleted = false; 
    private bool isTimelinePlaying = false; 
    private float timer = 0f; 
    public Camera mainCamera; // Refrence to main camera
    public TriggerDoor lockedDoor; 


    void Start()
    {
        gameObject.SetActive(false);
        Debug.Log("Stage4 deactivated, waiting for GameManager.");

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

    public void ActivateStage()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Debug.Log("Stage4 activated successfully.");
        }
        else
        {
            Debug.LogWarning("Stage4 was already active!");
        }
    }

    public void StartTimeline()
    {
        isTimelinePlaying = true;
        timer = 0f;
        Debug.Log("Timeline started in Stage4.");
    }

    void Update()
    {
        if (isTimelinePlaying && !isStageCompleted)
        {
            timer += Time.deltaTime;
            if (timer >= 14f) 
            {
                 mainCamera.enabled = false;
                 Debug.Log("Main Camera disabled before scene transition.");
                isTimelinePlaying = false;
                isStageCompleted = true;
                Debug.Log("Stage4 completed!");
                SceneManager.LoadScene("TeddyScene");
                GameObject.FindObjectOfType<GameManager>()?.StageCompleted(); 
               
            }
        }
    }
}