using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public Vector3 targetPos;
    Vector2 targetAdd, initialPos;
    public GameObject buildingPrefab, travellerPrefab;
    int maxRange;
    float timer, halfRadius;
    public float maxTime;
    int count, lineCount, initialX, initialZ, travellerCount;
    LineRenderer line;
    bool build;
    public List<GameObject> travellers = new List<GameObject>();
    Setup setup;

    private void Start()
    {
        setup = GameObject.Find("GameManager").GetComponent<Setup>();
        maxTime = 0.1f;
        halfRadius = 0.3f;
        lineCount = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        maxRange = setup.Expansion / 2;
        timer += Time.deltaTime;
        if (timer >= maxTime && build == false)
        {
            CreateBuilding();
            timer = 0;
        }

        if (build == true && travellers[travellerCount].GetComponent<moveTowards>().current == targetPos)
        {
                GameObject newBuilding = Instantiate(buildingPrefab, targetPos, Quaternion.identity);
                travellerCount++;
                build = false;
        }

    }

    void CreateBuilding()
    {   
        initialPos = Random.insideUnitCircle * maxRange;
        targetPos = new Vector3(Mathf.RoundToInt(this.transform.position.x + initialPos.x), 0.03f, Mathf.RoundToInt(this.transform.position.z + initialPos.y));
        targetAdd = new Vector2(targetPos.x, targetPos.z);
        targetPos.y = halfRadius;
        
        //lineDraw = true;
       
        if (!ListChecker.Values.Contains(targetAdd))
        {
            ListChecker.Values.Add(targetAdd);   
            GameObject traveller = Instantiate(travellerPrefab, this.transform.position, Quaternion.identity);
            travellers.Add(traveller);
            build = true;
        }
        else
        {
            
        }
    }
}
