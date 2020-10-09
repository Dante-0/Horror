using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun:MonoBehaviour {

  public float damage = 10;
  public float range = 100;

  public ParticleSystem shootEffect;
  public GameObject bulletEffect;
  public GameObject hitEffect;
  public float impactForce = 100;

  void Start() {

  }

  void Update() {
    if(Physics.Raycast(gameObject.transform.position,gameObject.transform.forward,out RaycastHit hit,range)) {
      Player player = hit.collider.GetComponent<Player>();
      if(player != null) {
        Shoot();
      }
    }
  }

  public void Shoot() {
    RaycastHit hit;
    if(Physics.Raycast(gameObject.transform.position,gameObject.transform.forward,out hit,range)) {
      GameObject effect = Instantiate(bulletEffect,hit.point,Quaternion.LookRotation(hit.normal));
      shootEffect.Play();
      Destroy(effect,1);

      Obstacle obstacle = hit.collider.GetComponent<Obstacle>();
      Player player = hit.collider.GetComponent<Player>();
      if(hit.collider.tag == "Wall") {
        Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
      } else if(obstacle != null) {
        Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
        obstacle.TakeDamage(damage);
      } else if(player != null) {
        player.TakeDamage(damage);
      }
    }
  }
}
