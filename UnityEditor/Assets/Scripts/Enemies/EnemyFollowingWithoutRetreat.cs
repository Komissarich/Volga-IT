using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowingWithoutRetreat : MonoBehaviour
{   
    public float stoppingdistance, retreatdistance, speed;
    public GameObject target;

    private Vector2 move;
    private Rigidbody2D rb;

     public void OnCreate(Vector3 positionm, float  rotation) {
    transform.position = positionm;
    transform.rotation = Quaternion.Euler(0f, 0f, rotation);   
    }


     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        int value = Random.Range(0, 10);
        if (value > 5 || GameObject.FindGameObjectWithTag("Truck").GetComponent<MainTruck>().trailer == null) {
            target = GameObject.FindGameObjectWithTag("Truck");
        }
        else{
            target = GameObject.FindGameObjectWithTag("Truck");
            target = target.GetComponent<MainTruck>().trailer.gameObject;
        }
        
    }


     private void FixedUpdate(){

        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         direction.Normalize();   
         rb.rotation = angle;
         move = direction;
         transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
        
    }

}
