using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class InfoHandler : MonoBehaviour
{
    public string[] InfoText;
    public Sprite[] images;
    public TextMeshProUGUI Text;
    public Image ImageToChange;
    public int Tracker=0;
    public void next()
    {
        if (Tracker<InfoText.Length-1)
            Tracker++;
        else Tracker=0;
        Text.text = InfoText[Tracker];
        ImageToChange.sprite = images[Tracker];
        if (Tracker == 9)
            Text.color = Color.red;
        else Text.color = Color.black;
    }
    public void previous()
    {
        if (Tracker > 0)
            Tracker--;
        else Tracker = InfoText.Length-1;
        Text.text = InfoText[Tracker];
        ImageToChange.sprite = images[Tracker];
        if (Tracker == 9)
            Text.color = Color.red;
        else Text.color = Color.black;
    }

}
