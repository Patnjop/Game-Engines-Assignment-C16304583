﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public Vector3 targetPos;
    Vector2 targetAdd, initialPos;
    public GameObject buildingPrefab, travellerPrefab, InitialBuilding;
    Camera Pie;
    float expansionFactor;
    public int maxRange, buildingFactor;
    float timer, halfRadius;
    public float maxTime;
    int count, initialX, initialZ, rand;
    public int travellerCount, index;
    bool build, ready, canConsolidate;
    public List<GameObject> travellers = new List<GameObject>();
    public List<Vector2> newCityRandoms = new List<Vector2>();
    public List<GameObject> buildings = new List<GameObject>();
    Setup setup;
    private Vector3 newcityPos;
    Color rndColor;
    Light childLight;

    private void Start()
    {
        childLight = GetComponentInChildren<Light>();
        rndColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.7f, 1);
        GetComponent<Renderer>().material.color = rndColor;
        childLight.color = rndColor;
        rand = 0;
        index = 0;
        setup = GameObject.Find("GameManager").GetComponent<Setup>();
        halfRadius = 0.3f;
        Pie = setup.Pie;
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        maxTime = 4 / setup.Expansion;
        expansionFactor = ((float)setup.Expansion / 10) + 0.2f;
        maxRange = Mathf.RoundToInt((setup.Expansion + 1) * (1 + (expansionFactor/2)));
        buildingFactor = Mathf.RoundToInt((Mathf.Pow((setup.Expansion + 2), 2) * (1 + expansionFactor)));
        //Debug.Log(setup.Expansion);
        //Debug.Log("expansion factor is " + expansionFactor);
        //Debug.Log("max range is " + maxRange);
        //Debug.Log("building amount is " + buildingFactor);
        Debug.Log(build);
        timer += Time.deltaTime;
        if (timer >= maxTime && build == false)
        {
            CreateBuilding();
            if (index > Mathf.RoundToInt(16 / setup.Expansion))
            {
                Consolidate();
            }
            timer = 0;
        }

        if (buildings.Count % ((setup.Expansion + setup.Expansion) * 2) == 0 && ready == false)
        {
            ready = true;
            if (index <= Mathf.RoundToInt(16 / setup.Expansion))
            {
                Expand();
            }
        }

        if (buildings.Count % ((setup.Expansion + setup.Expansion) * 2) != 0)
        {
            ready = false;
        }

        if (buildings.Count % (setup.Expansion) == 0 && canConsolidate == true)
        {
            canConsolidate = false;
            Consolidate();
            rand++;
        }

        if (buildings.Count % (setup.Expansion) != 0)
        {
            canConsolidate = true;
        }

        if (build == true && Vector3.Distance(travellers[travellerCount].GetComponent<moveTowards>().current, targetPos) < 0.1)
        {
            GameObject newBuilding = Instantiate(buildingPrefab, targetPos, Quaternion.AngleAxis(Random.Range(0,90), Vector3.up));
            Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.7f, 1);
            newBuilding.GetComponent<Renderer>().material.color = color;
            newBuilding.GetComponentInChildren<Light>().color = color;
            buildings.Add(newBuilding);
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

        if (!ListChecker.Values.Contains(targetAdd) && travellerCount < buildingFactor)
        {
            ListChecker.Values.Add(targetAdd);
            
            for (int r = 0; r < ListChecker.Values.Count; r++)
            { 
                if (travellerCount == 0)
                {
                    GameObject traveller = Instantiate(travellerPrefab, this.transform.position, Quaternion.identity);
                    Pie.transform.SetParent(traveller.transform);
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
                    GameObject traveller = Instantiate(travellerPrefab, travellers[r].transform.position , Quaternion.identity);
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

    void Expand()
    {
        int xAdd = 0;
        int zAdd = 0;
        int rnd = Random.Range(0, 3);
        if (rnd == 0)
        {
            xAdd = maxRange + maxRange;
        }
        else if (rnd == 1)
        {
            xAdd = 0;
        }
        else if (rnd == 2)
        {
            xAdd = -(maxRange + maxRange);
        }
        int rnd1 = Random.Range(0, 3);
        if (rnd1 == 0)
        {
            zAdd = maxRange + maxRange ;
        }
        else if (rnd1 == 1 && rnd != 1)
        {
            zAdd = 0;
        }
        else if (rnd1 > 0)
        {
            zAdd = -(maxRange + maxRange);
        }
        if (!newCityRandoms.Contains(new Vector2(rnd, rnd1)))
        {
            newCityRandoms.Add(new Vector2(rnd, rnd1));
            Vector2 tempcityPos = new Vector2(this.transform.position.x + (xAdd + Random.insideUnitCircle.x), this.transform.position.z + (zAdd + Random.insideUnitCircle.y));
            newcityPos = new Vector3(Mathf.RoundToInt(tempcityPos.x), 0.3f, Mathf.RoundToInt(tempcityPos.y));
            if (ready == true)
            {
                GameObject city = Instantiate(InitialBuilding, newcityPos, Quaternion.identity);
                Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.7f, 1);
                city.GetComponent<Renderer>().material.color = color;
                city.GetComponentInChildren<Light>().color = color;
                index++;
            }
        }
        else {
            Expand();
        }
    }

    void Consolidate()
    {
        if (rand == 0)
        {
            float newScale = this.transform.localScale.x - 0.1f;
            Vector3 conPos = new Vector3(this.transform.position.x, this.transform.position.y + (newScale + 0.05f), this.transform.position.z);
            if (canConsolidate == false)
            {
                GameObject newBuilding = Instantiate(buildingPrefab, conPos, Quaternion.AngleAxis(Random.Range(0, 90), Vector3.up));
                Color color = this.GetComponent<Renderer>().material.color * newScale;
                newBuilding.GetComponent<Renderer>().material.color = color;
                newBuilding.GetComponentInChildren<Light>().color = color;
                newBuilding.transform.localScale = new Vector3(newScale, newScale, newScale);
                buildings.Add(newBuilding);
            }
        }
        else
        {
            float newScale = buildings[rand].transform.localScale.x - 0.1f;
            Vector3 conPos = new Vector3(buildings[rand].transform.position.x, buildings[rand].transform.position.y + (newScale + 0.05f), buildings[rand].transform.position.z);
            if (canConsolidate == false)
            {
                GameObject newBuilding = Instantiate(buildingPrefab, conPos, Quaternion.AngleAxis(Random.Range(0, 90), Vector3.up));
                Color color = buildings[rand].GetComponent<Renderer>().material.color * newScale;
                newBuilding.GetComponent<Renderer>().material.color = color;
                newBuilding.GetComponentInChildren<Light>().color = color;
                newBuilding.transform.localScale = new Vector3(newScale, newScale, newScale);
                buildings.Add(newBuilding);
            }
        }
    }
}
