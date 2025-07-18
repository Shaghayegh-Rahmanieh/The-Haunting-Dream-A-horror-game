using UnityEngine;
using TMPro; 

public class LockedDoor : MonoBehaviour
{
    private Animator _doorAnimator;
    private AudioSource _audioSource;

    public AudioClip lockedSound; 
    public TMP_Text interactionText; 

    private bool isPlayerInTrigger = false;

    void Start()
    {
        _doorAnimator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        if (interactionText != null)
        {
            interactionText.enabled = false; 
        }
        else
        {
            Debug.LogWarning("interactionText is not assigned in LockedDoor for " + gameObject.name);
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed near locked door: " + gameObject.name);
            _audioSource.PlayOneShot(lockedSound); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            Debug.Log("Player entered trigger for locked door: " + gameObject.name);

            if (interactionText != null)
            {
                interactionText.text = "Door is locked!"; 
                interactionText.enabled = true; 
                Debug.Log("Showing text for locked door: " + gameObject.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            Debug.Log("Player exited trigger for locked door: " + gameObject.name);

            if (interactionText != null)
            {
                interactionText.enabled = false; 
                Debug.Log("Hiding text for locked door: " + gameObject.name);
            }
        }
    }
}