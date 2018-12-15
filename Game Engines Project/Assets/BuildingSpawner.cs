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
        targetPos = this.transform.position + new Vector3 (initialPos.x, 0f, initialPos.y);
        targetPos.y = 0.03f;
        if (Vector3.Distance(targetPos, this.transform.position) <= 0.05)
        {
            targetPos.x *= 1.5f;
            targetPos.z *= 1.5f;
        }
        Instantiate(buildingPrefab, targetPos, Quaternion.identity);
    }
}
