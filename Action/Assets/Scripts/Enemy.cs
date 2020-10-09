using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy:MonoBehaviour {
  NavMeshAgent navigator;
  GameObject player;
  public float health = 100;
  public float positionX;
  public float positionZ;
  public bool directionXorZ = false;
  bool direction = true;
  bool isAlive = true;

  Animator animator;

  void Start() {
    navigator = GetComponent<NavMeshAgent>();
    player = GameObject.FindGameObjectWithTag("Player");
    animator = GetComponent<Animator>();
  }

  void Update() {
    if((gameObject.transform.position.x - player.transform.position.x) >= -40 && (gameObject.transform.position.x - player.transform.position.x) <= 40) {
      if((gameObject.transform.position.z - player.transform.position.z) >= -40 && (gameObject.transform.position.z - player.transform.position.z) <= 40) {
        navigator.destination = player.transform.position;
      }
    } else {
      if(direction) {
        navigator.destination = new Vector3(directionXorZ ? positionX - 30 : positionX,gameObject.transform.forward.y,directionXorZ ? positionZ : positionZ - 30);
        if((navigator.transform.position.z == positionZ - 30) || (navigator.transform.position.x == positionX - 30)) {
          direction = false;
        }
      } else {
        navigator.destination = new Vector3(positionX,gameObject.transform.forward.y,positionZ);
        if(((navigator.transform.position.z == positionZ) && !directionXorZ)|| ((navigator.transform.position.x == positionX) && directionXorZ)) {
          direction = true;
        } 
      }
    }
  }
  public void TakeDamage(float damage) {
    health -= damage;
    if(health <= 0 && isAlive) {
      animator.SetBool("isDead",true);
      Destroy(gameObject,0.5f);
      GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().enemyNumber--;
      isAlive = false;
    }
  }
}
