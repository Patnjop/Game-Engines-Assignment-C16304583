using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {
    
    [Range(2f, 10f)]
    public int Expansion, liveCamera;
    public GameObject Pie, Free, Train;
    List<GameObject> Cameras = new List<GameObject>();
    // Use this for initialization
    void Start () {
        Pie = GameObject.Find("Pie in the Sky");
        Free = GameObject.Find("Free Cam");
        Train = GameObject.Find("Train Cam");
        Cameras.Add(Pie);
        Cameras.Add(Free);
        Cameras.Add(Train);
        Pie.transform.position = new Vector3(0f, (Expansion * 5) + 5 ,0f);
        Free.GetComponent<Camera>().enabled = false;
        Train.GetComponent<Camera>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Pie.GetComponent<Camera>().enabled == true)
        {
            if (Input.GetKey(KeyCode.W) && Pie.transform.position.y > 2)
            {
                Pie.transform.position = Vector3.Lerp(Pie.transform.position, new Vector3(Pie.transform.position.x, Pie.transform.position.y - 5, Pie.transform.position.x), Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S)&& Pie.transform.position.y < (Expansion * 10) + 20)
            {
                Pie.transform.position = Vector3.Lerp(Pie.transform.position, new Vector3(Pie.transform.position.x, Pie.transform.position.y + 5, Pie.transform.position.x), Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int c = 0; c < Cameras.Count; c++)
            {
                Cameras[c].GetComponent<Camera>().enabled = false;
            }
            if (liveCamera == 2)
            {
                liveCamera = 0;
            }
            if (liveCamera < 2)
            {
                liveCamera++;  
            }           
        }
        
        Cameras[liveCamera].GetComponent<Camera>().enabled = true;
        
    }
}
