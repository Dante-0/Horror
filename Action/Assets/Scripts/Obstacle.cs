using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle:MonoBehaviour {
  public float health = 100;
  public void TakeDamage(float damage) {
    health -= damage;
    if(health <= 0) {
      Destroy(gameObject);
    }
  }

  void Start() {

  }

  
  void Update() {

  }
}
