﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour {
    public bool DoMove = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, -MainController.s.forestMovingSpeed * Time.deltaTime), Space.World);
	}
}
