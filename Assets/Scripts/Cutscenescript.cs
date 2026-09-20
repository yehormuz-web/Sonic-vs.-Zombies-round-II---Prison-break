using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class Cutscenescript : MonoBehaviour
{
    public Cutsceneexclusive cutscenecontrols;
    public PlayableDirector director;
    private InputAction skipbutton;
    
    public void pausetimeline()
    {
        director.Pause();
    }
    private void Awake()
    {
        cutscenecontrols = new Cutsceneexclusive();
    }
    private void OnEnable()
    {
        skipbutton = cutscenecontrols.NextDiaulog.Newaction;
        skipbutton.Enable();
        skipbutton.performed+=nextDiaulog;
    }
    private void nextDiaulog(InputAction.CallbackContext callback) 
    {
        director.Play();
        Debug.Log("buttonpress");        
    }
    private void Update()
    {

    }
}
