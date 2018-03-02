using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour,IBeginDragHandler,IDragHandler ,IEndDragHandler{

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    public GameObject spawnCubesObject;
    public Texture[] alphaTextures;
    GameObject placeholder = null;

    void Start()
    {
        StartCoroutine(Delay(1));

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

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

    public void OnEndDrag(PointerEventData eventData)
    {
        string name=(gameObject.GetComponentInChildren<RawImage>().texture.name);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
        if (Physics.Raycast(ray, out hit))
        {

            BoxCollider bc = hit.collider as BoxCollider;
            //print((bc.gameObject.name + "(Clone)")+"===================");
            if (bc != null && name.Equals(spawnCubesObject.GetComponent<spawnCubes>().correctLetter) && (bc.gameObject.name).Equals(spawnCubesObject.GetComponent<spawnCubes>().wrongLetter + "(Clone)")) 
            {
                print(bc.gameObject.name);
                //string word = global[0].GetComponent<CommonWords>().getWord();
                bc.gameObject.GetComponent<Replacement>().replaceObject = spawnCubesObject.GetComponent<spawnCubes>().getPrefabFromLetter(gameObject.GetComponentInChildren<RawImage>().texture.name);
                bc.gameObject.GetComponent<Replacement>().replace();
                Destroy(gameObject);
            }

        }
        Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeholder);
    }

    IEnumerator Delay(int delay)
    {
        yield return new WaitForSeconds(delay);
        print("EEEEEEEEEEEEEE" + spawnCubesObject.GetComponent<spawnCubes>().correctLetter);
        int rand = Random.Range(0, 100);
        if (rand < 50)
        {
            print("Mpike");
            foreach (Texture t in alphaTextures)
            {
                if (t.name.Equals(spawnCubesObject.GetComponent<spawnCubes>().correctLetter))
                {

                    gameObject.GetComponentInChildren<RawImage>().texture = t;
                }

            }
        }
        else
        {
            gameObject.GetComponentInChildren<RawImage>().texture = alphaTextures[Random.Range(0, alphaTextures.Length)];
        }

    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);


    }
}


