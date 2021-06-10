using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour {

    public GameObject ondaSonora;
    //public float pushSpeed;
    public float waveSpeed = 100;
    public float fineOnda;

    private void Start() {
        GetComponent<Rigidbody>().AddForce(transform.forward * waveSpeed, ForceMode.Impulse);
        StartCoroutine(DeleteThis());
        //StartCoroutine(LimitSpeed());
    }


    // Probabilmente dovr� spostare tutto in script diversi da mettere ai singoli GameObject.
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<DestroyableBase>() != null) {
            other.gameObject.GetComponent<DestroyableBase>().DestroyItem();
        }
        Destroy(gameObject);
    }

    /**IEnumerator LimitSpeed() {
        yield return new WaitForSeconds(0.1f);
        Destroy(ondaSonora.GetComponent<ConstantForce>());

    }**/

    IEnumerator DeleteThis() {
        yield return new WaitForSeconds(fineOnda);
        Destroy(ondaSonora);
    }
}
