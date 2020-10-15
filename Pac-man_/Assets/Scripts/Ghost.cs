using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost:MonoBehaviour {
  public float speed = 1f;
  private Animator animator;
  private Vector3 startPosition;
  private Vector3 prevPosition;
  private int timer = 0;
  public int beginTime;
  void Start() {
    animator = GetComponent<Animator>();
    startPosition = transform.position;
    prevPosition = transform.position;
  }

  void Update() {
    if(timer > beginTime) {
      Move();
    }
    ++timer;
  }

  private void Move() {
    transform.position = Vector3.MoveTowards(transform.position,GameObject.FindGameObjectWithTag("Player").transform.position,speed * Time.deltaTime);
    if(prevPosition.x < transform.position.x) {
      animator.SetInteger("moveType",0);
    } else if(prevPosition.x > transform.position.x) {
      animator.SetInteger("moveType",1);
    }
    prevPosition = transform.position;
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
  }

  public void ReturnToStart() {
    transform.position = startPosition;
    timer = 0;
  }
}
