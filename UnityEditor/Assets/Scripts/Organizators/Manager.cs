using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Manager : MonoBehaviour
{
    public List<Wave> waves = new List<Wave>();
    public List<Enemy> enemies = new List<Enemy>();
    public int WaveNumber = 0,  firstamount, secondamount, thirdamount;
    public Transform[] shops = new Transform[3];
    public Main[] trailers = new Main[3];
    private bool isstarted = true, isspawn = false,  isshoot = true;
    private float time = 0f;
    public GameObject[] spawnpoints = new GameObject[16];
    public GameObject startwavebutton;
    public System.Random random = new System.Random();
    public MainTruck truck;
    public Text text;
    public string letters;

    private void Start() {
        letters = text.text;
        text.text = "";
        StartCoroutine(Texting());

        TrailerJoint.vent.AddListener(RemoveFromShop);
    }
    public void RemoveFromShop() {
        for(int i = 0; i < 3; i++) {
            if (trailers[i] == truck.trailer) {
                trailers[i] = null;
            }
        }
    }
    public void StartWave() {
        firstamount = waves[WaveNumber].amountofmelees;
        secondamount = waves[WaveNumber].amountofdistants;
        thirdamount = waves[WaveNumber].amountofbosses;
        startwavebutton.SetActive(false);
        isspawn = true;
        time = waves[WaveNumber].rateofspawning;
        isstarted = false;
    }


    void Update() {
        enemies.RemoveAll(item => item == null);
        if (enemies.Count == 0 && !isspawn && !isstarted) {
            isstarted = true;
            if (WaveNumber == 0) {

                FirstWave();
            }
            else {
                EndWave();
            }
            
            
        }
      

        if (isspawn) {
            if (!isshoot) {
            if (time < 0) {
                isshoot = true;
            }
            else {
                time -= Time.deltaTime;
            }

         }

         if(isshoot) {
            if (firstamount <= 0 && secondamount <= 0 && thirdamount <= 0) {
                isspawn = false;
                
            }
            isshoot = false;
            time = waves[WaveNumber].rateofspawning;
            int value = Random.Range(0, 10);
            if (value > 5 && firstamount > 0) {
                GameObject obj = spawnpoints[random.Next(0, spawnpoints.Length)];
                GameObject enemy = GetComponent<Randomizer>().SpawnSimpleMeleeEnemy(obj.transform.position);
                firstamount -= 1;
                enemies.Add(enemy.GetComponent<Enemy>());
             }
            else if(value < 5 && secondamount > 0) {
                GameObject obj = spawnpoints[random.Next(0, spawnpoints.Length)];
                GameObject enemy = GetComponent<Randomizer>().SpawnDistantEnemy(obj.transform.position);
                secondamount -= 1;
                enemies.Add(enemy.GetComponent<Enemy>());

            }
            else if (thirdamount > 0) {
                GameObject obj = spawnpoints[random.Next(0, spawnpoints.Length)];
                GameObject enemy = GetComponent<Randomizer>().SpawnBossEnemy(obj.transform.position);
                thirdamount -= 1;
                enemies.Add(enemy.GetComponent<Enemy>());
            }
         }

        }
    }

      IEnumerator Texting(){
        foreach(char abc in letters) {
            text.text += abc;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(false);
    }

    IEnumerator waiter() {
        yield return new WaitForSeconds(10);
        letters = "Каждая 5 волна - битва с боссом";
        text.text = "";
        text.gameObject.SetActive(true);
        StartCoroutine(Texting());
        yield return new WaitForSeconds(5);
        EndWave();
    }
    public void FirstWave() {
        
        letters = "После конца волны можете заглянуть на стоянку за новыми прицепами";
        text.text = "";
        text.gameObject.SetActive(true);
        StartCoroutine(Texting());
        StartCoroutine(waiter());

    }
    public void EndWave() {
        WaveNumber += 1;
        for (int i = 0; i < 3; i++) {
            if(trailers[i] == null) {
                GameObject tr = GetComponent<Randomizer>().SpawnRandomTrailer(shops[i].position);
                tr.transform.Rotate(0,0,-90f);
                trailers[i] = tr.GetComponent<Main>();
                break;
            }
        }
        text.text = "";
        letters = "Волна №" + (WaveNumber + 1).ToString();
        text.text = "";
        text.gameObject.SetActive(true);
        
        StartCoroutine(Texting());
        startwavebutton.gameObject.SetActive(true);
    }
    
    
}
