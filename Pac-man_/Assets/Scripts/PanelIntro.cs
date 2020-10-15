using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelIntro:MonoBehaviour {
  public void Play() {
    SceneManager.LoadScene("Level1");
  }
}
