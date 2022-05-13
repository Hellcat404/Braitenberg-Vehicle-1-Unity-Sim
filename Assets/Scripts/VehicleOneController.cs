using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleOneController : MonoBehaviour {    
    [SerializeField]
    private GameObject engine;
    [SerializeField]
    private GameObject sensor;

    private Rigidbody rb;

    public float[,] heatmap;
    
    //Line tracking
    [SerializeField]
    private GameObject tracker;

    private LineRenderer lr;

    // Start is called before the first frame update
    void Start() {
        lr = tracker.GetComponent<LineRenderer>();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        heatmap = GameObject.Find("Heatmap").GetComponent<GenerateHeatmap>().temps;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        int sensorX = (int)sensor.transform.position.x % 256;
        int sensorY = (int)sensor.transform.position.z % 256;
        if(sensorX < 0)
            sensorX *= -1;
        if(sensorY < 0)
            sensorY *= -1;

        rb.velocity = gameObject.transform.forward * (heatmap[sensorX, sensorY]*10);
        rb.MoveRotation(Quaternion.Euler(new Vector3(0,gameObject.transform.rotation.eulerAngles.y + Random.Range(-20f,20f),0)));

        lr.positionCount++;
        lr.SetPosition(lr.positionCount-1, engine.transform.position);
        if(lr.positionCount % 50 == 0)
            lr.Simplify(0.05f);
    }
}
