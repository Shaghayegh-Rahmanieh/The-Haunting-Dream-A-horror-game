using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cam;
    public Transform playerRoot;
    public float sensitivity = 2f;
    
    float rotX;
    float rotY;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        
        rotX -= mouseY;
        rotY += mouseX;
        
        rotX = Mathf.Clamp(rotX, -90f, 90f);
        
        playerRoot.rotation = Quaternion.Euler(0f, rotY, 0f);
        cam.rotation = Quaternion.Euler(rotX, rotY, 0f);
        

    }
}
