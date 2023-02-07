using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Audio : MonoBehaviour
{
   public static bool sound = true;
   public Toggle toggle;
   public Button button;
    public int intToSave = 1;
    void Start()
    {
    if(PlayerPrefs.GetInt("SavedBool") == 1) {
        toggle.isOn = true;
    }
    else {
        toggle.isOn = false;
    }
    }
    void Update()
    {
        
    }

    public void ChangeAudio() {
        if(button.gameObject.active) {
        button.gameObject.SetActive(false);
        toggle.gameObject.SetActive(true);
        }
        else {
           button.gameObject.SetActive(true);
           toggle.gameObject.SetActive(false);
        }

      
    }

    public void Choose() {

        if (toggle.isOn) {
            sound = true;
            intToSave = 1;
            PlayerPrefs.SetInt("SavedBool", intToSave);
        
        }
        else {
            sound = false;
            intToSave = 0;
            PlayerPrefs.SetInt("SavedBool", intToSave);
        }
    }
}
