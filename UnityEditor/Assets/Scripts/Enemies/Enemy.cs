using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    public HealthBar bar;

    public int scores, countofturrets;
    public static UnityEvent Die = new UnityEvent();

    public Text points, multiplier;

    public GameObject explosion;

    public List<EnemyTurret> turrets = new List<EnemyTurret>();
    public float maxhealth, currenthealth;
    private Manager Manager;

    public void OnCreate(Vector3 positionm) {
    currenthealth = maxhealth;
    transform.position = positionm;
    }

    void Start()
    {
        MainTruck.Death.AddListener(death);
        Manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        maxhealth = maxhealth * Manager.waves[Manager.WaveNumber].healthmultiplier;
        currenthealth = maxhealth;
        points = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        multiplier = GameObject.FindGameObjectWithTag("Multiplier").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        
        if (other.gameObject.tag == "Bullet" && other.gameObject.active == true) {

            other.gameObject.transform.position = new Vector2(-1000, -1000);
            Pool.Instance.DestroyObject(other.gameObject);
            currenthealth -= other.gameObject.GetComponent<Ammo>().damage;
            Pool.Instance.DestroyObject(other.gameObject);
            if (currenthealth <= 0) {
                Pool.Instance.DestroyObject(other.gameObject);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                multiplier.GetComponent<Multiplier>().Add();
                int score = 0;
                if (GetComponent<Enemy>().countofturrets == 0) {
                    score = scores;
                }
                for(int i = 0; i < GetComponent<Enemy>().countofturrets + 1; i++) {
                    score += transform.GetChild(i).GetComponent<EnemyTurret>() ? transform.GetChild(i).GetComponent<EnemyTurret>().points : 0;
                }
                string c = multiplier.GetComponent<Text>().text.Split()[1];
                points.GetComponent<Score>().ChangeText(score * ((int)(int.Parse(c) / 2)));
                
                var boom = Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -5f), Quaternion.identity);
                Destroy(gameObject);

            }
            bar.SetHealth(currenthealth, maxhealth);
        }

    }

    public void death() {
        Destroy(gameObject);
    }

}
