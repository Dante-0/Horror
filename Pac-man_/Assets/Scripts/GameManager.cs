using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager:MonoBehaviour {
  public Text scoreText;
  private int score = 0;
  private static bool level2 = false;
  private static int savedScore = 0;
  private Stopwatch timer = new Stopwatch();
  public Text timeText;
  public int maxTime = 180;
  public List<Image> healths;
  private int healthPoint;
  public int pointAndPillCount;

  void Start() {
    healths = GameObject.FindGameObjectsWithTag("Health").Select(p => p.GetComponent<Image>()).ToList();
    healthPoint = healths.Count;
    pointAndPillCount = GameObject.FindGameObjectsWithTag("Point").Count() + GameObject.FindGameObjectsWithTag("Pill").Count();
    score = savedScore;
    timer.Reset();
    if(level2) {
      timer.Restart();
    }
  }

  void Update() {
    if(healthPoint == 0 || (pointAndPillCount == 0 && level2) || maxTime - timer.Elapsed.Seconds <= 0) {
      DataHolder.Score = score;
      SceneManager.LoadScene("Result");
      level2 = false;
      savedScore = 0;
    } else if(pointAndPillCount == 0 && !level2) {
      savedScore = score;
      level2 = true;
      SceneManager.LoadScene("Level2");
    } else if(level2) {
      timeText.text = $"Left: {maxTime - timer.Elapsed.Seconds} seconds";
    }
    scoreText.text = $"Score: {score}";
  }

  public void AddScore(int points) {
    score += points;
  }

  public void ReduceHealth() {
    --healthPoint;
    Destroy(healths.Last(p => p != null));
    List<Ghost> ghosts= GameObject.FindGameObjectsWithTag("Ghost").Select(p => p.GetComponent<Ghost>()).ToList();
    for(int i = 0; i < ghosts.Count;++i) { 
      ghosts[i].ReturnToStart();
      ghosts[i].isKilled = false;
      ghosts[i].sprite.color = Color.white;
    }
    GameObject.FindGameObjectWithTag("Player").GetComponent<PacMan>().ReturnToStart();
    GameObject.FindGameObjectWithTag("Player").GetComponent<PacMan>().takePill = false;
  }
}
