using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour
{
    public string leveltoload;
    public void loadlevel2()
    {
        SceneManager.LoadScene(leveltoload);
    }    

    


    // Update is called once per frame

}
