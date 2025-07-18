using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TiggerKeypad : MonoBehaviour
{
    public TMP_Text interactionText;
    public GameObject EnterKeypadCanvas; // Refrence to keypad canvas
    private bool isPlayerInTrigger = false;
    private bool isCanvasActive = false; 
    private bool isSuccess = false; 

    public TMP_InputField txtholder;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button0;
    public GameObject buttonClear;
    public GameObject buttonEnter;

    private AudioSource audioSource; 
    public AudioClip buttonClickSound;
    public AudioClip successSound; 
    public AudioClip failedSound; 

    void Start()
    {
        interactionText.enabled = false;
        txtholder.placeholder.GetComponent<TextMeshProUGUI>().color = Color.white;

        if (EnterKeypadCanvas != null)
        {
            EnterKeypadCanvas.SetActive(false); // Canvas must be disabled in start
        }
        // Event system in Scene
        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
     
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && !isSuccess && Input.GetKeyDown(KeyCode.F))
        {
            isCanvasActive = !isCanvasActive; 
            if (EnterKeypadCanvas != null)
            {
                EnterKeypadCanvas.SetActive(isCanvasActive);
                if (isCanvasActive)
                {
                    Cursor.lockState = CursorLockMode.None; // Free cursor
                    Cursor.visible = true; // show cursor
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked; // locked cursor
                    Cursor.visible = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            if (!isSuccess)
            {
                interactionText.enabled = true;
            }
            else
            {
                interactionText.enabled = false; 
                Debug.Log("Success achieved, no further interaction.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;

            if (interactionText != null)
                interactionText.enabled = false;

            if (EnterKeypadCanvas != null && isCanvasActive)
            {
                EnterKeypadCanvas.SetActive(false); // Diabled canvas with exit
                isCanvasActive = false; 
                Cursor.lockState = CursorLockMode.Locked; // locked corsor with exit
                Cursor.visible = false;
                Debug.Log("EnterKeypadCanvas deactivated on exit.");
            }
        }
    }

    public void btn1()
    {
        txtholder.text = txtholder.text + "1";
        PlayButtonClickSound();
    }

    public void btn2()
    {
        txtholder.text = txtholder.text + "2";
        PlayButtonClickSound();
    }

    public void btn3()
    {
        txtholder.text = txtholder.text + "3";
        PlayButtonClickSound();
    }

    public void btn4()
    {
        txtholder.text = txtholder.text + "4";
        PlayButtonClickSound();
    }

    public void btn5()
    {
        txtholder.text = txtholder.text + "5";
        PlayButtonClickSound();
    }

    public void btn6()
    {
        txtholder.text = txtholder.text + "6";
        PlayButtonClickSound();
    }

    public void btn7()
    {
        txtholder.text = txtholder.text + "7";
        PlayButtonClickSound();
    }

    public void btn8()
    {
        txtholder.text = txtholder.text + "8";
        PlayButtonClickSound();
    }

    public void btn9()
    {
        txtholder.text = txtholder.text + "9";
        PlayButtonClickSound();
    }

    public void btn0()
    {
        txtholder.text = txtholder.text + "0";
        PlayButtonClickSound();
    }

    public void btnClear()
    {
        txtholder.text = null;
        PlayButtonClickSound();
    }

    public void btnEnter()
    {
        if (txtholder.text == "3825")
        {
            txtholder.text = "Success";
            PlaySuccessSound();
            isSuccess = true; 
            if (EnterKeypadCanvas != null && isCanvasActive)
            {
                EnterKeypadCanvas.SetActive(false); // exit canvas after sucess
                isCanvasActive = false;
                Cursor.lockState = CursorLockMode.Locked; // locked cursor
                Cursor.visible = false;
                Debug.Log("Canvas closed after success.");
            }
         
            Stage2 stage2 = FindObjectOfType<Stage2>();
            if (stage2 != null)
            {
                stage2.CompleteStage();
                Debug.Log("Stage2 completed.");
            }
            else
            {
                Debug.LogWarning("Stage2 script not found in Scene!");
            }
        }
        else
        {
            txtholder.text = "Failed";
            PlayFailedSound();
            Invoke("ClearFailedText", 1.0f);
        }
    }

    private void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
            Debug.Log("Button click sound played.");
        }
        else
        {
            Debug.LogWarning("AudioSource or buttonClickSound is missing!");
        }
    }

    private void PlaySuccessSound()
    {
        if (audioSource != null && successSound != null)
        {
            audioSource.PlayOneShot(successSound);
            Debug.Log("Success sound played.");
        }
        else
        {
            Debug.LogWarning("AudioSource or successSound is missing!");
        }
    }

    private void PlayFailedSound()
    {
        if (audioSource != null && failedSound != null)
        {
            audioSource.PlayOneShot(failedSound);
            Debug.Log("Failed sound played.");
        }
        else
        {
            Debug.LogWarning("AudioSource or failedSound is missing!");
        }
    }

    private void ClearFailedText()
    {
        if (txtholder.text == "Failed")
        {
            txtholder.text = ""; 
            txtholder.placeholder.GetComponent<TextMeshProUGUI>().color = Color.black; 
            Debug.Log("Failed text cleared, ready for new input.");
        }
    }
}