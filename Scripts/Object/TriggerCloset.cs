using UnityEngine;
using TMPro; 

public class TriggerCloset : MonoBehaviour
{
    private Animator _closetAnimator;
    private AudioSource _audioSource;

    public AudioClip openSound;
    public AudioClip closeSound;

    public TMP_Text interactionText; 

    private bool isPlayerInTrigger = false;
    private bool isClosetOpen = false;

    void Start()
    {
        _closetAnimator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        if (interactionText != null)
        {
            interactionText.enabled = false; 
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && !isClosetOpen && Input.GetKeyDown(KeyCode.E))
        {
            _closetAnimator.SetTrigger("Open");
            _audioSource.PlayOneShot(openSound);
            isClosetOpen = true;

            if (interactionText != null)
                interactionText.enabled = false; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;

            if (!isClosetOpen && interactionText != null)
                interactionText.enabled = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;

            if (interactionText != null)
                interactionText.enabled = false; 

            if (isClosetOpen)
            {
                _closetAnimator.SetTrigger("Close");
                _audioSource.PlayOneShot(closeSound);
                isClosetOpen = false;
            }
        }
    }
}