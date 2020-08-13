using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script starts the molecules going at the beginning, and also keeps them in the right velocity range for the simulation (accounts for drag from collisions, etc.). It also gives molecules a bit of a boost right after a reaction since those work by destroying existing objects and creating new ones. This may or may not be desired (more testing is needed).

public class rigidPush : MonoBehaviour
{
    public float initialEnthusiasm = 3f;
    public float constantEnthusiasm = 0.5f;
    public float constantSlowdown = 0.5f;
    
    private Rigidbody self;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Rigidbody>();   //Variable to store the Rigidbody component of the molecule this is applied to
        self.AddForce(initialEnthusiasm*Random.Range(-5f, 5f), initialEnthusiasm*Random.Range(-5f, 5f), initialEnthusiasm*Random.Range(-5f, 5f), ForceMode.Impulse);    //initial push, happens when the molecule is created
    }

    // Update is called once per frame
    void Update()
    {
        self.AddForce(self.velocity.x*constantEnthusiasm*Time.deltaTime, self.velocity.y*constantEnthusiasm*Time.deltaTime, self.velocity.z*constantEnthusiasm*Time.deltaTime, ForceMode.Impulse);      //Adds velocity in the direction it's going
        if (self.velocity.magnitude < 0.5f) {
            self.AddForce(self.velocity.x*constantEnthusiasm*Time.deltaTime/self.velocity.magnitude, self.velocity.y*constantEnthusiasm*Time.deltaTime/self.velocity.magnitude, self.velocity.z*constantEnthusiasm*Time.deltaTime/self.velocity.magnitude, ForceMode.Impulse);      //Speeds it up if it's going too slowly. Note that this will break if the velocity somehow gets to be exactly 0.
        } else if (self.velocity.magnitude > 15f) {
            self.AddForce(-1*self.velocity.x*constantSlowdown*Time.deltaTime, -1*self.velocity.y*constantSlowdown*Time.deltaTime, -1*self.velocity.z*constantSlowdown*Time.deltaTime, ForceMode.Impulse);       //Slows it down if it's going too quickly. This was an attempt to fix the bug where the atoms can get through the wall of the box.
        }
    }
}
