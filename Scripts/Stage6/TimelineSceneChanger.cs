using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineSceneChanger : MonoBehaviour
{
    public PlayableDirector director;
    public AudioSource bgAudio;


    void Start()
    {
        bgAudio.Stop();
        director.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}