using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hydroniumDecay : MonoBehaviour
{
    public Transform hydrogen;      //getting the Transform objects from Unity (when you use this script, you have to manually drag and drop or select the hydrogen and water objects into teh box for this)
    public Transform water;
    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 2500) < Time.deltaTime) {        //If it passes the randomization check, it will decay
            Instantiate(hydrogen, transform.position + new Vector3(0f, -0.9f, -0.2f), Quaternion.identity);     //creating the hydrogen at approximately the right location
            Instantiate(water, transform.position, Quaternion.identity);    //Creating the water at the same position and rotation as the hydronium
            Destroy(gameObject, 0);     //destroy the hydronium
        }
    }
}
