using UnityEngine;
using TMPro; 

public class TriggerDrawer : MonoBehaviour
{
    private Animator _drawerAnimator;
    private AudioSource _audioSource;

    public AudioClip openSound;
    public AudioClip closeSound;

    public TMP_Text interactionText; 

    private bool isPlayerInTrigger = false;
    private bool isDrawerOpen = false;

    void Start()
    {
        _drawerAnimator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        if (interactionText != null)
        {
            interactionText.enabled = false; 
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && !isDrawerOpen && Input.GetKeyDown(KeyCode.E))
        {
            _drawerAnimator.SetTrigger("Open");
            _audioSource.PlayOneShot(openSound);
            isDrawerOpen = true;

            if (interactionText != null)
                interactionText.enabled = false; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;

            if (!isDrawerOpen && interactionText != null)
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

            if (isDrawerOpen)
            {
                _drawerAnimator.SetTrigger("Close");
                _audioSource.PlayOneShot(closeSound);
                isDrawerOpen = false;
            }
        }
    }
}