using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class Notescript : MonoBehaviour
{
    private Playercontrols playercontrols;
    public PlayableDirector director;
    public bool nexttonote;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        playercontrols = new Playercontrols();
    }
    private void OnEnable()
    {
        playercontrols.Enable();
        playercontrols.Interact.Interact.performed += ctx => readnote();
    }
    private void OnDisable()
    {
        playercontrols.Disable();
        playercontrols.Interact.Interact.performed -= ctx => readnote();
    }
    public void readnote()
    {
        if (nexttonote) {
        director.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nexttonote = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nexttonote = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
