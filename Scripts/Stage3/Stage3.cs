using UnityEngine;

public class Stage3 : MonoBehaviour
{
    public Light[] lights; 
    public GameObject threat; 
    public AudioSource Horrorsound; 
    private bool isStageCompleted = false; 
    private bool isThreatTriggered = false; 
    private bool soundPlayed = false; 

    void Start()
    {

        if (lights == null || lights.Length == 0)
        {
            Debug.LogWarning("Lights array is null or empty! Please assign lights in Inspector.");
            return;
        }

        gameObject.SetActive(false);
        Debug.Log("Stage3 deactivated, waiting for GameManager.");
    }

    public void ActivateStage()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Debug.Log("Stage3 activated successfully.");
        }
        else
        {
            Debug.LogWarning("Stage3 was already active!");
        }
        ChangeLightColors(); // change color B81B1B
        ActivateThreat(); 
    }

   
    private void ChangeLightColors()
    {
        if (lights == null || lights.Length == 0)
        {
            Debug.LogError("No lights assigned to change colors in Stage3!");
            return;
        }

        Color targetColor = new Color(0.722f, 0.106f, 0.106f); //B81B1B
        foreach (Light light in lights)
        {
            if (light != null)
            {
                light.color = targetColor;
                Debug.Log($"Changed light {light.name} color to {targetColor} in Stage3");
            }
            else
            {
                Debug.LogWarning("Null light reference found in lights array!");
            }
        }
    }

    private void ActivateThreat()
    {
        if (threat != null)
        {
            threat.SetActive(true);
            Debug.Log($"Threat {threat.name} activated in Stage3.");
        }
        else
        {
            Debug.LogWarning("Threat GameObject is not assigned in Inspector!");
        }
    }

    public void SetThreatTriggered(bool value)
    {
        isThreatTriggered = value;
        if (isThreatTriggered && !isStageCompleted && !soundPlayed)
        {
            TurnLightsWhite(); 
            PlaySound(); 
        }
    }

    private void TurnLightsWhite()
    {
        if (lights != null && lights.Length > 0)
        {
            foreach (Light light in lights)
            {
                if (light != null)
                {
                    light.color = Color.white;
                    Debug.Log($"Changed light {light.name} color to white before sound.");
                }
            }
        }
        else
        {
            Debug.LogWarning("No lights assigned to change to white!");
        }
    }

    private void PlaySound()
    {
        if (Horrorsound != null && Horrorsound.clip != null)
        {
            Horrorsound.Play();
            soundPlayed = true;
            Debug.Log("Horror sound started playing in Stage3.");
        }
        else
        {
            Debug.LogError("Horrorsound or its AudioClip is not assigned in Stage3!");
        }
    }

    private void CheckCompletion()
    {
        if (!isStageCompleted && isThreatTriggered && soundPlayed)
        {
            if (Horrorsound != null && !Horrorsound.isPlaying && threat != null && !threat.activeSelf)
            {
                isStageCompleted = true;
                Debug.Log("Stage3 completed! Threat deactivated.");
                GameObject.FindObjectOfType<GameManager>()?.StageCompleted(); 
            }
        }
    }

    void Update()
    {
        CheckCompletion();
    }
}