using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    void Start()
    {

    }


    public void ChangeText(int a)
    {
         string b = GetComponent<Text>().text.Split()[0];
         string c = GetComponent<Text>().text.Split()[1];
         GetComponent<Text>().text = b + " " +(int.Parse(c) + a).ToString();
    }
   
}
