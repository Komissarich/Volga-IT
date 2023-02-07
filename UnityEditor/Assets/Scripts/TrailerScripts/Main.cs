using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Main : MonoBehaviour
{
    public SpriteRenderer sp;

    public static UnityEvent Damage = new UnityEvent();

    public int countofturrets;

    public List<Turret> child_turrets = new List<Turret>();

    public GameObject explosion;
    public float selfhealth = 100f;
    public float maxhealth = 100f;

    private bool timeron = false;

    public float currenttime;

    public float damageduration;

    void Start(){
        
        sp = gameObject.GetComponent<SpriteRenderer>();
        currenttime = damageduration;
    }
    
    void Update() {

        if (timeron) {
            currenttime -= Time.deltaTime;
            if (currenttime < 0) {
                UnRed();
                timeron = false;
                currenttime = damageduration;
            }
        }

    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.tag == "Enemy_bullet" && gameObject.tag != "InactiveTrailer") {
           
           TakeDamage(other.GetComponent<Ammo>().damage);
        }
    }

    

    public void TakeDamage(float damage){
        Damage.Invoke();
        selfhealth -= damage;
        if (selfhealth <= 0) {
            Damage.Invoke();
            var g = GameObject.FindGameObjectWithTag("Truck");
            g.transform.GetChild(g.transform.childCount - 1).gameObject.SetActive(true);
            g.gameObject.GetComponent<CarController>().acceleration -= 20f;
      
             g.gameObject.GetComponent<CarController>().maxspeed -= 3f;
            var boom = Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -5f), Quaternion.identity);
            Destroy(gameObject);
           
        }
        else {
            timeron = true;
            Red();
            gameObject.GetComponent<HealthBar>().SetHealth(selfhealth, maxhealth);

        }

    }

    public void Red(){
        sp.color = Color.red;
        

    }

    public void UnRed(){
        sp.color = Color.white;
    }


}
