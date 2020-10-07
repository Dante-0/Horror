using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Gun:MonoBehaviour {
  public float damage = 10;
  public float range = 100;
  public int bulletsNumber = 30;
  public Camera fpsCam;

  public ParticleSystem shootEffect;
  public GameObject bulletEffect;
  public float impactForce = 100;
  public Text text;
  public Text message;

  void Start() {

  }

  // Update is called once per frame
  void Update() {
    if(Input.GetKeyDown(KeyCode.R)) {
      bulletsNumber = 30;
      text.text = "30/30";
      message.enabled = false;
    }
    if(bulletsNumber != 0) {
      if(Input.GetMouseButtonDown(0)) {
        Shoot();
        bulletsNumber--;
        text.text = bulletsNumber + "/30";
      }
    } else {
      message.enabled = true;
    }
  }

  public void Shoot() {
    shootEffect.Play();
    RaycastHit hit;
    if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range)) {
      GameObject effect = Instantiate(bulletEffect,hit.point,Quaternion.LookRotation(hit.normal));
      Destroy(effect,1);

      Rigidbody rigidbody = hit.collider.GetComponent<Rigidbody>();

      if(hit.rigidbody != null) {
        hit.rigidbody.AddForce(-hit.normal * impactForce);
      }
      Target target = hit.collider.GetComponent<Target>();
      if(target != null) {
        target.TakeDamage(damage);
      }
      //Debug.Log(hit.collider.name);
    }
  }
}
