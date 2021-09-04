using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterPlatform : MonoBehaviour
{
    public static SwitchCharacterPlatform Instance { get; private set; }

    public List<GameObject> characters = new List<GameObject>();


    private int currentChar;

    private int maxChars;



    // Start is called before the first frame update

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        characters[0].SetActive(true);
        currentChar = 0;
        maxChars = characters.Count - 1;
    }


    public void NextChar()
    {
        if (currentChar<maxChars) { 
            currentChar++;
            characters[currentChar].SetActive(true);
            characters[currentChar-1].SetActive(false);
        }
        else
        {
            characters[0].SetActive(true);
            currentChar = 0;
            characters[maxChars].SetActive(false);
        }
        
    }

    public GameObject ReturnSelectedChar()
    {
        GameObject selectedPrefab = characters[currentChar].GetComponent<StoredCharacter>().storedChar;

        return selectedPrefab;

    }

}
