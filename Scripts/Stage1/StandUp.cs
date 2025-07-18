using UnityEngine;

public class StandUp : MonoBehaviour
{
    public GameObject standUp; 
    public GameObject firstPersonController; 
    private GameManager gameManager; 

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
            return;
        }

        if (standUp == null)
        {
            Debug.LogError("StandUp reference is not assigned!");
            return;
        }

        standUp.SetActive(true);
        Animator animator = standUp.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on StandUp!");
            return;
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length > 0 ? stateInfo.length : 2f;
        Invoke("OnStageCompleted", animationLength);

        if (firstPersonController != null)
        {
            firstPersonController.SetActive(false);
        }
        else
        {
            Debug.LogError("FirstPersonController reference is not assigned!");
        }
    }

    void OnStageCompleted()
    {
        if (standUp != null) standUp.SetActive(false);
        if (firstPersonController != null) firstPersonController.SetActive(true);
        if (gameManager != null) gameManager.StageCompleted(); 
    }
}
