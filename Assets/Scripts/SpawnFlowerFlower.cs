using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlowerFlower : MonoBehaviour {
    private Vector3 myfallV;

    [Header("花朵scale范围")]
    public Vector2 scaleRange = new Vector2(0.8f, 1.6f);

    [Header("降落速度 默认值0.05")]
    public Vector3 fallV = new Vector3(0.05f, 0.05f, 0.05f);
    [Header("整朵花的z旋转速度随机范围")]
    public Vector2 rotateZRange = new Vector2(-1,1);
    [Header("花瓣降落的时间间隔范围")]
    public Vector2 flowerfallingRange = new Vector2(0.5f, 1.5f);
    [Header("花瓣降落每个axis的速度范围")]
    public Vector3 pedalFallV = new Vector3(0.7f, 0.5f, 0.7f);
    [Header("花瓣降落每个axis的旋转速度范围")]
    public Vector3 pedalRotV = new Vector3(2f, 2f, 10f);
    [Header("花的颜色")]
    public Color FlowerC = Color.white;

    private float rotateZ;
    // Use this for initialization
    void Start () {
        float s = Random.Range(scaleRange.x, scaleRange.y);
        transform.localScale = new Vector3(s, s, s);

        rotateZ = Random.Range(rotateZRange.x, rotateZRange.y);
        myfallV = new Vector3(Random.Range(-fallV.x, fallV.x), Random.Range(-fallV.y, 0), Random.Range(-fallV.z, fallV.z));
        Invoke("letgopedal", Random.Range(flowerfallingRange.x, flowerfallingRange.y));
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(myfallV, Space.Self);
        transform.Rotate(new Vector3(0, 0, rotateZ), Space.Self);
	}



    void letgopedal(){
        if (transform.childCount == 0)
            return;

        GameObject pd = transform.GetChild(Random.Range(0, transform.childCount)).gameObject;
        pd.transform.parent = null;
        pd.GetComponent<SpawnFlowerPedal>().StartMove = true;

        Invoke("letgopedal", Random.Range(flowerfallingRange.x, flowerfallingRange.y));
    }
}
