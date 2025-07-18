using UnityEngine;

public class GhostSection : MonoBehaviour
{
   public static bool isTriggerGhost=false;
  

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            isTriggerGhost=true;

         
        }
    }

}
