using TMPro;
using UnityEngine;

public class zombiefierHitbox : MonoBehaviour
{
    public ZombiefierScript zs;
    public TextMeshProUGUI HealthLife;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            zs.health -= 1;
            HealthLife.text=zs.health.ToString();
            if (zs.health == 0)
            {
                zs.die();
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
