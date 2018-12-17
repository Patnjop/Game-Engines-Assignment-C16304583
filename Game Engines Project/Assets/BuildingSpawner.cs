using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    Vector3 targetPos;
    Vector2 targetAdd;
    public GameObject buildingPrefab;
    public int maxRange;
    float timer, halfRadius, maxTime;
    int count, lineCount, initialX, initialZ;
    LineRenderer line;
    bool lineDraw;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        maxTime = 0.1f;
        halfRadius = 0.25f;
        lineCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            CreateBuilding();
            timer = 0;
        }
        line.positionCount = ListChecker.Values.Count;
        if (lineDraw == true)
        {
            line.SetPosition(lineCount, new Vector3(targetPos.x, targetPos.y - halfRadius, targetPos.z));
            lineCount++;
            lineDraw = false;
        }
    }

    void CreateBuilding()
    {   
        initialX = Random.Range(-maxRange, maxRange + 1);
        initialZ = Random.Range(-maxRange, maxRange + 1);
        targetPos = new Vector3(Mathf.RoundToInt(this.transform.position.x + initialX), 0.03f, Mathf.RoundToInt(this.transform.position.z + initialZ));
        targetAdd = new Vector2(targetPos.x, targetPos.z);
        targetPos.y = halfRadius;
        lineDraw = true;
       
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
