using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {
    
    [Range(2f, 8f)]
    public int Expansion;

    GameObject plane;

	// Use this for initialization
	void Start () {
        plane = GameObject.Find("FieldArea");
        
	}
	
	// Update is called once per frame
	void Update () {
        plane.transform.localScale = new Vector3(Expansion, Expansion, Expansion);
    }
}
