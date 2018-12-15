using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    Vector2 initialPos;
    Vector3 targetPos;
    public GameObject buildingPrefab;
    int maxTime = 1;
    float timer;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            CreateBuilding();
            timer = 0;
        }
        Debug.Log(timer);
    }

    void CreateBuilding()
    {
        initialPos = Random.insideUnitCircle * 0.25f;  
        targetPos = this.transform.position + new Vector3 (initialPos.x, 0, initialPos.y);
        if (Vector3.Distance(targetPos, this.transform.position) <= 0.05)
        {
            targetPos *= 2f;
        }
        Instantiate(buildingPrefab, targetPos, Quaternion.identity);
    }
}
