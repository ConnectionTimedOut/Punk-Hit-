using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public Rigidbody rbProtagonista;
    
    public float speed;
    private float orientation;
    private Vector3 speedCalc;
    public float speedDimezzata;

    private GroundCheck _gCheck;
    //private DisableWallMovement _wCheck;
    void Start() {
        rbProtagonista = GetComponent<Rigidbody>();
        _gCheck = gameObject.GetComponent<GroundCheck>();
   //     _wCheck = gameObject.GetComponent<DisableWallMovement>();
    }


    void FixedUpdate() {


        orientation = Input.GetAxisRaw("Horizontal");
        speedCalc = transform.right * speed * orientation;

        if (!_gCheck.isGrounded) speedCalc /= speedDimezzata;

  //      if (_wCheck.touchesRWall) Mathf.Clamp(orientation, -1, 0);
    //    if (_wCheck.touchesLWall) Mathf.Clamp(orientation, 0, 1);
        rbProtagonista.AddForce(speedCalc, ForceMode.Force);
    }
}
