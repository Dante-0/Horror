using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem:MonoBehaviour {
  public void OnTriggerEnter(Collider other) {
    if(other.tag == "Player") {
      FindObjectOfType<GameManager>().AddScore(2);
      Destroy(gameObject);
    }
  }
}
