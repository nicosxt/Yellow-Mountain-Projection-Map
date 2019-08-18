using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

    protected static MainController singleton;
    public static MainController s { get { return singleton; } }

    [Header("true - 现在在放森林场景 /  false - 现在在放桃花场景")]
    public bool isPlayingForestScene = true;
    public bool animationTriggered;//triggered on the beginning of show/hide animation

    [Header("mic读数需要启动动画的最低读数(0 to 1)")]
    public float micThreshold = 0.5f;

    [Header("mic读数(0 to 1)")]
    public float micReading;

    [Header("森林移动的速度-默认值5")]
    public float forestMovingSpeed;

    [Header("花朵播放多少秒之后自动变回森林， 默认15")]
    public float ShowForestTimeOut = 15;
    float showforestTimer;

    public GameObject CameraObj;

    public GameObject FlowerSpawnTemplate, FlowerSpawnPosition;
    public GameObject currentFlowerSpawner;

    public InputField micThresholdInput, forestMovingSpeedInput;


    [Header("声音响度影响粒子效果速度的程度")]
    public float speedInfluencer = 0.5f;



    private void Awake()
    {
        singleton = this;
        isPlayingForestScene = true;
        Screen.SetResolution(1920, 644, true);
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
        //Debug.Log("anim>>>>>>>>>>>>>>:" + GetComponent<Animator>().GetBool("ShowParticles"));
        if(Input.GetKeyUp(KeyCode.A))
        {
            HideParticles();
        }

        if(!isPlayingForestScene){
            showforestTimer += Time.deltaTime;
            if(showforestTimer > ShowForestTimeOut){
                if(!animationTriggered){
                    HideParticles();
                    animationTriggered = true;
                }
              
            }
            InfluenceSpeed();
        }

       

    }

    public void InfluenceSpeed(){
        foreach(Transform ps in SeasonController.s.currentParticle){
            if(ps.GetComponent<ParticleSystem>()){
                ParticleSystem.MainModule psmain = ps.GetComponent<ParticleSystem>().main;
                float newv = 0.5f + speedInfluencer * micReading;
                psmain.simulationSpeed = Mathf.Lerp(psmain.simulationSpeed, newv, 0.4f);
            }
        }

    }

    public void ShowParticles()
    {
        Debug.Log("mic triggering SHOWING PARTICLES");
        currentFlowerSpawner = Instantiate(FlowerSpawnTemplate, FlowerSpawnPosition.transform);
        currentFlowerSpawner.transform.localPosition = Vector3.zero;
        currentFlowerSpawner.SetActive(true);
        GetComponent<Animator>().SetBool("ShowParticles", true);

    }

    public void HideParticles()
    {
        if (!currentFlowerSpawner)
            return;
        Debug.Log("mic triggering HIDING PARTCLES");
        currentFlowerSpawner.GetComponent<SpawnFlower>().StopSpawning = true;
        GetComponent<Animator>().SetBool("ShowParticles", false);

    }

    public void HideParticlesFinished(){
        Debug.Log("HIDE PARTICLES FINISHED");
        isPlayingForestScene = true;
        showforestTimer = 0;
        animationTriggered = false;

    }

    public void ShowParticlesFinished()
    {
        Debug.Log("SHOW PARTICLES FINISHED");
        isPlayingForestScene = false;
        animationTriggered = false;
    }
}
