using UnityEngine;
using UnityEngine.Playables;

public class MomThreat : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject timelineTrigger;

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           timelineTrigger.SetActive(true);
           Invoke("StopTimeLine", 7f);
         
        }
    }
    void StopTimeLine()
    {
        gameObject.SetActive(false);
    }
}
