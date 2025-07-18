using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject character;
    public GameObject fpController;
    public GameObject PlayAgain;
    public GameObject chAmimation;
    private Animator animator;
    

    void Start()
    {
        if (character != null)
        {
            character.SetActive(false);
        }

        if (fpController != null)
        {
            fpController.SetActive(false);
        }

        animator = GetComponent<Animator>();

        if (PlayAgain != null)
        {
            PlayAgain.SetActive(false);
        }

        if (animator != null)
        {
            animator.SetTrigger("scream");
        }

        Invoke("ActivatePlayAgain", 2.26f);
    }

    void ActivatePlayAgain()
    {
        if (chAmimation != null)
        {
            chAmimation.SetActive(false);
        }

        if (PlayAgain != null)
        {
            PlayAgain.SetActive(true);
        }
    }
}