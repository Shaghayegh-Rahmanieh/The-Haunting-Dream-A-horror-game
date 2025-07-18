using UnityEngine;

public class StartFollow : MonoBehaviour
{
    public GameObject character; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (character != null)
            {
                character.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Character GameObject is not assigned in the Inspector!");
            }
        }
    }
}