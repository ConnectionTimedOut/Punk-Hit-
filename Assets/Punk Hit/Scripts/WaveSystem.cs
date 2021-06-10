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


    // Probabilmente dovrò spostare tutto in script diversi da mettere ai singoli GameObject.
    private void OnCollisionEnter(Collision other) {
        /**if (other.gameObject.CompareTag("Spingibile")) {
            other.attachedRigidbody.AddForce(transform.right * pushSpeed, ForceMode.Impulse);
        } else**/ if (other.gameObject.CompareTag("Distruggibile")) {
            other.gameObject.SetActive(false);

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
