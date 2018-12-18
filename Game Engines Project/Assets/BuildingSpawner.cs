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
<<<<<<< HEAD
    int count, initialX, initialZ, travellerCount;
=======
    int count, lineCount, initialX, initialZ, travellerCount;
    LineRenderer line;
>>>>>>> parent of f9db605... Linerendering
    bool build;
    public List<GameObject> travellers = new List<GameObject>();
    public List<Vector3> targets = new List<Vector3>();
    Setup setup;

    private void Start()
    {
        setup = GameObject.Find("GameManager").GetComponent<Setup>();
<<<<<<< HEAD
        halfRadius = 0.3f;  
=======
        maxTime = 0.1f;
        halfRadius = 0.3f;
        lineCount = 1;
        
>>>>>>> parent of f9db605... Linerendering
    }

    // Update is called once per frame
    void Update()
    {
        maxTime = setup.Expansion / 2f;
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

        if (build == true && Vector3.Distance(travellers[travellerCount].GetComponent<moveTowards>().current, targets[travellerCount]) < 0.1)
        {
                GameObject newBuilding = Instantiate(buildingPrefab, targets[travellerCount], Quaternion.identity);
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
        targets.Add(targetPos);
        

        if (!ListChecker.Values.Contains(targetAdd) && travellerCount < Mathf.RoundToInt((Mathf.Pow((setup.Expansion + 2), 2) * (1 + expansionFactor))))
        {
<<<<<<< HEAD
            //Debug.Log("d");
            for (int r = 0; r < ListChecker.Values.Count; r++)
            { 
                Debug.Log(Vector2.Distance(targetAdd, new Vector2(this.transform.position.x, this.transform.position.z)));
                if (travellerCount == 0)
                {
                    Debug.Log("b");
                    ListChecker.Values.Add(targetAdd);
                    GameObject traveller = Instantiate(travellerPrefab, this.transform.position, Quaternion.identity);
                    travellers.Add(traveller);
                    build = true;
                    break;
                }
                else if (r == travellerCount)
                {
                    Debug.Log("c");
                    ListChecker.Values.Add(targetAdd);
                    GameObject traveller = Instantiate(travellerPrefab, this.transform.position, Quaternion.identity);
                    travellers.Add(traveller);
                    build = true;
                    break;
                }
                else if (Vector2.Distance(new Vector2(travellers[r].transform.position.x, travellers[r].transform.position.z), targetAdd) < Vector2.Distance(targetAdd, new Vector2(this.transform.position.x, this.transform.position.z)) && Vector2.Distance(new Vector2(travellers[r].transform.position.x, travellers[r].transform.position.z), targetAdd) < setup.Expansion)
                {
                    //Debug.Log(Vector2.Distance(ListChecker.Values[r + 1], targetAdd));
                    Debug.Log("a");
                    ListChecker.Values.Add(targetAdd);
                    GameObject traveller = Instantiate(travellerPrefab, travellers[r].transform.position , Quaternion.identity);
                    travellers.Add(traveller);
                    build = true;
                    break;
                }
            }   
            
=======
            ListChecker.Values.Add(targetAdd);   
            GameObject traveller = Instantiate(travellerPrefab, this.transform.position, Quaternion.identity);
            travellers.Add(traveller);
            build = true;
>>>>>>> parent of f9db605... Linerendering
        }
        else
        {
            
        }
    }
}
