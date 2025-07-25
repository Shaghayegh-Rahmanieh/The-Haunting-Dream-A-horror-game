using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerRoot;
    public float speed = 5f;


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = playerRoot.right * x + playerRoot.forward * z;
        controller.Move(move * speed * Time.deltaTime);

       
    }
}
