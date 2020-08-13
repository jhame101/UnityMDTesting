using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform prefab;    //The molecule to be spawned
    public float xSpread = 1;   //The distance in each axis that it can be spread out
    public float ySpread = 1;
    public float zSpread = 1;
    public int number = 10;     //How many to be spawned
    void Start()
    {
        for (int i = 0; i < number; i++) {
            Instantiate(prefab, transform.position + new Vector3(xSpread*Random.Range(-1f, 1f), ySpread*Random.Range(-1f, 1f), zSpread*Random.Range(-1f, 1f)), Quaternion.identity);        //Creates a new instance of the input prefab within the range of the position of the spawner asset, with no relative rotation (could randomize rotation as well by replacing Quaternion.identity with a Quaternion.Euler call)
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
