using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearLines : MonoBehaviour
{
    public GameObject renderObject;

    private GameObject[] linePoints; 

    public void ClearLines()
    {
        linePoints = renderObject.GetComponentsInChildren<GameObject>();
        
        for(int i = 0; i < 1; i++)
        {
            Destroy(linePoints[i]);
        }

    }

}
