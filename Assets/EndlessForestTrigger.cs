using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessForestTrigger : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "InstantiationTrigger")
        {
            EndlessForest.s.InstantiateNext = true;
            Debug.Log("trigger");
        }

        if(other.gameObject.name == "DestructionTrigger")
        {
            Destroy(transform.parent.gameObject);
        }
            
    }
}
