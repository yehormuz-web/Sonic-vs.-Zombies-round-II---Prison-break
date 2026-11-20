using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ZombiefierScript : MonoBehaviour
{
    public Transform point1transformation;
    public float time_wait;
    public float timer;
    public Transform point2middletransformation;
    public Transform point3transformation;
    public GameObject ringthrow_attack;
    public GameObject Zombiefier;
    public int loop_tracker;
    public Sprite SpriteSwitch;
    public Sprite SpriteLoopToOriginal;

    public int health;
    public TextMeshProUGUI lifetext;
    void Start()
    {
        
    }


    void Update()
    {
        

        timer += Time.deltaTime;
        if (timer > time_wait)
        {
            if (loop_tracker == 0) 
            {
                Zombiefier.transform.position = point1transformation.position; 
                loop_tracker += 1;
                timer = 0;
                Zombiefier.GetComponent<SpriteRenderer>().sprite = SpriteLoopToOriginal;
            }
            else if (loop_tracker == 1) 
            { 
                Zombiefier.transform.position = point2middletransformation.position; 
                Zombiefier.GetComponent<SpriteRenderer>().sprite=SpriteSwitch;
                loop_tracker += 1; 
                timer = 0; 
            }
            else if (loop_tracker == 2) 
            { 
                Zombiefier.transform.position = point3transformation.position;
                loop_tracker += 1; 
                timer = 0; 
                Zombiefier.GetComponent<SpriteRenderer>().sprite = SpriteLoopToOriginal;
            }
            else if (loop_tracker == 3) 
            { 
                Zombiefier.transform.position = point2middletransformation.position; 
                Zombiefier.GetComponent<SpriteRenderer>().sprite=SpriteSwitch;
                Instantiate(ringthrow_attack, Zombiefier.transform);
                Instantiate(ringthrow_attack, Zombiefier.transform.position,new Quaternion(0,180,0,0),this.transform);
                loop_tracker = 0; timer = 0; 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health -= 1;
            lifetext.text=health.ToString();
            if (health == 0)
            {
                die();
            }
        }
    }

    public void die()
    {
        Debug.Log("zombifier died");
        SceneManager.LoadScene("Stage 14");
    }
}
