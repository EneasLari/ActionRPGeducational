using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadoutManager : MonoBehaviour {

    public Image FadeImg;
    public GameObject mainCamera;
    public GameObject player;
    public float fadeSpeed = 1.5f;
    public bool fadeIn = false;
    public bool fadeOut = true;

    void Awake()
    {
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if (fadeOut == true) {
            StartScene();
        }
        else if (fadeIn==true) {
            EndScene();
        }
    }


    void FadeOut()
    {
        // Lerp the colour of the image between itself and transparent.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeIn()
    {
        // Lerp the colour of the image between itself and black.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
    }
    void EndScene() {
        FadeImg.enabled = true;
        FadeIn();
        if (FadeImg.color.a >= 0.9f) {
            FadeImg.color = Color.black;
            if (player!=null && player.activeInHierarchy)
            {
                GameObject.FindGameObjectWithTag("GlobalVariables").GetComponent<QuestsToComplete>().getQuest();
            }
            else {
                mainCamera.transform.parent.gameObject.SetActive(true);
                mainCamera.GetComponent<FadoutManager>().fadeOut = true;
                player.SetActive(true);
                gameObject.transform.parent.gameObject.SetActive(false);              
            }
            
            fadeIn = false;           
        }
    }
    
    void StartScene()
    {
        // Fade the texture to clear.
        FadeOut();

        // If the texture is almost clear...
        if (FadeImg.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the RawImage.
            FadeImg.color = Color.clear;
            fadeOut = false;
            FadeImg.enabled = false;
        }
    }
}
