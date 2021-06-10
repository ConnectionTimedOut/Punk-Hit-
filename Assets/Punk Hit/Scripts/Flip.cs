using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour {

    public GameObject skins;
    public bool isFlipped = true;


    void Update() {
        if (Input.GetAxis("Horizontal") > 0 && isFlipped) {
            isFlipped = false;

            
            Vector3 v = skins.transform.rotation.eulerAngles; //speen
            v.y = 0;
            transform.rotation = Quaternion.Euler(v);

            Debug.Log("Flip!");
        } else if (Input.GetAxis("Horizontal") < 0 && isFlipped == false) {
            isFlipped = true;

            Vector3 v = skins.transform.rotation.eulerAngles; //speen
            v.y = 180;
            transform.rotation = Quaternion.Euler(v);

            Debug.Log("Unflip!");
        }
    }
}
