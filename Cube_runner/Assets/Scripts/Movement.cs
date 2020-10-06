using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement:MonoBehaviour {
  Rigidbody rb;
  public int speed = 0;
  public int speedX = 15;

  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void Update() {
    rb.AddForce(0,0,speed);
    if(Input.GetKey(KeyCode.D)) {
      rb.AddForce(speedX,0,0);
    } else if(Input.GetKey(KeyCode.A)) {
      rb.AddForce(-speedX,0,0);
    }
  }
}
