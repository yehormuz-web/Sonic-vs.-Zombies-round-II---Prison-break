using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;

public class QTE : MonoBehaviour
{
    public PlayableDirector failure_director;
    public PlayableDirector success_director;
    public float timetoclick;
    public float timer=-1;
    public PlayableDirector Original_TimeLine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void StartTimer() 
    {
        timer = 0;
    }
    void Update()
    {
        if (timer != -1)
        {
            timer += Time.deltaTime;
            if (timer > timetoclick)
            {
                Original_TimeLine.Stop();
                failure_director.Play();
            }
        }
    }
    public void success_QTE() 
    {
        Original_TimeLine.Stop();
        success_director.Play(); 
    }
}
