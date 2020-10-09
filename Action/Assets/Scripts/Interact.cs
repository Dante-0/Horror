using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact:MonoBehaviour {
  public LayerMask interactLayer;
  public float interactDistance;
  public Image interactIcon;

  void Start() {
    if(interactIcon != null) {
      interactIcon.enabled = false;
    }
  }

  void Update() {
    Ray ray = new Ray(transform.position,transform.forward);
    RaycastHit hit;
    if(Physics.Raycast(ray,out hit,interactDistance,interactLayer)) {
      if(interactIcon != null) {
        interactIcon.enabled = true;
          hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
      }
      if(Input.GetKeyDown(KeyCode.E)) {
        if(hit.collider.tag == "Key") {
          hit.collider.GetComponent<Key>().DestoyMe();
        }
      }
    } else {
      if(interactIcon != null) {
        interactIcon.enabled = false;
      }
    }
  }
}
