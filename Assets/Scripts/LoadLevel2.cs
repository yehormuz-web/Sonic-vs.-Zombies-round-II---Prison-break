using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour
{
    public string leveltoload;
    public void loadlevel2()
    {
        SceneManager.LoadScene(leveltoload);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            loadlevel2();
        } 
    }




    // Update is called once per frame

}
