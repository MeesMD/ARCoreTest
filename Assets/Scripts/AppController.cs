using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class AppController : MonoBehaviour
{
    private List<TrackedPlane> m_newTrackedPlanes = new List<TrackedPlane>();

    public GameObject GridPrefab;
    public GameObject Portal;
    public GameObject ARCamera;

    void Start()
    {
        
    }

    void Update()
    {
        if(Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        Session.GetTrackables<TrackedPlane>(m_newTrackedPlanes, TrackableQueryFilter.New);

        for(int i = 0; i < m_newTrackedPlanes.Count; i++)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);

            grid.GetComponent<GridVisualizer>().Initialize(m_newTrackedPlanes[i]);
        }

        Touch touch;
        if(Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        TrackableHit hit;
        if(Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit))
        {
            Portal.SetActive(true);

            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

            Portal.transform.position = hit.Pose.position;
            Portal.transform.rotation = hit.Pose.rotation;

            Vector3 cameraPosition = ARCamera.transform.position;
            cameraPosition.y = hit.Pose.position.y;
            Portal.transform.LookAt(cameraPosition, Portal.transform.up);
            Portal.transform.parent = anchor.transform;
        }
    }
}
