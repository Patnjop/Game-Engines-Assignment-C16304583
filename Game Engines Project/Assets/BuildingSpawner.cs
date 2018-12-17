using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    Vector3 targetPos;
    Vector2 targetAdd;
    public GameObject buildingPrefab;
    float maxTime = 0.1f;
    public int maxRange;
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
        initialX = Random.Range(-maxRange, maxRange + 1);
        initialZ = Random.Range(-maxRange, maxRange + 1);
        targetPos = new Vector3(Mathf.RoundToInt(this.transform.position.x + initialX), 0.03f, Mathf.RoundToInt(this.transform.position.z + initialZ));
        targetAdd = new Vector2(targetPos.x, targetPos.z);
        targetPos.y = 0.25f;
       
        if (!ListChecker.Values.Contains(targetAdd))
        {
            ListChecker.Values.Add(targetAdd);
            GameObject newBuilding = Instantiate(buildingPrefab, targetPos, Quaternion.identity);
        }
        else
        {
            
        }
    }
}
