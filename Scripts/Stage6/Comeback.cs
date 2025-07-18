using UnityEngine;

public class Comeback : MonoBehaviour
{
     public GameObject comeback; 
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

        if (comeback == null)
        {
            Debug.LogError("Come Back reference is not assigned!");
            return;
        }

        comeback.SetActive(true);
        Animator animator = comeback.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on comeback!");
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
        if (comeback != null) comeback.SetActive(false);
        if (firstPersonController != null) firstPersonController.SetActive(true);
        if (gameManager != null) gameManager.StageCompleted(); 
    }
}
