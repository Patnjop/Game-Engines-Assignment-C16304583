using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialisation : MonoBehaviour {

    public GameObject startprefab;
    public float Radius = 0.5f;
    bool isCreated = false;
    Vector3 mouse, start;
    Vector2 initial;

    // Use this for initialization
    void Start () {
       
	}

    private void Update()
    {
        if (Input.GetMouseButton (0) && !isCreated)
        {
            mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            CreateBuilding();
            isCreated = true;
        }
    }

    void CreateBuilding()
    {
        Ray ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 1000f))
        {
            start = raycastHit.point;
        }
        else
        {
            start = Camera.main.ScreenToWorldPoint(mouse);
        }
        start.y += Radius;
        initial = new Vector2(Mathf.RoundToInt(start.x), Mathf.RoundToInt(start.z));
        //ListChecker.transforms.Add(start);
        ListChecker.Values.Add(initial);
        Instantiate(startprefab, start, Quaternion.identity);
    }
}
