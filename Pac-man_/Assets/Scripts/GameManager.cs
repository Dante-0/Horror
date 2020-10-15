using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager:MonoBehaviour {
  public Text scoreText;
  private int score = 0;
  private static bool level2 = false;
  private static int savedScore;
  public List<Image> healths;
  void Start() {
    healths = GameObject.FindGameObjectsWithTag("Health").Select(p => p.GetComponent<Image>()).ToList();
  }

  // Update is called once per frame
  void Update() {
    if(healths is null) {
      SceneManager.LoadScene("Result");
    }
    scoreText.text = $"Score: {score}";
  }

  public void AddScore(int points) {
    score += points;
  }

  public void ReduceHealth() {
    Destroy(healths.Last(p => p != null));
    List<Ghost> ghosts= GameObject.FindGameObjectsWithTag("Ghost").Select(p => p.GetComponent<Ghost>()).ToList();
    foreach(var item in ghosts) {
      item.ReturnToStart();
    }
    GameObject.FindGameObjectWithTag("Player").GetComponent<PacMan>().ReturnToStart();
  }
}
