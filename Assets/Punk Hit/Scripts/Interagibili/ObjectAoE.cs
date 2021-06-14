using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

[RequireComponent(typeof(Collider))]
public class ObjectAoE : MonoBehaviour {

    private Collider explosionCollider;
    private void Start() {
        explosionCollider = GetComponent<Collider>();
        explosionCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        CustomEvent.Trigger(other.gameObject, "Stun");
    }

}
