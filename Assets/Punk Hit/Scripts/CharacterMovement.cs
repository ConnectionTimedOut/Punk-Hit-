using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public Rigidbody rbProtagonista;
    
    public float speed;
    private float orientation;
    //Roba che sto provando, al momento la lascio così, probabilmente da rimuovere
    private Vector3 speedCalc;
    public float speedDimezzata;

    private GroundCheck _check;
    void Start() {
        rbProtagonista = GetComponent<Rigidbody>();
        _check = gameObject.GetComponent<GroundCheck>();
    }


    void FixedUpdate() {
        orientation = Input.GetAxisRaw("Horizontal");
        //vedi riga 12
//        if (!gameObject.GetComponent<GroundCheck>().isGrounded) return;
        speedCalc = transform.right * speed * orientation;
        if (!_check.isGrounded) speedCalc /= speedDimezzata;
        rbProtagonista.AddForce(speedCalc, ForceMode.Force);
        
    }
}
