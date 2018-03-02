using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCubes : MonoBehaviour {
    public GameObject[] alphabetprefabs;
    private GameObject[] global;
    private string wordChanged;
    private string word;
    public float ofssetAtX=3;
    public string correctLetter;
    public string wrongLetter;
    // Use this for initialization
    void Start () {
        spawnwithchangedLetter(ofssetAtX);
    }

    private void spawnwithchangedLetter(float offsetatX) {
        global = GameObject.FindGameObjectsWithTag("GlobalVariables");
        word = global[0].GetComponent<CommonWords>().getWord();
        wordChanged = changeLetter(word);
        foreach (char c in wordChanged) {
            Vector3 pos = new Vector3(gameObject.transform.position.x + offsetatX, gameObject.transform.position.y, gameObject.transform.position.z);
            GameObject inst = Instantiate(getPrefabFromLetter(c + ""), pos, getPrefabFromLetter(c+"").transform.rotation);
            offsetatX = offsetatX+1.1f;
        }
    }

    private string changeLetter(string word) {
        //print("H leksi pou tha allaksoi=="+word);
        string newstr = "";
        int rand = Random.Range(0, word.Length);
        string swap= "" + word[rand];
        foreach (char c in word) {
            if (swap.Equals("" + c))
            {
                wrongLetter = alphabetprefabs[Random.Range(0, alphabetprefabs.Length)].name;
                newstr = newstr + wrongLetter;
                correctLetter = "" + c;
               // print("ALLAZOOOOO===="+correctLetter);
            }
            else {
                newstr = newstr + c;
            }
        }
        print(newstr);
        return newstr;
    }

    public GameObject getPrefabFromLetter(string ch) {
        GameObject gm = null;
        for (int i = 0; i < alphabetprefabs.Length; i++) {
            if (alphabetprefabs[i].name.Equals(ch)) {
                gm = alphabetprefabs[i];
            }
        }
        return gm;
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
