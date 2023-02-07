using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInput1 : MonoBehaviour
{
    CarController controller;
    



    void Awake(){
        controller = GetComponent<CarController>();
        
    }
    
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        controller.SetVector(inputVector);
    }
}

