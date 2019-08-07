using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlowerPedal : MonoBehaviour {
    public SpawnFlowerFlower flowerscript;

    public bool StartMove;

    private Vector3 myfallV;
    private Vector3 myRealFallV, myRealRot;
    private Vector3 rotate;

    float t;
    // Use this for initialization
    void Start()
    {
        Vector3 fallV = flowerscript.pedalFallV;
        Vector3 rotateV = flowerscript.pedalRotV;
        rotate = new Vector3(Random.Range(-rotateV.x, rotateV.x), Random.Range(-rotateV.y, rotateV.y), Random.Range(-rotateV.y, rotateV.y));
        myfallV = new Vector3(Random.Range(-fallV.x, fallV.x), Random.Range(-fallV.y*2, -fallV.y), Random.Range(-fallV.z, fallV.z));
    }

	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, flowerscript.FlowerC, 0.2f);

        if (StartMove){
            myRealFallV = Vector3.Lerp(myRealFallV, myfallV, 0.05f);
            transform.Translate(myRealFallV, Space.Self);
            myRealRot = Vector3.Lerp(myRealRot, rotate, 0.5f);
            transform.Rotate(myRealRot, Space.Self);
        }

        t += Time.deltaTime;
        if(t > 30f){
            Destroy(gameObject);
        }
	}
}
