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
        buildingSpawner = GameObject.Find("InitialCity(Clone)").GetComponent<BuildingSpawner>();
        target = buildingSpawner.targetPos;
        initial = this.transform.position;
        speed = setup.Expansion / 2;
    }
	
	// Update is called once per frame
	void Update () {
        current = this.transform.position;
        if (current != target)
        {
            current.x += Random.Range(-0.01f, .01f);
            current.z += Random.Range(-0.01f, 0.01f);
            
        }
        //speed = (Vector3.Distance(initial, target) / buildingSpawner.maxTime);
        if (current == target)
        {
            int rnd = Random.Range(0, ListChecker.Values.Count);
            current.x += Random.Range(-0.02f, .02f);
            current.z += Random.Range(-0.02f, 0.02f);
            target = new Vector3(ListChecker.Values[rnd].x, 0.3f, ListChecker.Values[rnd].y);
        }
        this.transform.position = Vector3.MoveTowards(current, target, Time.deltaTime * speed);
    }
}
