using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Randomitem : MonoBehaviour
{
    public static Randomitem Instance;
    public GameObject[] Prefabs;
    public Vector2 minPos, maxPos;
    [HideInInspector]
    public int Heart = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        Generate();
    }
    public void Generate()
    {
        GameObject a = Instantiate(Prefabs[0], new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0), Quaternion.identity);
        GameObject b = Instantiate(Prefabs[1], new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0), Quaternion.identity);
        a.transform.SetParent(this.transform); b.transform.SetParent(this.transform);
        if (Vector3.Distance(a.transform.position, b.transform.position) < 4f)
        {
            Destroy(a); Destroy(b);
            Generate();
        }
    }
}
