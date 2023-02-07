using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class MainTruck : MonoBehaviour
{
    public Main trailer;
    public int intToSave;
    public GameObject canv, explosion;
    public Text points;
    public static UnityEvent Damage = new UnityEvent();
    public static UnityEvent Death = new UnityEvent();
    public List<Turret> turrets = new List<Turret>();
    public SpriteRenderer sp;
    public float selfhealth = 100f, maxhealth = 100f, currenttime, damageduration ;
    private bool timeron = false;
    public Manager Manager;

    void Start(){
        Manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        sp = gameObject.GetComponent<SpriteRenderer>();
        currenttime = damageduration;
        points = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
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

    public void Destr(){
        trailer.GetComponent<Main>().TakeDamage(10000);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.tag == "Enemy_bullet") {
        float a = other.GetComponent<Ammo>().damage;
      
        TakeDamage(a);
        }
    }

    public void TakeDamage(float damage){
        damage = damage * Manager.waves[Manager.WaveNumber].damagemultiplier;
        Damage.Invoke();
        selfhealth -= damage;
        if (selfhealth <= 0) {
            Manager.enabled = false;
            gameObject.SetActive(false);
            string c = points.GetComponent<Text>().text.Split()[1];
            if (PlayerPrefs.HasKey("SavedInteger")) {
                if (int.Parse(c) > PlayerPrefs.GetInt("SavedInteger")) {
                    PlayerPrefs.SetInt("SavedInteger", int.Parse(c));
                }

            }
            else {
                 PlayerPrefs.SetInt("SavedInteger", int.Parse(c));
            }


            canv.SetActive(true);
            Death.Invoke();

            canv.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Твой счет: " + c; 
            canv.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Лучший счет: " + PlayerPrefs.GetInt("SavedInteger"); 
            canv.transform.position = gameObject.transform.position;

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
