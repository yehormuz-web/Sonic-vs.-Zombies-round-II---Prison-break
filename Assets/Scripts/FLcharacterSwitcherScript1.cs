using UnityEngine;
using UnityEngine.InputSystem;

public class FLcharacterSwitcherScript : MonoBehaviour
{
    public GameObject[] Characters;
    public Key[] keyCodes;
    public GameObject PreviousCharacter;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Keyboard.current[keyCodes[i]].wasPressedThisFrame )
            {
                
                foreach (GameObject character in Characters) { 
                character.SetActive(false);
                }
                Characters [i].transform.position=PreviousCharacter.transform.position;
                Characters[i].SetActive(true);
                PreviousCharacter=Characters [i]; 
                //Knuckles.gameObject.transform.position = Tails.gameObject.transform.position;
                
            }
        }
    }
}
