using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessForest : MonoBehaviour {

    protected static EndlessForest singleton;
    public static EndlessForest s { get { return singleton; }}

    private void Awake()
    {
        singleton = this;
    }

    public GameObject nature;
    public Transform ForestMover;
    public bool InstantiateNext;
    int numoftree;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(InstantiateNext){
            GameObject newforest = Instantiate(nature, ForestMover) as GameObject;
            numoftree++;
            newforest.transform.localPosition = new Vector3(0, 0, 95 + 95*numoftree);
            InstantiateNext = false;
        }
	}
}
