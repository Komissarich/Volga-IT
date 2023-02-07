using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherColider : MonoBehaviour
{
  public void OnCollisionEnter2D(Collision2D other) {
      if (other.gameObject.tag == "Bullet") {
      transform.parent.GetComponent<Main>().TakeDamage(other.gameObject.GetComponent<Ammo>().damage);
      }
  }
}
