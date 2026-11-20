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
                SceneManager.LoadScene("Main Menu");
     }
    }
    void Update()
    {
        this.gameObject.transform.position += this.gameObject.transform.right*speed;
    }
}
