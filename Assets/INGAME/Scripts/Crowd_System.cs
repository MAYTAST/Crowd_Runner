using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd_System : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform _runnerParents;
    [Header("Settings")]
    [SerializeField] private float _radius;
    [SerializeField] private float _angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceRunner();
    }
    void PlaceRunner()
    {
        for (int i = 0; i < _runnerParents.childCount; i++)
        {
            Vector3 childLocalPos = GetRunnerLocalPos(i);
            _runnerParents.GetChild(i).localPosition = childLocalPos;
        }
    }
    private Vector3 GetRunnerLocalPos(int index)
    {
        float x = _radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * _angle);
        float z = _radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * _angle);
        return new Vector3(x, 0, z);
    }
}
