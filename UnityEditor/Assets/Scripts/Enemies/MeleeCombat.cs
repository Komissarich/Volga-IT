using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public float rateoffire;
    private float time = 0f;
    public float damage;

    public bool isshoot = true;
    void Update()
    {
        if (gameObject.GetComponent<EnemyFollowingWithoutRetreat>().target == null) {
             gameObject.GetComponent<EnemyFollowingWithoutRetreat>().target = GameObject.FindGameObjectWithTag("Truck");
        }
          if (Vector2.Distance(transform.position, gameObject.GetComponent<EnemyFollowingWithoutRetreat>().target.transform.position) <= gameObject.GetComponent<EnemyFollowingWithoutRetreat>().stoppingdistance) {
           if (!isshoot) {
             if (time < 0) {
                 isshoot = true;
             }
             else {
                time -= Time.deltaTime;
             }
         }

         if (isshoot) {
            isshoot = false;
            time = rateoffire;
            if (gameObject.GetComponent<EnemyFollowingWithoutRetreat>().target.tag == "Truck") {
                gameObject.GetComponent<EnemyFollowingWithoutRetreat>().target.GetComponent<MainTruck>().TakeDamage(damage);
            }
            else{
                gameObject.GetComponent<EnemyFollowingWithoutRetreat>().target.GetComponent<Main>().TakeDamage(damage);
            }

         }
        }
    }
}
