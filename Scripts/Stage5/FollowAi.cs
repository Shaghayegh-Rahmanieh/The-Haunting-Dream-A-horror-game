using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowAi : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;
    public Animator aiAnim;
    public Light flashLight; //Refrence
    public AudioSource soundStop;
    public AudioSource soundMove;

    Vector3 dest;

    void Start()
    {
       
        if (ai == null)
        {
            ai = GetComponent<NavMeshAgent>();
            if (ai == null)
            {
                Debug.LogError("NavMeshAgent not found on " + gameObject.name);
            }
        }

        if (flashLight == null)
        {
            Debug.LogError("FlashLight reference not set on " + gameObject.name);
        }

        if (soundMove == null)
        {
            Debug.LogError("soundMove AudioSource is not assigned on " + gameObject.name);
        }
        if (soundStop == null)
        {
            Debug.LogError("soundStop AudioSource is not assigned on " + gameObject.name);
        }
    }

    void Update()
    {
        if (ai != null && player != null && ai.isOnNavMesh)
        {
            dest = player.position;
            bool isInLight = flashLight != null && flashLight.enabled && IsInFlashlightRange();

            if (!isInLight)
            {
                // Move
                ai.SetDestination(dest);
                aiAnim.SetTrigger("jog");

                if (soundStop != null && soundStop.isPlaying)
                {
                    soundStop.Stop();
                }
                if (soundMove != null && !soundMove.isPlaying)
                {
                    soundMove.Play();
                }
            }
            else
            {
                // Sotp
                ai.SetDestination(transform.position);
                aiAnim.SetTrigger("idle");

                if (soundMove != null && soundMove.isPlaying)
                {
                    soundMove.Stop();
                }
                if (soundStop != null && !soundStop.isPlaying)
                {
                    soundStop.Play();
                }
            }
        }
    }

    bool IsInFlashlightRange()
    {
        if (flashLight == null) return false;

        Vector3 directionToEnemy = transform.position - flashLight.transform.position;
        float angle = Vector3.Angle(directionToEnemy, flashLight.transform.forward);

        if (angle < flashLight.spotAngle * 0.5f && directionToEnemy.magnitude <= flashLight.range)
        {
            return true;
        }
        return false;
    }
}