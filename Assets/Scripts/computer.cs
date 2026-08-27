using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class computer : MonoBehaviour
{
    public int diaulognumber = 0;
    public bool cutsceneplay = false;
    public PlayableDirector director;
    public string[] alldiaulog;
    public string[] alldiaulogUkrainian;
    public GameObject[] alldiaulogtextboxes;
    public Color[] alldiaulogcolors;
    public int[] whenToPlay;
    public TextMeshProUGUI Textbox;
    public bool playonawake;
    public GameObject[] objectstodisable;
    public TMP_FontAsset UkrainianFont;

    public void Start()
    {
        if (playonawake)
            director.Play();
        if (LanguageHandler.Ukrainianselected)
            Textbox.font = UkrainianFont;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerMovement>().rb.linearVelocity=Vector2.zero;
            collision.gameObject.GetComponent<playerMovement>().enabled = false;
            director.Play();
            foreach (GameObject obj in objectstodisable)
            {
                obj.SetActive(false);
            }
        }
    }

    public void diaulog1()
    {
        if (diaulognumber > 0)
            alldiaulogtextboxes[diaulognumber - 1].SetActive(false);
        alldiaulogtextboxes[diaulognumber].SetActive(true);
        Textbox.color = alldiaulogcolors[diaulognumber];
            if (LanguageHandler.Englishselected)
                Textbox.text = alldiaulog[diaulognumber];
            else if (LanguageHandler.Ukrainianselected)
                Textbox.text = alldiaulogUkrainian[diaulognumber];
        else
            Textbox.text = alldiaulog[diaulognumber];
          diaulognumber += 1;
        if (whenToPlay.Length > 0)
        {
            foreach (int i in whenToPlay)
            {
                if (diaulognumber == i)
                    director.playableGraph.GetRootPlayable(0).SetSpeed(1);
            }
        }
    }

    public void diaulogcolor(string color)
    {
        Color Newcolor;
        ColorUtility.TryParseHtmlString(color, out Newcolor);
        Debug.Log(Newcolor);
        Textbox.color = Newcolor;
    }
    public void pausetimeline()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }



    public void LoadLevel(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
    }
    public void enabletxt() {
        Textbox.gameObject.SetActive(true);
        cutsceneplay = true;
    }

    public void Update()
    {
        if ( Input.GetKeyDown(KeyCode.X) && cutsceneplay) {
            if (diaulognumber >= alldiaulog.Length)
                director.playableGraph.GetRootPlayable(0).SetSpeed(1);
            else 
                diaulog1();
        }
    }

}
