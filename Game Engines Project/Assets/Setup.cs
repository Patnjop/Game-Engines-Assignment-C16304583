using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {

    [Range(2f, 10f)]
    public int Expansion, liveCamera;
    public Camera Pie, Free, Train;
    public List<Camera> Cameras = new List<Camera>();
    Camera currentCamera;

    // Use this for initialization
    void Start() {
        Cameras.Add(Pie);
        Cameras.Add(Free);
        Pie.transform.position = new Vector3(0f, (Expansion * 5) + 5, 0f);
        currentCamera = Pie;
    }

    // Update is called once per frame
    void Update() {
        if (Pie.GetComponent<Camera>().enabled == true)
        {
            if (Input.GetKey(KeyCode.W) && Pie.transform.position.y > 2)
            {
                Pie.transform.position = Vector3.Lerp(Pie.transform.position, new Vector3(Pie.transform.position.x, Pie.transform.position.y - 5, Pie.transform.position.x), Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S) && Pie.transform.position.y < (Expansion * 10) + 20)
            {
                Pie.transform.position = Vector3.Lerp(Pie.transform.position, new Vector3(Pie.transform.position.x, Pie.transform.position.y + 5, Pie.transform.position.x), Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            liveCamera++;
            if (liveCamera >= Cameras.Count)
            {
                liveCamera = 0;
            }
            Change();
        }

        Cameras[liveCamera].GetComponent<Camera>().enabled = true;

    }

    void Change()
    {
        currentCamera.enabled = false;
        currentCamera = Cameras[liveCamera];
        currentCamera.enabled = true;
    }

}
