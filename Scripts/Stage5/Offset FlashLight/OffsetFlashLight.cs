using UnityEngine;

public class OffsetFlashLight : MonoBehaviour
{
    private Vector3 OffsetVector3;
    public GameObject FollowCam;
    [SerializeField] private float MoveSpeed=13f;
    public Light FlashLight;
    private bool FlashLightIsOn=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OffsetVector3=transform.position-FollowCam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=FollowCam.transform.position+OffsetVector3;
        transform.rotation=Quaternion.Slerp(transform.rotation, FollowCam.transform.rotation, MoveSpeed* Time.deltaTime);
        
            FlashLight.enabled=true;
            FlashLightIsOn=true;
        
    }
}
