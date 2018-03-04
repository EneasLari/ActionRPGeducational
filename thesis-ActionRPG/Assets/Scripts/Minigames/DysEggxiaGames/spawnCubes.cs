using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCubes : MonoBehaviour {
    public float ofssetAtX = 1;
    public string correctLetter;
    public string wrongLetter;
    public int extraLetterIndex;
    public bool isExtraLetterGame = false;
    public bool isFindTheMissingLetterGame = false;
    public bool isCutIntoTwoWords = false;
    public GameObject betweenObject;
    public GameObject[] alphabetprefabs;
    private GameObject[] global;
    private string wordChanged;
    private string word;
    // Use this for initialization
    void Start () {       
        
        if (isCutIntoTwoWords)
        {
            spawnwtwoWords(ofssetAtX);
        }
        else {
            spawnwithchangedLetter(ofssetAtX);
        }
    }

    private void spawnwithchangedLetter(float offsetatX) {
        global = GameObject.FindGameObjectsWithTag("GlobalVariables");
        word = global[0].GetComponent<CommonWords>().getWord();
        print(word);
        if (isExtraLetterGame)
        {
            wordChanged= addExtraLetter(word);//ADD EXTRA LETTER
        }else
        {
            wordChanged = changeLetter(word);
        }
        int count = 0;
        foreach (char c in wordChanged) {
            count++;
            Vector3 pos = new Vector3(gameObject.transform.position.x + offsetatX, gameObject.transform.position.y, gameObject.transform.position.z);
            GameObject inst = Instantiate(getPrefabFromLetter(c + ""), pos, getPrefabFromLetter(c+"").transform.rotation);          
            if (extraLetterIndex>=0 && wordChanged[extraLetterIndex].Equals(c) && (count-1)==extraLetterIndex) {
                inst.GetComponent<Rigidbody>().mass = 1;
                extraLetterIndex = -1;
            }
            offsetatX = offsetatX+1.1f;
        }
    }

    private void spawnwtwoWords(float offsetatX)
    {
        global = GameObject.FindGameObjectsWithTag("GlobalVariables");
        string word1 = global[0].GetComponent<CommonWords>().getWord();
        string word2 = global[0].GetComponent<CommonWords>().getWord();
        Vector3 pos=new Vector3(0,0,0);
        print(word1);
        print(word2);
        word = word1 +betweenObject.name+ word2;
        GameObject inst = null;
        foreach (char c in word)
        {
            if (betweenObject.name.Equals(c + ""))
            {
               // pos = new Vector3(gameObject.transform.position.x + offsetatX, gameObject.transform.position.y, gameObject.transform.position.z);
                //inst = Instantiate(getPrefabFromLetter(c + ""), pos, getPrefabFromLetter(c + "").transform.rotation);
                pos = new Vector3(pos.x + (inst.transform.lossyScale.x / 2), pos.y, pos.z);
                GameObject endOfWordCube = Instantiate(betweenObject, pos, Quaternion.identity);
                endOfWordCube.transform.SetParent(inst.transform);
            }
            else {
                pos = new Vector3(gameObject.transform.position.x + offsetatX, gameObject.transform.position.y, gameObject.transform.position.z);
                inst = Instantiate(getPrefabFromLetter(c + ""), pos, getPrefabFromLetter(c + "").transform.rotation);
                offsetatX = offsetatX + 1.1f;
            }

        }
    }

    private string changeLetter(string anword) {
        string newstr = "";
        int rand = Random.Range(0, anword.Length);
        string swap= "" + anword[rand];
        foreach (char c in anword) {
            if (swap.Equals("" + c))
            {                
                if (isFindTheMissingLetterGame)//the blank cube should be the final element of array
                {
                    wrongLetter = alphabetprefabs[alphabetprefabs.Length-1].name;//FIND THE MISSING LETTER
                }
                else {
                    wrongLetter = alphabetprefabs[Random.Range(0, alphabetprefabs.Length)].name;
                }
                newstr = newstr + wrongLetter;
                correctLetter = "" + c;
                while (wrongLetter.Equals(correctLetter))
                {
                    wrongLetter = alphabetprefabs[Random.Range(0, alphabetprefabs.Length)].name;
                }
                swap ="";//for not changing two same letters
            }
            else {
                newstr = newstr + c;
            }
        }
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

    private string addExtraLetter(string anword) {
        int rand = Random.Range(0,anword.Length);
        string newstr = "";
        for (int i=0;i< anword.Length; i++) {
            if (i == rand)
            {
                string addLetter = alphabetprefabs[Random.Range(0, alphabetprefabs.Length)].name;
                newstr = newstr + addLetter;
                extraLetterIndex = i;
                i--;
                rand = -1;
            }
            else {
                newstr = newstr + anword[i];
            }
        }
        return newstr;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
