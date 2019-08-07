using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlower : MonoBehaviour {
    [Header("花朵生成距离范围")]
    public Vector3 spawnRange = new Vector3(15f, 2f, 3f);
    public GameObject summerflower, springflower, winterflower, autumnflower;


    public bool StopSpawning;
    float timer;
    GameObject flowertospawn;

	// Use this for initialization
	void Start () {
        Debug.Log("spawn");
        if(SeasonController.s.currentSeason == "spring"){
            flowertospawn = springflower;

        }else if (SeasonController.s.currentSeason == "winter")
        {
            flowertospawn = winterflower;
        }
        else if (SeasonController.s.currentSeason == "autumn")
        {
            flowertospawn = autumnflower;
        }
        else if (SeasonController.s.currentSeason == "summer")
        {
            flowertospawn = summerflower;
        }

        Invoke("spawnflower", Random.Range(1f, 2f));
	}
	
	// Update is called once per frame
	void Update () {
        if(StopSpawning){
            timer += Time.deltaTime;
            if(timer > 30){
                Destroy(gameObject);
            }
        }
	}

    void spawnflower(){
        if (StopSpawning)
            return;

        Debug.Log("spawn flower");
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange.x, spawnRange.x), Random.Range(-spawnRange.y, spawnRange.y), Random.Range(-spawnRange.z, spawnRange.z));
        GameObject newflower = Instantiate(flowertospawn, transform);
        newflower.transform.localPosition = spawnPos;
       
        newflower.SetActive(true);
        Invoke("spawnflower", Random.Range(1f, 2f));
    }
}
