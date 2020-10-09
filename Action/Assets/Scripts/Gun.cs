using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Gun:MonoBehaviour {
  public float damage = 10;
  public float range = 100;
  int bulletsNumber = 30;
  public int maxBulletNumber = 30;
  public Camera fpsCam;

  public ParticleSystem shootEffect;
  public GameObject bulletEffect;
  public GameObject hitEffect;
  public float impactForce = 100;
  public Text bulletText;
  public Text message;
  public UnityEngine.UI.Image image;

  void Start() {
    bulletsNumber = maxBulletNumber;
  }

  // Update is called once per frame
  void Update() {
    bulletText.text = bulletsNumber.ToString() + '/' + maxBulletNumber.ToString();
    if(Input.GetKeyDown(KeyCode.R)) {
      bulletsNumber = maxBulletNumber;
      bulletText.text = bulletsNumber.ToString() + '/' + maxBulletNumber.ToString();
      message.enabled = false;
    }
    if(bulletsNumber != 0) {
      if(Input.GetMouseButtonDown(0)) {
        Shoot();
        bulletsNumber--;
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
      if(rigidbody != null) {
        hit.rigidbody.AddForce(-hit.normal * impactForce);
      }
      Target target = hit.collider.GetComponent<Target>();
      if(target != null) {
        target.TakeDamage(damage);
      }
      Obstacle obstacle = hit.collider.GetComponent<Obstacle>();
      Enemy enemy = hit.collider.GetComponent<Enemy>();
      if(hit.collider.tag == "Wall") {
        Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
      } else if(obstacle != null) {
        Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
        obstacle.TakeDamage(damage);
      } else if(enemy != null) {
        enemy.TakeDamage(damage);
      }


      //Debug.Log(hit.collider.name);
    }
  }
}
