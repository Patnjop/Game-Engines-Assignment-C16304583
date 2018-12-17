using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowards : MonoBehaviour {

    public BuildingSpawner buildingSpawner;
    Vector3 target;
    public static Vector3 initial;
    public float speed;

	// Use this for initialization
	void Start () {
        buildingSpawner = GameObject.Find("InitialBuilding(Clone)").GetComponent<BuildingSpawner>();
        target = buildingSpawner.targetPos;
	}
	
	// Update is called once per frame
	void Update () {
        initial = this.transform.position;
        speed = (Vector3.Distance(Initialisation.start, target) / buildingSpawner.maxTime +0.1f);
        Debug.Log(speed);
        this.transform.position = Vector3.MoveTowards(initial, target, Time.deltaTime);
	}
}
