using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class trailScript : MonoBehaviour
{

    public GameObject prefab;
    public GameObject cam;
    //public List<GameObject> Points = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            Vector3 camPos = cam.transform.position;
            Vector3 camDir = cam.transform.forward;
            Quaternion camRot = cam.transform.rotation;
            float spawnLineDist = 2;
            Vector3 spawnPos = camPos + (camDir * spawnLineDist);
            GameObject cur = Instantiate(prefab, spawnPos, camRot);
            cur.transform.SetParent(this.transform);
        }
    }
}