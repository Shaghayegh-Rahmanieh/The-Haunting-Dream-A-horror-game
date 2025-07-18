using UnityEngine;

public class BgSound : MonoBehaviour
{
        public AudioSource BackgroundSound;

      private void OnTriggerEnter(Collider other)
    {
       BackgroundSound.Play();
    }
}
