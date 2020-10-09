using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result:MonoBehaviour {
  public void Restart() {
    SceneManager.LoadScene(0);
  }

  public void Exit() {
    Application.Quit();
  }

  public void Update() {
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
  }
}
