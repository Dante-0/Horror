using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio:MonoBehaviour {
  public void PlayMusic(AudioSource audio) {
    audio.enabled = !audio.enabled;
  }
}
