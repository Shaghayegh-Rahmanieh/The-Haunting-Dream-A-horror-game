using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    private bool canPressKey = false;

    void Start()
    {
        Invoke("EnableKeyPress", 3f);
    }

    void Update()
    {
        if (canPressKey && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void EnableKeyPress()
    {
        canPressKey = true;
    }

    public void PlayAgainBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}