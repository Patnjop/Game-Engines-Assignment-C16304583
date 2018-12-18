using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public Vector3 targetPos;
    Vector2 targetAdd, initialPos;
    public GameObject buildingPrefab, travellerPrefab, InitialBuilding;
    float expansionFactor;
    public int maxRange, buildingFactor;
    float timer, halfRadius;
    public float maxTime;
    int count, initialX, initialZ;
    public int travellerCount;
    bool build, cityReady;
    public List<GameObject> travellers = new List<GameObject>();
    public List<Vector3> targets = new List<Vector3>();
    Setup setup;
    private Vector3 newcityPos;

    private void Start()
    {
        setup = GameObject.Find("GameManager").GetComponent<Setup>();
        halfRadius = 0.3f;
        cityReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        maxTime = setup.Expansion / 4f;
        expansionFactor = ((float)setup.Expansion / 10) + 0.2f;
        maxRange = Mathf.RoundToInt((setup.Expansion + 1) * (1 + (expansionFactor/2)));
        buildingFactor = Mathf.RoundToInt((Mathf.Pow((setup.Expansion + 2), 2) * (1 + expansionFactor)));
        //Debug.Log(setup.Expansion);
        //Debug.Log("expansion factor is " + expansionFactor);
        //Debug.Log("max range is " + maxRange);
        Debug.Log("building amount is " + buildingFactor);
        timer += Time.deltaTime;
        if (timer >= maxTime && build == false)
        {
            CreateBuilding();
            timer = 0;
        }

        if (cityReady == true && ListChecker.Values.Count % ((setup.Expansion + setup.Expansion) * 2) == 0)
        {
             Expand(); 
        }

        if (build == true && Vector3.Distance(travellers[travellerCount].GetComponent<moveTowards>().current, targetPos) < 0.1)
        {
                GameObject newBuilding = Instantiate(buildingPrefab, targetPos, Quaternion.AngleAxis(Random.Range(0,90), Vector3.up));
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
            xAdd = maxRange + maxRange + (maxRange / 2);
        }
        else if (rnd == 1)
        {
            xAdd = 0;
        }
        else if (rnd == 2)
        {
            xAdd = -(maxRange + maxRange + (maxRange / 2));
        }
        int rnd1 = Random.Range(0, 3);
        if (rnd1 == 0)
        {
            zAdd = maxRange + maxRange + (maxRange / 2);
        }
        else if (rnd1 == 1 && rnd != 1)
        {
            zAdd = 0;
        }
        else if (rnd1 > 0)
        {
            zAdd = -(maxRange + maxRange + (maxRange / 2));
        }
        Vector2 tempcityPos = new Vector2(this.transform.position.x + (xAdd + Random.insideUnitCircle.x) , this.transform.position.z + (zAdd + Random.insideUnitCircle.y));
        newcityPos = new Vector3(Mathf.RoundToInt(tempcityPos.x), 0.15f, Mathf.RoundToInt(tempcityPos.y));
        GameObject city = Instantiate(InitialBuilding, newcityPos, Quaternion.identity);
        cityReady = false;
    }
}
