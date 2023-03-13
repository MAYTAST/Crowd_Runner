using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Crowd_System _crowd_System;
    [SerializeField] private float _roadWidth;
    [Header("Settings")]
    [SerializeField] float _playerSpeed;
    [Header("Control")]
    [SerializeField] float _slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;


    void Update()
    {
        Moveforward();
        ManageControl();
    }
    private void Moveforward()
    {
        transform.position += Vector3.forward * Time.deltaTime * _playerSpeed;
    }
    private void ManageControl()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if(Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= _slideSpeed;

            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;
            position.x = Mathf.Clamp(position.x, -_roadWidth / 2+_crowd_System.GetCrowdRadius(), _roadWidth / 2- _crowd_System.GetCrowdRadius());
            transform.position = position;
          //  transform.position = clickedPlayerPosition + Vector3.right * xScreenDifference;
        }
    }
}
