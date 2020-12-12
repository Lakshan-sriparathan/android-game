using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour {

    public AudioClip death, jetPack, coinCollect;

    // Update is called once per frame
    void Update() {
        if (Input.GetButton ("Jump") && Player_Controlls.jetPackFuel >= 0.01f) {
            GetComponent<AudioSource>().PlayOneShot (jetPack, 1.0f);

        }
        
    }

    void OnCollisionEnter (Collision col){
        if (col.gameObject.tag == "Enemy") {
            GetComponent<AudioSource>().PlayOneShot (death, 1.0f);

        }
    }

    void OnTriggerEnter(Collider trig){
        if (trig.gameObject.tag == "Coin") {
            GetComponent<AudioSource>().PlayOneShot (coinCollect, 1.0f);

        }
    }
}
