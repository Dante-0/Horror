using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager:MonoBehaviour {
  public int score = 0;
  public Text scoreText;

  public void AddScore(int point) {
    score += point;
    scoreText.text = score.ToString();
  }

}
