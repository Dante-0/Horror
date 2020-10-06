using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio:MonoBehaviour {
  public void Music(AudioSource audio) {
    audio.enabled = !audio.enabled;
  }
}
