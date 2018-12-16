using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    Vector2 initialPos;
    Vector3 targetPos;
    public GameObject buildingPrefab;
    float maxTime = 0.1f;
    public float maxRange = 0.14f;
    float timer;
    int count;
    // Use this for initialization
    void Start()
    {

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
        //Debug.Log(Vector3.Distance(targetPos, this.transform.position));
    }

    void CreateBuilding()
    {
        initialPos = Random.insideUnitCircle * 5f;
        targetPos = new Vector3((int)this.transform.position.x, 0.03f, (int)this.transform.position.z) + new Vector3((int)initialPos.x, 0f, (int)initialPos.y);
        targetPos.y = 0.03f;
        /*for (int i = 0; i < ListChecker.transforms.Count; i++)
        {
            if (Vector3.Distance(ListChecker.transforms[i], targetPos) > maxRange)
            {
                count++;
            }
            else
            {

            }
        }*/
        if (ListChecker.xValues.Contains((int)targetPos.x) && ListChecker.zValues.Contains((int)targetPos.z))
        {

        }
        else
        {
            //ListChecker.transforms.Add(targetPos);
            ListChecker.xValues.Add((int)targetPos.x);
            ListChecker.zValues.Add((int)targetPos.z);
            GameObject newBuilding = Instantiate(buildingPrefab, targetPos, Quaternion.identity);
        }
    }
}
