using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster:MonoBehaviour {
  NavMeshAgent navigator;
  GameObject player;

  void Start() {
    navigator = GetComponent<NavMeshAgent>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  void Update() {
    navigator.destination = player.transform.position;
  }
}
