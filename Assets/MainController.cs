using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    protected static MainController singleton;
    public static MainController s { get { return singleton; } }

    private void Awake()
    {
        singleton = this;
    }
    public void ShowParticles()
    {
        GetComponent<Animator>().SetBool("ShowParticles", true);
    }

    public void HideParticles()
    {
        GetComponent<Animator>().SetBool("ShowParticles", false);
    }
}
