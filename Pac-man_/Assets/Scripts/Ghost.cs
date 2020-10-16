using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ghost:MonoBehaviour {
  public SpriteRenderer sprite;
  public float speed = 1f;
  private Animator animator;
  private Vector3 startPosition;
  private Vector3 prevPosition;
  private Stopwatch timer = new Stopwatch();
  public int beginTime;
  public bool isKilled = false;

  void Start() {
    timer.Restart();
    animator = GetComponent<Animator>();
    startPosition = transform.position;
    prevPosition = transform.position;
    sprite = GetComponentInChildren<SpriteRenderer>();
  }

  void Update() {
    if(GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PacMan>().takePill && !isKilled) {
      sprite.color = Color.grey;
      Move(startPosition);
    } else if(timer.Elapsed.Seconds > beginTime) {
      Move(GameObject.FindGameObjectWithTag("Player").transform.position);
      timer.Stop();
    }
  }

  private void Move(Vector3 destination) {
    transform.position = Vector3.MoveTowards(transform.position,destination,speed * Time.deltaTime);
    if(prevPosition.x < transform.position.x) {
      animator.SetInteger("moveType",0);
    } else if(prevPosition.x > transform.position.x) {
      animator.SetInteger("moveType",1);
    }
    prevPosition = transform.position;
  }

  public void GetKilled() {
    transform.position = startPosition;
    sprite.color = Color.white;
    isKilled = true;
  }

  public void ReturnToStart() {
    transform.position = startPosition;
    timer.Restart();
  }
}

//if(prevPosition.x < GameObject.FindGameObjectWithTag("Player").transform.position.x) {
//  animator.SetInteger("moveType",0);
//}
//if(prevPosition.x > GameObject.FindGameObjectWithTag("Player").transform.position.x) {
//  animator.SetInteger("moveType",1);
//}
//if(prevPosition.y < GameObject.FindGameObjectWithTag("Player").transform.position.y) {
//  animator.SetInteger("moveType",2);
//}
//if(prevPosition.y > GameObject.FindGameObjectWithTag("Player").transform.position.y) {
//  animator.SetInteger("moveType",3);
//}
//if(prevPosition.y < transform.position.y) {
//  animator.SetInteger("moveType",2);
//} else if(prevPosition.y > transform.position.y) {
//  animator.SetInteger("moveType",3);
//} else if(prevPosition.x < transform.position.x) {
//  animator.SetInteger("moveType",0);
//} else if(prevPosition.x > transform.position.x) {
//  animator.SetInteger("moveType",1);
//}