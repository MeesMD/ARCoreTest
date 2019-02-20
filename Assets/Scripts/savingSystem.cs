using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class savingSystem : MonoBehaviour
{

    public GameObject renderObject;
    public GameObject linePoint;

    private CurvedLinePoint[] linePoints;
    private Vector3[] linePositions;

    public void Save()
    {
        linePoints = renderObject.GetComponentsInChildren<CurvedLinePoint>();

        linePositions = new Vector3[linePoints.Length];
        for (int i = 0; i < linePoints.Length; i++)
        {
            linePositions[i] = linePoints[i].transform.position;
        };
        
        
        if (linePoints != null)
        {
            SaveObject saveObject = new SaveObject
            {
                linePoints = linePositions,
            };
            string json = JsonUtility.ToJson(saveObject);

            File.WriteAllText(Application.dataPath + "/save.txt", json);
            Debug.Log("Json Saved!");
        }
    }

    public void Load()
    {
        if(File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            for (int i = 0; i < saveObject.linePoints.Length; i++)
            {
                GameObject loadLinePoints = Instantiate(linePoint, saveObject.linePoints[i], Quaternion.identity);
                loadLinePoints.transform.SetParent(renderObject.transform);
            }

            Debug.Log("Json Loaded");
        }
        else
        {
            Debug.Log("There is no save data");
        }
    }

    private class SaveObject
    {
        public Vector3[] linePoints;
    }
}
