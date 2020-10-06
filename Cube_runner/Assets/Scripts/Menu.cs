using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu:MonoBehaviour {
  public void PlayGame() {
    SceneManager.LoadScene("Game");
  }

  public void ExitGame() {
    Application.Quit();
  }

  public void Music(AudioSource audio) {
    audio.enabled = !audio.enabled;
  }

}
