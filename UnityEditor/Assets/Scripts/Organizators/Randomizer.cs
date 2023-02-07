
using UnityEngine;
using System;

public class Randomizer: MonoBehaviour
{
    public Main[] trailers = new Main[6];
    public Enemy[] MeleeEnemies = new Enemy[1];
    public Enemy[] DistantEnemies = new Enemy[5];
    public Enemy[] Bosses = new Enemy[2];
    public System.Random random = new System.Random();
    

    public Turret[] turrets = new Turret[3];
    public EnemyTurret[] enemy_turrets = new EnemyTurret[3];
    void Start()
    {

    }   
    

  
    public GameObject SpawnRandomTrailer(Vector2 pos)
     {
           Main tr = trailers[random.Next(0, trailers.Length)];
           
       
        GameObject gg = Instantiate<GameObject>(tr.gameObject, pos, Quaternion.identity);
        gg.tag = "InactiveTrailer";
        gg.GetComponent<Rigidbody2D>().bodyType =  RigidbodyType2D.Kinematic;
        if (tr.countofturrets != 0) {
            for (int i = 0; i < tr.countofturrets; i++) {
                 GameObject tur = turrets[random.Next(0, turrets.Length)].gameObject;

                var ch = gg.transform.GetChild(i + 2);
            

                GameObject go = Instantiate<GameObject>(tur, ch.transform.position, Quaternion.identity) ;
                go.GetComponent<Turret>().enabled = false;
                go.transform.SetParent(gg.transform);
                Destroy(ch.gameObject);
            }
        }
        return gg;
    }
    public GameObject SpawnBossEnemy(Vector2 pos) {
        GameObject enemy = Instantiate(Bosses[0].gameObject, pos, Quaternion.identity);
      for (int i = 0; i < enemy.GetComponent<Enemy>().countofturrets; i++) {
             GameObject tur = enemy_turrets[random.Next(0, enemy_turrets.Length)].gameObject;

            var ch = enemy.transform.GetChild(i + 1);
            
            GameObject go = Instantiate<GameObject>(tur, ch.transform.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().turrets.Add(go.GetComponent<EnemyTurret>());
            go.transform.SetParent(enemy.transform);
            Destroy(ch.gameObject);
            
        }
         return enemy.gameObject;
    }
    public GameObject SpawnDistantEnemy(Vector2 pos) {
        var enemy = Instantiate(DistantEnemies[random.Next(0, DistantEnemies.Length)].gameObject, pos, Quaternion.identity);
        
       
        
        for (int i = 0; i < enemy.GetComponent<Enemy>().countofturrets; i++) {
             GameObject tur = enemy_turrets[random.Next(0, enemy_turrets.Length)].gameObject;

            var ch = enemy.transform.GetChild(i + 1);
            
            GameObject go = Instantiate<GameObject>(tur, ch.transform.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().turrets.Add(go.GetComponent<EnemyTurret>());
            go.transform.SetParent(enemy.transform);
            Destroy(ch.gameObject);
            
        }
         return enemy.gameObject;
    }

    public GameObject SpawnSimpleMeleeEnemy(Vector2 pos) {
        GameObject g = Instantiate(MeleeEnemies[0].gameObject, pos, Quaternion.identity);
        return g;
    }

}
