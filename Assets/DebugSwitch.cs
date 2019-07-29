using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSwitch : MonoBehaviour {
	public bool TurnOnParticles;
	public bool TurnOffParticles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(TurnOnParticles){

            TurnOnParticles = false;
        }

        if(TurnOffParticles){

            TurnOffParticles = false;
        }
	}
}
