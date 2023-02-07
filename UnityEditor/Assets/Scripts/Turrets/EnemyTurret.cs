using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public float rateoffire;

    public int points;
    
    
    

    public GameObject bullet;

    public Pool.ObjectInfo.ObjectType bulletType;
    


    private float time = 0f;

    public float maxdistance;

    public bool isshoot = true;

    public GameObject target;

  
    void Start() {

        
        

        target = gameObject.transform.parent.gameObject.GetComponent<EnemyFollowing>().target;
    
    }
     void Update()
     {
            

        Vector3 difference = target.transform.position - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f,  rotation_z);   

         if (!isshoot) {
             if (time < 0) {
                 isshoot = true;
             }
             else {
                time -= Time.deltaTime;
             }
         }

         if (isshoot && Vector2.Distance(transform.position, target.transform.position) < maxdistance) {
            isshoot = false;
            time = rateoffire;

            Transform tr = transform.GetChild(0);
            GameObject bullet = Pool.Instance.GetObject(bulletType);

            if (bullet.GetComponent<Ammo>().isusing) {
                var bullets = Pool.Instance.GetObject(bulletType);
                bullets.GetComponent<Ammo>().OnCreate(tr.position, rotation_z);
             }
             else {
                bullet.GetComponent<Ammo>().OnCreate(tr.position, rotation_z);
             }
            

            

         }
        
     }



    public void Shooting() {

            // if (time <= 0) {

            // Transform tr = transform.GetChild(0);
            // GameObject projectile = Instantiate(bullet, tr.position, Quaternion.identity);
            // projectile.GetComponent<Rigidbody2D>().AddForce(tr.right * moveSpeed, ForceMode2D.Impulse);
            // }
            
    }


}













