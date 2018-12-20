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
    Color rndColor;

    // Use this for initialization
    void Start () {
        rndColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.7f, 1);
        setup = GameObject.Find("GameManager").GetComponent<Setup>();
        buildingSpawner = GameObject.Find("InitialCity(Clone)").GetComponent<BuildingSpawner>();
        target = buildingSpawner.targetPos;
        initial = this.transform.position;
        speed = setup.Expansion / 2;
        this.GetComponent<MeshRenderer>().material.SetColor("rnd", rndColor);
        this.GetComponent<TrailRenderer>().material.SetColor("_Random", rndColor);
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
            target = new Vector3(ListChecker.Values[rnd].x, 0.3f, ListChecker.Values[rnd].y);
        }
        this.transform.position = Vector3.MoveTowards(current, target, Time.deltaTime * speed);
    }
}
