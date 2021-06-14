using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBase : MonoBehaviour {
    
    public GameObject VFX;
    public Collider impactArea;
    public float delayTime = 0;
    public float impactDuration = 0.1f;
    public virtual void DestroyItem() {
        Instantiate(VFX, transform.position, transform.rotation);
        if (impactArea != null) {
            StartCoroutine(DamageArea());
        } else {
            Destroy(gameObject);
        }
    }

    IEnumerator DamageArea() {
        yield return new WaitForSeconds(delayTime);
        impactArea.enabled = true;
        yield return new WaitForSeconds(impactDuration);
        Destroy(gameObject);
    }
}
