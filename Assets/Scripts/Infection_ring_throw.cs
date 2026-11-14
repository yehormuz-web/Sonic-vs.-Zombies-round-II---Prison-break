using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Infection_ring_throw : MonoBehaviour
{public float speed;
    
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            UnitedLifeHandler.Life -= 1;
            if (UnitedLifeHandler.Life == 0)
                SceneManager.LoadScene("Main Menu");
            else 
                SceneManager.LoadScene("Stage 48");
     }
    }
    void Update()
    {
        this.gameObject.transform.position += this.gameObject.transform.right*speed;
    }
}
