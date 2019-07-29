using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunctions : MonoBehaviour {
    public GameObject EndlessForest;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HideForest(){
        EndlessForest.SetActive(false);
    }

    public void ShowForest(){
        EndlessForest.SetActive(true);
    }
}
