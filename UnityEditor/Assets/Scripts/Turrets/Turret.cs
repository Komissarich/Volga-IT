using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Turret : MonoBehaviour
{
    public float rateoffire;

    public AudioSource audio;
    public AudioClip clip;
    

    public GameObject bullet;

    public Pool.ObjectInfo.ObjectType bulletType;
    
    private Vector3 mousePosition;

    private float time = 0f;

    public bool isshoot = true;


    
    private void Start() {
        audio = GetComponent<AudioSource>();
    }
    

     void Update()
    {
         
         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
         Vector3 difference = mousePosition - transform.position; 
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

         if (Input.GetMouseButtonDown(0) && isshoot) {
            if (PlayerPrefs.GetInt("SavedBool") == 1) {
            audio.PlayOneShot(clip);
            }
            isshoot = false;
            time = rateoffire;
             Transform tr = transform.GetChild(0);
             var bullet = Pool.Instance.GetObject(bulletType);
            if (bullet.GetComponent<Ammo>().isusing) {
                var bullets = Pool.Instance.GetObject(bulletType);
                bullets.GetComponent<Ammo>().OnCreate(tr.position, rotation_z);
             }
             else {
                bullet.GetComponent<Ammo>().OnCreate(tr.position, rotation_z);
             }
          //   bullet.GetComponent<Ammo>().OnCreate(tr.position, rotation_z);

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













