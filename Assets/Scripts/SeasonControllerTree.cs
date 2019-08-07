using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonControllerTree : MonoBehaviour {

    public GameObject[] TreeMesh;

    public void Start()
    {
       SwitchMats();
    }

    public void SwitchMats(){
        Debug.Log("switch mats");
        foreach(GameObject tree in TreeMesh){
            foreach(Material treemat in tree.GetComponent<Renderer>().materials){
                //Debug.Log("treemat names" + treemat.name); 
                foreach(Material targetmat in SeasonController.s.treeSeasonMat){
                    //Debug.Log("target mat  names" + targetmat.name);
                    if (treemat.name.Contains(targetmat.name)){
                        Debug.Log("MATCH" + targetmat.name + "  " + treemat.name);
                        treemat.SetColor("_Color", targetmat.GetColor("_Color"));
                    }
                }

            }
        }
    }
}
