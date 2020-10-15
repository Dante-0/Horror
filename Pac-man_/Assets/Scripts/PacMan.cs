using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan:MonoBehaviour {
  private SpriteRenderer sprite;
  public float speed = 3.0f;
  private Vector3 direction = new Vector3(10,0,0);
  private Vector3 startPosition;
  void Start() {
    sprite = GetComponentInChildren<SpriteRenderer>();
    startPosition = transform.position;
  }

  void Update() {
    ChangeDirection();
    Move();
  }

  private void ChangeDirection() {
    if(Input.GetKeyDown(KeyCode.W)) {
      sprite.flipX = false;
      transform.rotation = Quaternion.Euler(0f,0f,90f);
      direction = new Vector3(0,10,0);
    } else if(Input.GetKeyDown(KeyCode.S)) {
      sprite.flipX = false;
      transform.rotation = Quaternion.Euler(0f,0f,270f);
      direction = new Vector3(0,-10,0);
    } else if(Input.GetKeyDown(KeyCode.D)) {
      transform.rotation = Quaternion.Euler(0f,0f,0);
      sprite.flipX = false;
      direction = new Vector3(10,0,0);
    } else if(Input.GetKeyDown(KeyCode.A)) {
      transform.rotation = Quaternion.Euler(0f,0f,0);
      sprite.flipX = true;
      direction = new Vector3(-10,0,0);
    }
  }

  private void Move() {
    transform.position = Vector3.MoveTowards(transform.position,transform.position + direction,speed * Time.deltaTime);
  }

  public void ReturnToStart() {
    transform.position = startPosition;
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if(collision.gameObject.tag == "Ghost") {
      FindObjectOfType<GameManager>().ReduceHealth();
    }
  }
}
