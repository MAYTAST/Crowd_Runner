using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Crowd_System _crowd_System;
    void Update()
    {
        DetectDoors();
    }
     private void DetectDoors()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 1);
        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if(detectedColliders[i].TryGetComponent(out Doors doors))
            {
               doors.DisableCollider();
              int BonusAmount=doors.GetBonusAmount(transform.position.x);
              BonusType bonusType = doors.GetBonusType(transform.position.x);
              _crowd_System.ApplyBonus(BonusAmount, bonusType);
            }
            else if(detectedColliders[i].tag=="Finish")
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
