using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTrain : MonoBehaviour {

    BuildingSpawner buildingSpawner;
    Setup setup;
    Vector3 startpos;
    int radius;
    float timer;

	// Use this for initialization
	void Start () {
        buildingSpawner = GameObject.Find("InitialCity(Clone)").GetComponent<BuildingSpawner>();
        setup = GameObject.Find("GameManager").GetComponent<Setup>();
        startpos = Initialisation.start;
        setup.Cameras.Add(this.GetComponent<Camera>());
        
    }
	
	// Update is called once per frame
	void Update () {
        radius = buildingSpawner.maxRange;
        timer += Time.deltaTime * 0.5f;
        Debug.Log(radius);
        float x = Mathf.Cos(timer) * radius * 2;
        float y = 0;
        float z = Mathf.Sin(timer) * radius * 2;

        transform.position = new Vector3(startpos.x + x, y + setup.Expansion, startpos.z + z);
        transform.LookAt(startpos);
	}
}
