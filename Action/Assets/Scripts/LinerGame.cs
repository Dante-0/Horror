using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinerGame:MonoBehaviour {
  public Image uiElement;
  public float timeValue = 100;
  float currentTime;
  float timeDrain = 1;

  void Start() {
    currentTime = timeValue;
  }


  void Update() {
    currentTime -= timeDrain * Time.deltaTime;
    uiElement.transform.localScale = new Vector3(currentTime / timeValue,uiElement.transform.localScale.y,
      uiElement.transform.localScale.z);

    if(currentTime <= 0) {
      Application.LoadLevel(Application.loadedLevel);
    }
  }
}
