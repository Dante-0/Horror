using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall:MonoBehaviour {
  public void OnCollisionEnter(Collision collision) {
    if(collision.collider.tag == "Player") {
      Application.LoadLevel(Application.loadedLevel);
    }
  }
}
