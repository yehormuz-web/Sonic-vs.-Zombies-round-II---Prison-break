using UnityEngine;
using TMPro;

public class Mode : MonoBehaviour
{
    public string[] difficulties = new string[]{"Easy", "Normal", "Hard", "Impossible", "Nightmare", "Cursed"};
    public int selectedDifficulty = 0;
    public TextMeshProUGUI textMeshProUGUI;
    public void UpPressed() 
    {
        
        if (selectedDifficulty != difficulties.Length) 
        {
            selectedDifficulty += 1;
            textMeshProUGUI.text = difficulties[selectedDifficulty];
        }


    }
    
}
