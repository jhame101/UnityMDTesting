using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterHydronium : MonoBehaviour {
    public Transform hydronium;

    //OnCollisionEnter is called whenever a collision is detected
    void OnCollisionEnter(Collision h) {
        //Debug.Log("Collision detected");
        if (h.gameObject.name == "hydrogen(Clone)") {       //Check if it collided with hydrogen (or just some random other molecule)  (from the public hydrogen object, which needs to be brought in from Unity)
            if ((Random.Range(0, 3) < Time.deltaTime) && h.relativeVelocity.magnitude > 10) {        //Relative velocity check and randomization check
                Instantiate(hydronium, transform.position, Quaternion.identity);        //Creating the hydronium (from the public hydronium object)
                Destroy(h.gameObject, 0);   //Destroy the hydrogen
                Destroy(transform.parent.gameObject, 0);
            }
        }
    }
}