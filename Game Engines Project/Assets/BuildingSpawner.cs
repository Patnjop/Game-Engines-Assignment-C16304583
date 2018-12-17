using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    Vector3 initialPos, targetPos;
    Vector2 targetAdd;
    public GameObject buildingPrefab;
    float maxTime = 1f;
    public float maxRange;
    float timer;
    int count, initialX, initialZ;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            CreateBuilding();
            timer = 0;
        }
        for (int i = 0; i < ListChecker.Values.Count; i++)
        {
            Debug.Log(ListChecker.Values[i]);
        }
    }

    void CreateBuilding()
    {
        initialX = Random.Range(-4, 4);
        initialZ = Random.Range(-4, 4);
        //initialPos = new Vector3(initialX, 0f, initialZ);
        targetPos = new Vector3(Mathf.RoundToInt(this.transform.position.x + initialX), 0.03f, Mathf.RoundToInt(this.transform.position.z + initialZ));
        targetAdd = new Vector2(targetPos.x, targetPos.z);
        targetPos.y = 0.03f;
       
        if (ListChecker.Values.Contains(targetPos))
        {
            
        }
        else
        {
            ListChecker.Values.Add(targetAdd);
            GameObject newBuilding = Instantiate(buildingPrefab, targetPos, Quaternion.identity);
        }
    }
}
