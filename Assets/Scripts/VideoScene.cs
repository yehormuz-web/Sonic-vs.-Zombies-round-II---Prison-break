using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScene : MonoBehaviour
{   
    public VideoPlayer player;
    public string LeveLtoloaD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void onvidofinished(VideoPlayer VSP)
    {
        SceneManager.LoadScene(LeveLtoloaD);
        player.Stop();
    }
    void Start()
    {
        player.loopPointReached += onvidofinished;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
