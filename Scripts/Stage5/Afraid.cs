using UnityEngine;

public class Afraid : MonoBehaviour
{
     public GameObject afraid; 
    public GameObject firstPersonController; 

    void Start()
    {
         if (afraid == null)
        {
            Debug.LogError("Afraid reference is not assigned!");
            return;
        }
        afraid.SetActive(true);
        Animator animator = afraid.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on Afraid!");
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
        if (afraid != null) afraid.SetActive(false);
        if (firstPersonController != null) firstPersonController.SetActive(true);
    }
}
