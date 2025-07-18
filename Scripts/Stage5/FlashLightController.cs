using UnityEngine;
using TMPro;

public class FlashLightController : MonoBehaviour
{
    public TMP_Text interactionText; 
    public AudioClip pickupSound; 
    public GameObject objectToActivate; 
    private AudioSource audioSource;
    private bool isPlayerInTrigger = false;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (interactionText != null)
        {
            interactionText.enabled = false;
        }
        else
        {
            Debug.LogWarning("interactionText is not assigned in Inspector!");
        }

        if (audioSource != null)
        {
            audioSource.volume = 1.0f;
            audioSource.playOnAwake = false;
        }
        else
        {
            Debug.LogWarning("AudioSource not set for FlashlightPickup on " + gameObject.name);
        }

        if (pickupSound == null)
        {
            Debug.LogWarning("pickupSound not set for FlashlightPickup on " + gameObject.name);
        }

        if (objectToActivate == null)
        {
            Debug.LogWarning("objectToActivate is not assigned in Inspector!");
        }
        else
        {
            objectToActivate.SetActive(false); 
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            if (interactionText != null)
            {
                interactionText.text = "Press [F] to Pick Up Flashlight";
                interactionText.enabled = true;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (pickupSound != null && audioSource != null)
                {
                    GameObject soundObject = new GameObject("TempAudio");
                    AudioSource tempAudio = soundObject.AddComponent<AudioSource>();
                    tempAudio.volume = 1.0f;
                    tempAudio.PlayOneShot(pickupSound);
                    Destroy(soundObject, pickupSound.length);
                }
                else
                {
                    Debug.LogWarning("Failed to play sound");
                }

                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(true); 
                }

                Destroy(gameObject);
                if (interactionText != null)
                {
                    interactionText.enabled = false;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && interactionText != null)
        {
            isPlayerInTrigger = false;
            interactionText.enabled = false;
        }
    }
}