using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.1f; 
    public float shakeMagnitude = 0.2f; 
    private Vector3 originalPosition; 
    private float shakeTimer = 0f; 
    private bool isShaking = false;

    void Start()
    {
        originalPosition = transform.localPosition; 
    }

    void Update()
    {
        if (isShaking && shakeTimer > 0)
        {
            
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPosition;
            isShaking = false;
        }
    }

    public void StartShake()
    {
        isShaking = true;
        shakeTimer = shakeDuration;
    }

    public void StopShake()
    {
        isShaking = false;
        shakeTimer = 0f;
    }
}