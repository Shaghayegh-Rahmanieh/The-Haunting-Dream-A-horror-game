using UnityEngine;

public class GhostAi : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent ai;
    public Transform player;
    public Animator aiAnim;
    public AudioSource soundMove;
    public CameraShake cameraShake;
    public GameObject TimelineEnd;
    Vector3 dest;

    void Start()
    {
        if (ai != null && !ai.isOnNavMesh)
        {
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(transform.position, out hit, 5.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                ai.Warp(hit.position);
            }
         
        }
   
    }

    void Update()
    {
        if (ai != null && ai.isOnNavMesh)
        {
            if (GhostSection.isTriggerGhost)
            {
                dest = player.position;
                ai.destination = dest;
                ai.isStopped = false;
                if (!soundMove.isPlaying) 
                {
                    soundMove.Play();
                }
                if (cameraShake != null)
                {
                    cameraShake.StartShake(); 
                }
                aiAnim.ResetTrigger("idle"); 
                aiAnim.SetTrigger("jog");
            }
            else
            {
                ai.isStopped = true; 
                if (soundMove.isPlaying)
                {
                    soundMove.Stop();
                }
                if (cameraShake != null)
                {
                    cameraShake.StopShake(); 
                }
                aiAnim.ResetTrigger("jog"); 
                aiAnim.SetTrigger("idle");
            }
        }
       
    }

    
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            gameObject.SetActive(false);
            soundMove.Stop();
            TimelineEnd.SetActive(true);
         
        }
    }

}