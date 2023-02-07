using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour, IPooledObject
{

    public float destroyTime;

    public float damage;

    public bool isusing = false;
    

    
    public float force;
    

     public float currentdestroytime;

     public Pool.ObjectInfo.ObjectType Type => type;
    
     [SerializeField]
     private Pool.ObjectInfo.ObjectType type;


    public void OnCreate(Vector3 positionm, float  rotation) {
    transform.position = positionm;
    transform.rotation = Quaternion.Euler(0f, 0f, rotation);   
    currentdestroytime = destroyTime;
    isusing = true;

    }

    void Update()
    {

         transform.Translate(Vector2.right * (force * Time.deltaTime));
         if (currentdestroytime < 0) {
                 isusing = false;
            
             Pool.Instance.DestroyObject(gameObject);
         }
        else {
         currentdestroytime -= Time.deltaTime;
     }
    }
}
