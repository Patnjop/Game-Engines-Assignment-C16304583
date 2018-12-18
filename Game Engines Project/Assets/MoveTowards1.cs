using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards1 : MonoBehaviour {

    public newCity newCity;
    Vector3 target;
    public Vector3 current;
    Vector3 initial;
    public float speed;
    Setup setup;

    // Use this for initialization
    void Start()
    {
        setup = GameObject.Find("GameManager").GetComponent<Setup>();
        newCity = GameObject.Find("newCity(Clone)").GetComponent<newCity>();
        target = newCity.targetPos1;
        initial = this.transform.position;
        speed = setup.Expansion / 2;
    }

    // Update is called once per frame
    void Update()
    {
        current = this.transform.position;
        if (current != target)
        {
            current.x += Random.Range(-0.01f, .01f);
            current.z += Random.Range(-0.01f, 0.01f);

        }
        //speed = (Vector3.Distance(initial, target) / buildingSpawner.maxTime);
        if (current == target)
        {
            int rnd = Random.Range(0, newCity.Values1.Count);
            current.x += Random.Range(-0.02f, .02f);
            current.z += Random.Range(-0.02f, 0.02f);
            target = new Vector3(newCity.Values1[rnd].x, 0.3f, newCity.Values1[rnd].y);
        }
        this.transform.position = Vector3.MoveTowards(current, target, Time.deltaTime * speed);
    }
}
