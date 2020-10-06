using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin:MonoBehaviour {
  public void OnTriggerEnter(Collider other) {
    if(other.tag == "Player") {
      FindObjectOfType<GameManager>().AddScore(1);
      Destroy(gameObject);
    }
  }
}
