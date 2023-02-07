using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextPrinting : MonoBehaviour
{
   public Text text;
   private string letters;
    void Start()
    {
        letters = text.text;
        text.text = "";
        StartCoroutine(Texting());
    }

    IEnumerator Texting(){
        foreach(char abc in letters) {
            text.text += abc;
            yield return new WaitForSeconds(0.1f);
        }
        text.gameObject.SetActive(false);
    }
}
