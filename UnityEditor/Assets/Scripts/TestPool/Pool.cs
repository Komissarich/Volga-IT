using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance;

    [Serializable]
    public struct ObjectInfo {
        public enum ObjectType{
            Bullet_1,
            Bullet_2,
            Bullet_3,
            EnemyBullet_1,
            EnemyBullet_2,
            EnemyBullet_3

        }

        public ObjectType Type;
        public GameObject prefab;
        

        public int StartCount;
    }
    public List<ObjectInfo> objectInfos;

    private Dictionary<ObjectInfo.ObjectType, PoolObject> pools;



     private void Awake() {
        if (Instance == null) {
            Instance = this;

        }
        InitPool();
    }

    public void InitPool(){
        pools = new Dictionary<ObjectInfo.ObjectType, PoolObject>();
        
        var emptyGO = new GameObject();

        foreach(var obj in objectInfos) {
            var container = Instantiate(emptyGO, transform, false);
            container.name = obj.Type.ToString();

            pools[obj.Type] = new PoolObject(container.transform);

            for (int i = 0; i < obj.StartCount; i++) {
                var go =  InstantiateObject(obj.Type, container.transform);
                go.name = go.name + i;
                pools[obj.Type].Objects.Enqueue(go);

            }
        }
        Destroy(emptyGO);


    }
    

    public GameObject InstantiateObject(ObjectInfo.ObjectType type, Transform parent) {

        var go = Instantiate(objectInfos.Find(x => x.Type == type).prefab, parent);
        pools[type].Objects.Enqueue(go);
        go.SetActive(false);
        return go;
    }


    public GameObject GetObject(ObjectInfo.ObjectType type) {
        var obj = pools[type].Objects.Count > 0 ?
            pools[type].Objects.Dequeue() : InstantiateObject(type, pools[type].Container);

        obj.SetActive(true);

        return obj;

    }


    public void DestroyObject(GameObject obj) {
      
        pools[obj.GetComponent<IPooledObject>().Type].Objects.Enqueue(obj);
        obj.SetActive(false);

    }
}
