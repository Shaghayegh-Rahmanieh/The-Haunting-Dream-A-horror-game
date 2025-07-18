using UnityEngine;
using TMPro; 

public class KeyPickup : MonoBehaviour
{
    private Stage1 stage1; // Refrence GameManager
    public TMP_Text pickupText;
    public AudioClip pickupSound; 
    private AudioSource audioSource;

    void Start()
    {
        stage1 = FindObjectOfType<Stage1>(); // found Stage1 in Scene
        audioSource = gameObject.GetComponent<AudioSource>(); // Check AudioSource 
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); 
        }
        if (pickupText != null)
        {
            pickupText.enabled = false; // Disabled text in start
        }

        if (audioSource != null)
        {
            audioSource.volume = 1.0f; 
            audioSource.playOnAwake = false; 
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickupText != null)
            {
                pickupText.text = "Press [F] To Pick Up";
                pickupText.enabled = true; 
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (stage1 != null)
                {
                    stage1.AddKey(); 
                }
                if (pickupSound != null && audioSource != null)
                {
                    // Add a GameObject for playing sound
                    GameObject soundObject = new GameObject("TempAudio");
                    AudioSource tempAudio = soundObject.AddComponent<AudioSource>();
                    tempAudio.volume = 1.0f;
                    tempAudio.PlayOneShot(pickupSound);
                    // Destroy the object after finished sound
                    Object.Destroy(soundObject, pickupSound.length);
                }
                else
                {
                    Debug.LogWarning("Failed to play sound");
                }
                gameObject.SetActive(false); // Disabled key after pick up
                Debug.Log("Key picked up!");
                if (pickupText != null)
                {
                    pickupText.enabled = false; 
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && pickupText != null)
        {
            pickupText.enabled = false; 
        }
    }
}