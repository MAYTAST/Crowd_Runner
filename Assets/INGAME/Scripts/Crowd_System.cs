using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd_System : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _runnerParent;
    [Header("Elements")]
    [SerializeField] GameObject _runnerPrefab;
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
        for (int i = 0; i < _runnerParent.childCount; i++)
        {
            Vector3 childLocalPos = GetRunnerLocalPos(i);
            _runnerParent.GetChild(i).localPosition = childLocalPos;
        }
    }
    private Vector3 GetRunnerLocalPos(int index)
    {
        float x = _radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * _angle);
        float z = _radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * _angle);
        return new Vector3(x, 0, z);
    }
    public float GetCrowdRadius()
    {
        return _radius * Mathf.Sqrt(_runnerParent.childCount);
    }
    public void ApplyBonus(int BonusAmount,BonusType bonusType)
    {
        switch (bonusType)
        {
            case BonusType.Additon:
                AddBonus(BonusAmount);
                break;
            case BonusType.Product:
                int RunnerToAdd = _runnerParent.childCount* BonusAmount - _runnerParent.childCount;
                AddBonus(RunnerToAdd);
                break;
            case BonusType.Subtraction:
                RemoveBonus(BonusAmount);
                break;
            case BonusType.Division:
                int RunnerToremove =_runnerParent.childCount-(_runnerParent.childCount / BonusAmount);
                RemoveBonus(RunnerToremove);
                break;
            default:
                break;
        }
    }
    void AddBonus(int BonusAmount)
    {
        for (int i = 0; i < BonusAmount; i++)
        {
            Instantiate(_runnerPrefab, _runnerParent);
        }
       
    }
    void RemoveBonus(int BonusAmount)
    {
        if (BonusAmount>_runnerParent.childCount)
        {
            BonusAmount = _runnerParent.childCount;
        }
        int runnerAmount = _runnerParent.childCount;
        for (int i =_runnerParent.childCount-1;i>=Mathf.Clamp(runnerAmount - BonusAmount, 1,runnerAmount-BonusAmount); i--)
        {
            Transform runnerToDestroy = _runnerParent.GetChild(i);
            runnerToDestroy.SetParent(null);
            Destroy(runnerToDestroy.gameObject);
        }
    }
}
