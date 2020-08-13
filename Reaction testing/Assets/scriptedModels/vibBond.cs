using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vibBond : MonoBehaviour
{
    public float enthusiasm = 1f;       //how quickly it vibrates
    public float range = 0.08f;         //radius of vibration
    public float vecX, vecY, vecZ;      //the vector between the centre molecule and the vibrating one (the axis on which it's vibrating)
    float speed = 0;
    float d=0;      //displacement
    // Start is called before the first frame update
    void Start()
    {
        float magnitude = Mathf.Sqrt(Mathf.Pow(vecX, 2)+Mathf.Pow(vecY, 2)+Mathf.Pow(vecZ, 2));
        if (magnitude != 0f) {
            vecX /= magnitude;
            vecY /= magnitude;
            vecZ /= magnitude;
        }       //norming the vector so that the length doesn't contribute to the enthusiasm
    }

    // Update is called once per frame
    void Update()
    {
        //randomizing speed
        if (Random.Range(1, 5) < 2) {
            speed = Random.Range(-0.5f*enthusiasm, 0.5f*enthusiasm);
        }
        //keeping it in bounds
        if (d > range) {
            speed = Random.Range(-0.5f*enthusiasm, 0f);
        } else if (d < -range) {
            speed = Random.Range(0f, 0.5f*enthusiasm);
        }
        
        d += Time.deltaTime*speed;      //keeping track of its displacement
        transform.Translate(Time.deltaTime*speed*vecX, Time.deltaTime*speed*vecY, Time.deltaTime*speed*vecZ);
    }
}
