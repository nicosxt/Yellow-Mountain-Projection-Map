using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

    protected static MainController singleton;
    public static MainController s { get { return singleton; } }

    [Header("true - 现在在放森林场景 /  false - 现在在放桃花场景")]
    public bool isPlayingForestScene = true;

    [Header("mic读数需要启动动画的最低读数(0 to 1)")]
    public float micThreshold = 0.5f;

    [Header("mic读数(0 to 1)")]
    public float micReading;

    [Header("森林移动的速度-默认值5")]
    public float forestMovingSpeed;

    public GameObject CameraObj;

    public InputField micThresholdInput, forestMovingSpeedInput;

    private void Awake()
    {
        singleton = this;
        isPlayingForestScene = true;
    }

    public void ChangeValueMicThreshold(){
        micThreshold = float.Parse(micThresholdInput.text);
    }

    public void ChangeValueForestMovingSpeed()
    {
        forestMovingSpeed = float.Parse(forestMovingSpeedInput.text);
    }


    private void Update()
    {

        micReading = CameraObj.GetComponent<MicInput>().testSound;
    }

    public void ShowParticles()
    {
        GetComponent<Animator>().SetBool("ShowParticles", true);
    }

    public void HideParticles()
    {
        GetComponent<Animator>().SetBool("ShowParticles", false);
    }

    public void HideParticlesFinished(){
        Debug.Log("HIDE PARTICLES FINISHED");
        isPlayingForestScene = true;
    }

    public void ShowParticlesFinished()
    {
        Debug.Log("SHOW PARTICLES FINISHED");
        isPlayingForestScene = false;
    }
}
