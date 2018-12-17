using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowards : MonoBehaviour {

    public BuildingSpawner buildingSpawner;
    Vector3 target;
    public Vector3 current;
    Vector3 initial;
    public float speed;

	// Use this for initialization
	void Start () {
        buildingSpawner = GameObject.Find("InitialBuilding(Clone)").GetComponent<BuildingSpawner>();
        target = buildingSpawner.targetPos;
        initial = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        current = this.transform.position;
        speed = (Vector3.Distance(initial, target) / buildingSpawner.maxTime);

        //Debug.Log(Vector3.Distance(Initialisation.start, target));
        //Debug.Log(speed * Time.deltaTime);
        this.transform.position = Vector3.MoveTowards(current, target, speed * Time.deltaTime);
	}
}
