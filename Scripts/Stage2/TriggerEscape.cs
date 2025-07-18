using UnityEngine;
using UnityEngine.Playables;

public class TriggerEscape : MonoBehaviour
{
    public AudioSource escapeVoice;
    public GameObject canvasWithTimeline; // Refrence to canvas with timeline
    public GameObject KnockDoor;
    private bool hasPlayed = false; // Not repet sound
    private PlayableDirector playableDirector; //  Refrence to Playable Director

    void Start()
    {
        if (canvasWithTimeline != null)
        {
            playableDirector = canvasWithTimeline.GetComponent<PlayableDirector>();
            if (playableDirector != null)
            {
                playableDirector.stopped += OnTimelineStopped; // Sign event in Start
                Debug.Log("PlayableDirector event registered.");
            }
            else
            {
                Debug.LogError("PlayableDirector not found on Canvas!");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            Debug.Log("Player entered TriggerEscape.");
            KnockDoor.SetActive(false);

            if (canvasWithTimeline != null)
            {
                canvasWithTimeline.SetActive(true); 
                Debug.Log("Canvas activated.");

                if (playableDirector != null && !playableDirector.state.Equals(PlayState.Playing))
                {
                    playableDirector.Play();
                    Debug.Log("Timeline started.");
                    hasPlayed = true; 
                }
                else
                {
                    Debug.LogWarning("Timeline is already playing or PlayableDirector is null.");
                }
            }
        }
    }

    void OnTimelineStopped(PlayableDirector director)
    {
        Debug.Log("Timeline stopped, deactivating escapeTrigger.");
        if (gameObject != null)
        {
            gameObject.SetActive(false);
            Debug.Log("escapeTrigger deactivated.");
        }
        if (canvasWithTimeline != null)
        {
            canvasWithTimeline.SetActive(false); 
        }
        if (escapeVoice != null && escapeVoice.isPlaying)
        {
            escapeVoice.Stop();
            Debug.Log("Escape voice stopped.");
        }
    }

    void OnDestroy()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnTimelineStopped; // Delete event in destroy 
        }
    }
}