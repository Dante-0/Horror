using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using UnityEditor;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class PacMan:MonoBehaviour {
  private Animator animator;
  private SpriteRenderer sprite;
  public float speed = 3.0f;
  private Vector3 direction = new Vector3(10,0,0);
  private Vector3 startPosition;
  public bool takePill = false;
  public Stopwatch timer = new Stopwatch();

  void Start() {
    sprite = GetComponentInChildren<SpriteRenderer>();
    animator = GetComponent<Animator>();
    startPosition = transform.position;
    timer.Restart();
  }

  void Update() {
    animator.SetBool("isMoving",true);
    if(takePill && timer.Elapsed.Seconds >= 10) {
      takePill = false;
      List<Ghost> list = GameObject.FindGameObjectsWithTag("Ghost").Select(p => p.GetComponent<Ghost>()).ToList();
      for(int i = 0;i < list.Count;++i) {
        list[i].isKilled = false;
        list[i].sprite.color = Color.white;
      }
    }
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
      if(takePill && !collision.gameObject.GetComponent<Ghost>().isKilled) {
        collision.gameObject.GetComponent<Ghost>().GetKilled();
        FindObjectOfType<GameManager>().AddScore(100);
      } else {
        animator.SetBool("isMoving",false);
        StartCoroutine(Wait(3));
        FindObjectOfType<GameManager>().ReduceHealth();
      }
    } else if(collision.gameObject.tag == "Point") {
      Destroy(collision.gameObject);
      FindObjectOfType<GameManager>().AddScore(10);
      FindObjectOfType<GameManager>().pointAndPillCount--;
    } else if(collision.gameObject.tag == "Pill") {
      Destroy(collision.gameObject);
      FindObjectOfType<GameManager>().pointAndPillCount--;
      FindObjectOfType<GameManager>().AddScore(50);
      List<Ghost> list = GameObject.FindGameObjectsWithTag("Ghost").Select(p => p.GetComponent<Ghost>()).ToList();
      for(int i = 0;i < list.Count;++i) {
        list[i].isKilled = false;
      }
      takePill = true;
      timer.Restart();
    }
  }

  IEnumerator Wait(int second) {
    yield return new WaitForSeconds(second);
  }
}
