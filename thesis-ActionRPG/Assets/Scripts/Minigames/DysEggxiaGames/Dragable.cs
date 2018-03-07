using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour,IBeginDragHandler,IDragHandler ,IEndDragHandler{

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    public GameObject spawnCubesObject;
    public bool isThecorrect = false;
    public Texture[] alphaTextures;

    GameObject placeholder = null;

    void Start()
    {
        StartCoroutine(Delay(1));

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false; ;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log ("OnDrag");

        this.transform.position = eventData.position;

        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {

                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)//Functionality and gameplay of change a letter mini game
    {
        string nameofLetterImage=(gameObject.GetComponentInChildren<RawImage>().texture.name);
        string correctLetter = spawnCubesObject.GetComponent<spawnCubes>().correctLetter;
        string wrongLetter = spawnCubesObject.GetComponent<spawnCubes>().wrongLetter;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
        if (Physics.Raycast(ray, out hit))
        {
            BoxCollider bc = hit.collider as BoxCollider;
            if (bc != null && nameofLetterImage.Equals(correctLetter) && (bc.gameObject.name).Equals(wrongLetter + "(Clone)")) 
            {
                bc.gameObject.GetComponent<Replacement>().replaceObject = spawnCubesObject.GetComponent<spawnCubes>().getPrefabFromLetter(gameObject.GetComponentInChildren<RawImage>().texture.name);
                bc.gameObject.GetComponent<Replacement>().replace();
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadoutManager>().fadeIn = true;
                print("You changed the correct letter.Excellent!");
                Destroy(gameObject);
            }
        }
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeholder);
    }

    IEnumerator Delay(int delay)
    {
        
        yield return new WaitForSeconds(delay);
        if (isThecorrect)
        {
            print("CORRECT "+gameObject.name);
            GameObject parent = transform.parent.gameObject;
            string correctLetter = spawnCubesObject.GetComponent<spawnCubes>().correctLetter;
            foreach (Texture t in alphaTextures)
            {
                if (t.name.Equals(correctLetter))
                {
                    Texture myTexture = gameObject.GetComponentInChildren<RawImage>().texture;
                    gameObject.GetComponentInChildren<RawImage>().texture = t;
                    for (int i = 0; i < parent.transform.childCount; i++)
                    {
                        bool isNotComparingWithHimSelf = !parent.transform.GetChild(i).name.Equals(gameObject.name);
                        string siblingTextureName = parent.transform.GetChild(i).GetComponentInChildren<RawImage>().texture.name;
                        bool correctLetterHasBeeenShown = siblingTextureName.Equals(correctLetter);
                        if ( correctLetterHasBeeenShown && isNotComparingWithHimSelf)
                        {  
                            while (myTexture.name.Equals(siblingTextureName) )
                            {
                                gameObject.GetComponentInChildren<RawImage>().texture = alphaTextures[Random.Range(0, alphaTextures.Length)];
                            }
                        }
                    }
                }
            }
        }
        else
        {
            gameObject.GetComponentInChildren<RawImage>().texture = alphaTextures[Random.Range(0, alphaTextures.Length)];
            GameObject parent = transform.parent.gameObject;
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                while (gameObject.GetComponentInChildren<RawImage>().texture.name.Equals(parent.transform.GetChild(i).GetComponentInChildren<RawImage>().texture.name) && !parent.transform.GetChild(i).name.Equals(gameObject.name)) {
                    gameObject.GetComponentInChildren<RawImage>().texture = alphaTextures[Random.Range(0, alphaTextures.Length)];
                }

            }
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);


    }
}


