using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponSwitcher:MonoBehaviour {
  public int selectedWeapon = 0;
  int prevWeapon = 0;
  void Start() {

  }

  void Update() {
    //int prevWeapon = selectedWeapon;
    if(Input.GetAxis("Mouse ScrollWheel") > 0) {
      if(selectedWeapon >= transform.childCount - 1) {
        selectedWeapon = 0;
      } else {
        selectedWeapon++;
      }
    } else if(Input.GetAxis("Mouse ScrollWheel") < 0) {
      if(selectedWeapon <= 0) {
        selectedWeapon = transform.childCount - 1;
      } else {
        selectedWeapon--;
      }
    } 
    
    if(prevWeapon != selectedWeapon) {
      SelectWeapon();
    }
  }

  public void SelectWeapon() {
    transform.GetChild(prevWeapon).gameObject.GetComponent<Gun>().image.color = Color.white;
    transform.GetChild(prevWeapon).gameObject.GetComponent<Gun>().message.enabled = false;
    int index = 0;
    for(int i = 0;i < transform.childCount;++i) {
      if(i == selectedWeapon) {
        index = i;
        transform.GetChild(i).gameObject.SetActive(true);
        prevWeapon = selectedWeapon;
      } else {
        transform.GetChild(i).gameObject.SetActive(false);
      }
    }
    transform.GetChild(index).gameObject.GetComponent<Gun>().image.color = Color.red;

  }
}
