using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
   public Transform Container {get; private set;}

    public Queue<GameObject> Objects;

    public PoolObject(Transform container) {

        Container = container;

        Objects = new Queue<GameObject>();
    }

}
