using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crowd_Counter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] TextMeshPro _crowdCount;
    [SerializeField] Transform _runnersParent;
    void Update()
    {
        _crowdCount.text= _runnersParent.childCount.ToString();
    }
}
