using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
   
    public float smooth = 0.1f;
    private GameObject target;
    public GameObject go;

    public float timer = 0.3f;

     void Start() {
        target = go;
    }

     
    void FixedUpdate()
    {
        if (timer < 0 && target != null) {
        Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, smooth);
        }
        else {
            timer -= Time.deltaTime;
        }
    }
}
