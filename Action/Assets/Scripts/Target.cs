using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target:MonoBehaviour {
  public float health = 100;
  public void TakeDamage(float amount) {
    health -= amount;
    if(health <= 0) {
      Die();
    }
  }

  public void Die() {
    Destroy(gameObject);
  }
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }
}
