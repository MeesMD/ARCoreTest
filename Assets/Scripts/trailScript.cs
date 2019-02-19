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
    public List<GameObject> Points = new List<GameObject>();

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
            //Debug.Log("Touched" + camPos.x + " " + camPos.y + " " + camPos.z);
            Vector3 spawnPos = camPos + (camDir * spawnLineDist);
            GameObject cur = Instantiate(prefab, spawnPos, camRot);
            cur.transform.SetParent(this.transform);
        }
    }

    public void clearLines()
    {
        Debug.Log("Going to clear all lines");
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
        Debug.Log("Cleared all lines");
    }
}