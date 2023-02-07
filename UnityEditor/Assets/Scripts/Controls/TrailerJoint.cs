
using UnityEngine;
using UnityEngine.Events;

public class TrailerJoint : MonoBehaviour
{
    public static UnityEvent vent = new UnityEvent();
    public void OnTriggerEnter2D(Collider2D other) {
       
        if (other.gameObject.tag == "Mark") {
            Trailer(other.gameObject);
            vent.Invoke();
        }
    }

    public void Trailer(GameObject go) {
        go.transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        go.transform.parent.GetComponent<HingeJoint2D>().connectedBody = transform.parent.GetComponent<Rigidbody2D>();
        go.transform.parent.transform.position = new Vector2(transform.parent.transform.position.x, go.transform.parent.transform.position.y);
        transform.parent.GetComponent<CarController>().acceleration += 20f;
        transform.parent.GetComponent<CarController>().maxspeed += 3f;
        gameObject.transform.parent.GetChild(gameObject.transform.parent.childCount - 1).gameObject.SetActive(false);
        transform.parent.GetComponent<MainTruck>().trailer = go.transform.parent.gameObject.GetComponent<Main>();
        for (int i = 0; i < go.transform.parent.GetComponent<Main>().countofturrets; i ++) {
            transform.parent.GetComponent<MainTruck>().turrets.Add(go.transform.parent.GetChild(i + 2).gameObject.GetComponent<Turret>());
            go.transform.parent.GetChild(i + 2).GetComponent<Turret>().enabled = true;
        }   
        go.transform.parent.gameObject.tag = "Trailer";
        Destroy(go);

    }

}
