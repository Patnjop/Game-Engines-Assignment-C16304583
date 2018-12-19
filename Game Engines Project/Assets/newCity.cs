using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCity : MonoBehaviour {

    float timer, maxTime, expansionFactor, halfRadius;
    public BuildingSpawner buildingSpawner;
    Setup setup;
    bool build;
    Vector2 initialPos, targetAdd, newCityInitial;
    public Vector3 targetPos1;
    int maxRange, travellerCount, citynumber, buildingFactor;
    public List<GameObject> travellers = new List<GameObject>();
    public GameObject travellerPrefab, buildingPrefab;
    public List<Vector2> Values1 = new List<Vector2>();

	// Use this for initialization
	void Start () {
        halfRadius = 0.3f;
        build = false;
        setup = GameObject.Find("GameManager").GetComponent<Setup>();
        buildingSpawner = GameObject.Find("InitialCity(Clone)").GetComponent<BuildingSpawner>();
        maxTime = buildingSpawner.maxTime;
        maxRange = Mathf.RoundToInt((buildingSpawner.maxRange/4) * 3);
        expansionFactor = setup.Expansion;
        newCityInitial = new Vector2(Mathf.RoundToInt(this.transform.position.x), Mathf.RoundToInt(this.transform.position.z));
        Values1.Add(newCityInitial);
        buildingSpawner.buildings.Add(this.gameObject);
        citynumber = buildingSpawner.index;
        this.gameObject.name = ("newCity" + citynumber);
        buildingFactor = buildingSpawner.buildingFactor / 2;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= maxTime * 2 && build == false)
        {
            CreateBuilding();
            timer = 0;
        }
        //Debug.Log(setup.Expansion);
        //Debug.Log("expansion factor is " + expansionFactor);
        //Debug.Log("max range is " + maxRange);
        //Debug.Log("building amount is " + buildingSpawner.buildingFactor);
        if (build == true && Vector3.Distance(travellers[travellerCount].GetComponent<MoveTowards1>().current, targetPos1) < 0.1)
        {
            Debug.Log("ff");
            GameObject newBuilding = Instantiate(buildingPrefab, targetPos1, Quaternion.AngleAxis(Random.Range(0, 90), Vector3.up));
            Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.7f, 1);
            newBuilding.GetComponent<Renderer>().material.color = color;
            newBuilding.GetComponentInChildren<Light>().color = color;
            buildingSpawner.buildings.Add(newBuilding);
            travellerCount++;
            build = false;
        }
    }

    void CreateBuilding()
    {
        initialPos = Random.insideUnitCircle * maxRange;
        targetPos1 = new Vector3(Mathf.RoundToInt(this.transform.position.x + initialPos.x), 0, Mathf.RoundToInt(this.transform.position.z + initialPos.y));
        targetAdd = new Vector2(targetPos1.x, targetPos1.z);
        targetPos1.y = halfRadius;

        if (!Values1.Contains(targetAdd) && travellerCount < Mathf.RoundToInt(buildingFactor))
        {
            Values1.Add(targetAdd);
            for (int r = 0; r < Values1.Count; r++)
            {
                if (travellerCount == 0)
                {
                    GameObject traveller = Instantiate(travellerPrefab, this.transform.position, Quaternion.identity);
                    travellers.Add(traveller);
                    build = true;
                    break;
                }
                else if (r == travellerCount)
                {
                    GameObject traveller = Instantiate(travellerPrefab, this.transform.position, Quaternion.identity);
                    travellers.Add(traveller);
                    build = true;
                    break;
                }
                else if (Vector2.Distance(new Vector2(travellers[r].transform.position.x, travellers[r].transform.position.z), targetAdd) < Vector2.Distance(targetAdd, new Vector2(this.transform.position.x, this.transform.position.z)) && Vector2.Distance(new Vector2(travellers[r].transform.position.x, travellers[r].transform.position.z), targetAdd) < 2)
                {
                    GameObject traveller = Instantiate(travellerPrefab, travellers[r].transform.position, Quaternion.identity);
                    travellers.Add(traveller);
                    build = true;
                    break;
                }
            }

        }
        else
        {

        }
    }
    
}
