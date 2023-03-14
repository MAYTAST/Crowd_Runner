using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Transform RunnerParent;
    public void Run()
    {
       for (int i = 0; i < RunnerParent.childCount; i++)
       {
            Animator RunnerAnimator =RunnerParent.GetChild(i).GetComponent<Animator>();
            RunnerAnimator.Play("Run");
       }
    }
    public void Idle()
    {
       for (int i = 0; i < RunnerParent.childCount; i++)
       {
            Animator RunnerAnimator = RunnerParent.GetChild(i).GetComponent<Animator>();
            RunnerAnimator.Play("Idle");
       }
    }
}
