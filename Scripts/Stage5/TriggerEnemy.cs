using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    public GameObject gameOver;

    void Start()
    {
        if (gameOver == null)
        {
            Debug.LogError("gameOver reference not set on " + gameObject.name);
        }

        if (gameOver != null && gameOver.activeSelf)
        {
            gameOver.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player entered trigger!");
            if (gameOver != null && !gameOver.activeSelf)
            {
                gameOver.SetActive(true);
                Debug.Log("GameOver activated.");
            }
            gameObject.SetActive(false);
        }
    }
}