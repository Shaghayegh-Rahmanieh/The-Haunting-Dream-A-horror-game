using UnityEngine;

public class TriggerThreat : MonoBehaviour
{
    public GameObject Threat;
    private Stage3 stage3; //Refrence to Stage3

    void Start()
    {
        stage3 = FindObjectOfType<Stage3>();
        if (stage3 == null)
        {
            Debug.LogWarning("Stage3 script not found in Scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) 
        {
            if (Threat != null && Threat.activeSelf) 
            {
                if (stage3 != null)
                {
                    stage3.SetThreatTriggered(true); 
                }
                else
                {
                    Debug.LogWarning("Stage3 reference not found!");
                }

               
                Threat.SetActive(false);
                Debug.Log($"Threat {Threat.name} deactivated.");
            }
            else if (Threat != null)
            {
                Debug.LogWarning("Threat is not active!");
            }
            else
            {
                Debug.LogWarning("Threat GameObject is not assigned!");
            }
        }
        else
        {
            Debug.LogWarning($"Object {other.gameObject.name} is not tagged as Player!");
        }
    }
}