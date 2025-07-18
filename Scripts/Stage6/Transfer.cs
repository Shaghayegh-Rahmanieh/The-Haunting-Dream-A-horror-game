using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Transfer : MonoBehaviour
{
    public GameObject placeBackroom;
    public GameObject house;
    public GameObject ghost;

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            placeBackroom.SetActive(true);
            ghost.SetActive(true);
            house.SetActive(false);
         
        }
    }
     
}
