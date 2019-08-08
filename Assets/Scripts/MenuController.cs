using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    protected static MenuController singleton;
    public static MenuController s { get { return singleton; } }

    public GameObject DebugMenu;
    //public GameObject micThresholdInput;
    //public GameObject forestMovingSpeedInput;
    void Awake()
    {
        singleton = this;
    }


    public float highestMicReading;
    public GameObject restartMenu;
	// Use this for initialization
	void Start () {
        restartMenu.SetActive(false);
	}

    bool isshowingmenu;
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyUp(KeyCode.Return)){
            isshowingmenu = !isshowingmenu;
            DebugMenu.SetActive(isshowingmenu);
        }

        if(Time.time < 5f && Time.time > 1f){
            if(MainController.s.micReading > highestMicReading){
                highestMicReading = MainController.s.micReading;
            }

        }
        if(Time.time > 5f){
            if(highestMicReading == 0){
                restartMenu.SetActive(true);
                MainController.s.gameObject.SetActive(false);
                Debug.Log("PLEASE RESTART");
            }
        }
	}
}
