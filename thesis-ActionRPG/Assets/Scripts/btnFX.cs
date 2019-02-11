using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour {
    public AudioSource myfx;
    public AudioClip clickFx;

    public void ClickSound() {
        myfx.PlayOneShot(clickFx);
    }


}
