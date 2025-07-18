using UnityEngine;
using TMPro;

public class TriggerKnock : MonoBehaviour
{
   public AudioSource knockSound;
   public TMP_Text interactionText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && knockSound != null && !knockSound.isPlaying)
        {
            knockSound.Play();
            Debug.Log("Knock sound started.");
            interactionText.text="The sound is coming from the exit door!";
        }
    }

}
