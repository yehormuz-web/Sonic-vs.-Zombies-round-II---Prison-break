using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class Cutscenescript : MonoBehaviour
{
    public PlayableDirector director;
    
    public void pausetimeline()
    {
        director.Pause();
    }
    private void Update()
    {

    }
}
