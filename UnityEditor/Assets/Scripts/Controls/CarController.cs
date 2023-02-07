using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float acceleration = 30.0f;
    public float drift = 0.05f;
    public float turnFactor = 3.5f;

    public float maxspeed;
    
    float accelerationInput = 0;
    float steeringInput = 0;
    float velocityUp = 0;

    float rotatinAngle = 0;
    Rigidbody2D carphysics;
    

    void Awake() {
        carphysics = GetComponent<Rigidbody2D>();
    }

     void FixedUpdate() {
        AddForce();
        Velocity();
        Steering();
    }
    
    void AddForce() {

        velocityUp = Vector2.Dot(transform.up, carphysics.velocity);

       if (velocityUp > maxspeed && accelerationInput > 0){
           return;
        }
     

        if (velocityUp < -maxspeed * 0.5f && accelerationInput < 0){
            return;
        }

        if (carphysics.velocity.sqrMagnitude > maxspeed * maxspeed && accelerationInput > 0){
            return;
        }
        
        if(accelerationInput == 0) {
            carphysics.drag = Mathf.Lerp(carphysics.drag, 3.0f, Time.fixedDeltaTime * 3);

        }

        else{
            carphysics.drag = 0;
        }

        Vector2 vect = transform.up * accelerationInput * acceleration;

        carphysics.AddForce(vect, ForceMode2D.Force);

       

    }

    void Steering(){

        float minturn = carphysics.velocity.magnitude / 8;

        minturn = Mathf.Clamp01(minturn);
        rotatinAngle -= steeringInput * turnFactor * minturn;

        carphysics.MoveRotation(rotatinAngle);

    }

    public void  SetVector (Vector2 vect) {
        steeringInput = vect.x;
        accelerationInput = vect.y;

    }

    void Velocity(){
        Vector2 forwardveclocity = transform.up * Vector2.Dot(carphysics.velocity, transform.up);
        Vector2 rightvelocity = transform.right * Vector2.Dot(carphysics.velocity, transform.right);
        carphysics.velocity = forwardveclocity + rightvelocity * drift;
    }
}
