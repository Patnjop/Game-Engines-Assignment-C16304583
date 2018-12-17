using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public Vector3 targetPos;
    Vector2 targetAdd, initialPos;
    public GameObject buildingPrefab, travellerPrefab;
    float expansionFactor;
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
        expansionFactor = ((float)setup.Expansion / 10) + 0.2f;
        maxRange = Mathf.RoundToInt((setup.Expansion + 1) * (1 + (expansionFactor/2)));
        //Debug.Log(setup.Expansion);
        //Debug.Log("expansion factor is " + expansionFactor);
        //Debug.Log("max range is " + maxRange);
        //Debug.Log("building amount is " + Mathf.RoundToInt((Mathf.Pow((setup.Expansion + 2), 2) * (1 + expansionFactor))));
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
        
       
        if (!ListChecker.Values.Contains(targetAdd) && travellerCount < Mathf.RoundToInt((Mathf.Pow((setup.Expansion + 2), 2) * (1 + expansionFactor))))
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
