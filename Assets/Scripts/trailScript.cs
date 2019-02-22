using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
    using Input = GoogleARCore.InstantPreviewInput;
#endif

public class trailScript : MonoBehaviour
{
    public GameObject prefab;
    public GameObject cam;

    private bool isTouchingUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            isTouchingUI = EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);

            if (isTouchingUI)
            {
                Debug.Log("Dont Draw");
                Debug.Log(Input.GetTouch(0));

            }
            else if (!isTouchingUI && Input.touchCount > 0)
            {
                Draw();
                Debug.Log("Draw");
            }
        }
    }

    private void Draw()
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


