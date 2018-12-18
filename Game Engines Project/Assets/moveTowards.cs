using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowards : MonoBehaviour {

    public BuildingSpawner buildingSpawner;
    Vector3 target;
    public Vector3 current;
    Vector3 initial;
    public float speed;
    Setup setup;

	// Use this for initialization
	void Start () {
        setup = GameObject.Find("GameManager").GetComponent<Setup>();
        buildingSpawner = GameObject.Find("InitialBuilding(Clone)").GetComponent<BuildingSpawner>();
        target = buildingSpawner.targetPos;
        initial = this.transform.position;
        speed = setup.Expansion / 2;
    }
	
	// Update is called once per frame
	void Update () {
        current = this.transform.position;
<<<<<<< HEAD
        //speed = (Vector3.Distance(initial, target) / buildingSpawner.maxTime);
        
        this.transform.position = Vector3.Lerp(current, target, Time.deltaTime * speed);
=======
        speed = (Vector3.Distance(initial, target) / buildingSpawner.maxTime);

        //Debug.Log(Vector3.Distance(Initialisation.start, target));
        //Debug.Log(speed * Time.deltaTime);
        this.transform.position = Vector3.MoveTowards(current, target, speed * Time.deltaTime);
>>>>>>> parent of f9db605... Linerendering
	}
}
