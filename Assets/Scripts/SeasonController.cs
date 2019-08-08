using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SeasonController : MonoBehaviour {

    protected static SeasonController singleton;
    public static SeasonController s { get { return singleton; } }


    public Transform FallingPS;

    [Header("debug mode 选择 true， 否则是false")]
    public bool UseDebug;
    [Header("spring summer autumn winter")]
    public string DebugSeason;

    public Transform currentParticle;
    public string currentSeason;

    //TREES
    //public Material[] treeSpring, treeSummer, treeAutumn, treeWinter;
    public Material[] treeSeasonMat;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {

        Debug.Log(DateTime.Now.Month);
        Debug.Log(DateTime.Now.Day);

        if (UseDebug)
        {
            SwitchSeason(DebugSeason);
        }
        else
        {
            if (DateTime.Now.Month <= 2 || DateTime.Now.Month == 12)
            {
                //Winter
                SwitchSeason("winter");

            }
            else if (DateTime.Now.Month > 2 && DateTime.Now.Month <= 5)
            {
                //Spring
                SwitchSeason("spring");
            }
            else if (DateTime.Now.Month > 5 && DateTime.Now.Month <= 8)
            {
                //Summer
                SwitchSeason("summer");
            }
            else if (DateTime.Now.Month > 8 && DateTime.Now.Month <= 11)
            {
                //Autumn
                SwitchSeason("autumn");

            }
        }

    }

    void SwitchSeason(string season){
        foreach(Transform obj in FallingPS){
            if(obj.name == season){
                obj.gameObject.SetActive(true);
                currentParticle = obj;
            }else{
                obj.gameObject.SetActive(false);
            }
        }

        string treepath = "TREE/" + season;
        treeSeasonMat = Resources.LoadAll<Material>(treepath);

        currentSeason = season;

        //DO NOT SHOW ANY PARTICLES AT FIRST
        TurnOffParticles();

    }

    public void TurnOffParticles(){
        Debug.Log("Turn Off Particles emission");
        foreach (Transform kid in currentParticle) { 
            if(kid.GetComponent<ParticleSystem>()){
                kid.GetComponent<ParticleSystem>().Stop();
            }
            ParticleSystem.VelocityOverLifetimeModule vel = kid.GetComponent<ParticleSystem>().velocityOverLifetime;
            vel.yMultiplier = 10;
            vel.orbitalX = new ParticleSystem.MinMaxCurve(-1f, 1f);
            vel.orbitalY = new ParticleSystem.MinMaxCurve(-1f, 1f);
            vel.orbitalZ = new ParticleSystem.MinMaxCurve(-1f, 1f);

        }


    }

    public void TurnOnParticles(){
        Debug.Log("Turn On Particles emission");
        foreach (Transform kid in currentParticle)
        {
            if (kid.GetComponent<ParticleSystem>())
            {
                kid.GetComponent<ParticleSystem>().Play();

                ParticleSystem.VelocityOverLifetimeModule vel = kid.GetComponent<ParticleSystem>().velocityOverLifetime;
                vel.yMultiplier = 0;
                vel.orbitalX = new ParticleSystem.MinMaxCurve(-0.05f, 0.05f);
                vel.orbitalY = new ParticleSystem.MinMaxCurve(-0.05f, 0.05f);
                vel.orbitalZ = new ParticleSystem.MinMaxCurve(-0.05f, 0.05f);

            }
        }
    }


}
