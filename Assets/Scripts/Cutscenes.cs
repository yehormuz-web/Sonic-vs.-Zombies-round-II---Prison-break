using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Cutscenes : MonoBehaviour
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
        if (languageswitchhandler.Ukrainianselected)
            Textbox.font = UkrainianFont;
    }


    public void diaulog1()
    {
        if (diaulognumber > 0)
            alldiaulogtextboxes[diaulognumber - 1].SetActive(false);
        alldiaulogtextboxes[diaulognumber].SetActive(true);
        Textbox.color = alldiaulogcolors[diaulognumber];
            if (languageswitchhandler.Englishselected)
                Textbox.text = alldiaulog[diaulognumber];
            else if (languageswitchhandler.Ukrainianselected)
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
