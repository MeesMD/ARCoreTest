using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearLines : MonoBehaviour
{
    public void ClearLines()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Debug.Log("finished clearing");
    }
}
