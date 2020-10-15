using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelGameOver:MonoBehaviour {
  public Text scoreText;
  void Start() {
    scoreText.text = FindObjectOfType<GameManager>().scoreText.text;
  }

  public void Replay() {
    SceneManager.LoadScene("Level1");
  }
}
