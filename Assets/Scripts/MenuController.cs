using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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

    public GameObject PasswordUIGameObject, PasswordUIInput;
    public float highestMicReading;
    public GameObject restartMenu;

    public DateTime datenow, datebar;
    [Header("小于0:没到催款截止日， 大于0:过了催款截止日")]
    public int comparedDates;//0

	// Use this for initialization
	void Start () {
        restartMenu.SetActive(false);

        datenow = DateTime.Now;
        datebar = new DateTime(2019, 12, 23);

        comparedDates = DateTime.Compare(datenow, datebar);

        ShowText();

	}

    bool isshowingmenu;
	


	// Update is called once per frame
	void Update () {

        if(Input.GetKeyUp(KeyCode.Space)){
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

    public void ShowText(){
        if(PlayerPrefs.GetInt("GotPaid") == 1){
            PasswordUIGameObject.SetActive(false);
            return;
        }


        if(comparedDates > 0){
            PasswordUIGameObject.SetActive(true);
        }else{
            PasswordUIGameObject.SetActive(false);
        }
    }

    public void HideText()
    {
        if (comparedDates < 0)
            return;

        if(PasswordUIInput.GetComponent<Text>().text == "GotPaid"){
            PasswordUIGameObject.SetActive(false);
            PlayerPrefs.SetInt("GotPaid", 1);
        }


    }
}
