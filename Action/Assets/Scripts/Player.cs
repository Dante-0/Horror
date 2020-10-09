using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player:MonoBehaviour {
  public float health = 100;
  public Camera fpsCam;
  public float interactDistance = 10;
  public LayerMask interactLayer;
  public Image interactIcon;
  public int enemyNumber = 10;
  public Text enemyLeft;
  public Text enemyKilled;
  public Text healthText;

  void Start() {
    enemyLeft.text = $"Enemy left: {enemyNumber}";
    enemyKilled.text = $"Enemy killed: {0}";
  }

  void Update() {
    enemyLeft.text = $"Enemy left: {enemyNumber}";
    enemyKilled.text = $"Enemy killed: {10-enemyNumber}";
    healthText.text =  "HP: " + System.Math.Round(health) + '/' + 100;
    GetMedicine();
    if(enemyNumber == 0) {
      SceneManager.LoadScene("WinScene");
    }
  }

  public void TakeDamage(float damage) {
    health -= damage;
    if(health <= 0) {
      SceneManager.LoadScene("LoseScene");
    }
  }
  public void GetMedicine() {
    Ray ray = new Ray(fpsCam.transform.position,fpsCam.transform.forward);
    RaycastHit hit;
    if(Physics.Raycast(ray,out hit,interactDistance,interactLayer)) {
      if(interactIcon != null) {
        interactIcon.enabled = true;
      }
      if(Input.GetKeyDown(KeyCode.E)) {
        if(hit.collider.tag == "Medicine") {
          hit.collider.GetComponent<Medicine>().DestroyMe();
          health = health + 30 > 100 ? 100 : health + 30;
        }
      }
    } else {
      if(interactIcon != null) {
        interactIcon.enabled = false;
      }
    }
  }
}
