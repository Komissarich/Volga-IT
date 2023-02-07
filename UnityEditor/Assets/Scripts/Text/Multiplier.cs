using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Multiplier : MonoBehaviour
{
    private int multi = 1;
    void Start()
    {
        Main.Damage.AddListener(Zeroing);
        MainTruck.Damage.AddListener(Zeroing);
    }

   
    void Update()
    {
        
    }

    public void Add() {
        multi += 1;
        GetComponent<Text>().text = "Множитель: " + multi;
    }

    public void Zeroing() {
        multi = 1;
        GetComponent<Text>().text = "Множитель: " + multi;
    }
}
