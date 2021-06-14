using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWallMovement : MonoBehaviour {

    private float distanceToWall;
    public bool touchesRWall;
    public bool touchesLWall;
    void Start() {
        distanceToWall = GetComponent<Collider>().bounds.extents.x;
    }

    void FixedUpdate() {
        if (Physics.Raycast(transform.position, Vector3.right, distanceToWall + 0.1f)) {
            touchesRWall = true;
        } else if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), Vector3.right, distanceToWall + 0.1f)) {
            touchesRWall = true;
        } else if (Physics.Raycast(transform.position + new Vector3(0, -0.5f, 0), Vector3.right, distanceToWall + 0.1f)) {
            touchesRWall = true;
        } else touchesRWall = false;

        if (Physics.Raycast(transform.position, -Vector3.right, distanceToWall + 0.1f)) {
            touchesLWall = true;
        } else if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), -Vector3.right, distanceToWall + 0.1f)) {
            touchesLWall = true;
        } else if (Physics.Raycast(transform.position + new Vector3(0, -0.5f, 0), -Vector3.right, distanceToWall + 0.1f)) {
            touchesLWall = true;
        } else touchesLWall = false;
        
    }
}
