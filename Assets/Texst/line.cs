using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    [Range(0,360)]
    public float angle;
    LineRenderer l;
    Vector3[] poss;
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<LineRenderer>();
        poss = new Vector3[2];
    }

    // Update is called once per frame
    void Update()
    {
        poss[0] = new Vector3(0, 0, 0);
        float rad = Mathf.Deg2Rad * angle;
        poss[1] = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
        l.SetPositions(poss);
    }
}