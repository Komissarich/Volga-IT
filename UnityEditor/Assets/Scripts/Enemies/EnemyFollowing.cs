using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    public float speed;

    public float stoppingdistance;
    public float retreatdistance;


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
        
        target = GameObject.FindGameObjectWithTag("Truck");
    }

    private void FixedUpdate(){

        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();   
        rb.rotation = angle;
        move = direction;
     
        if (Vector2.Distance(transform.position, target.transform.position) > stoppingdistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
        }
     
        else if (Vector2.Distance(transform.position, target.transform.position) < retreatdistance ){
           transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.fixedDeltaTime);
        } 

        else {
            transform.position = this.transform.position;
        }
      
    }



}
