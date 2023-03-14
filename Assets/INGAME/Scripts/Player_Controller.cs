using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public static Player_Controller _instance;
    [Header("Elements")]
    [SerializeField] private Crowd_System _crowd_System;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private float _roadWidth;
    [SerializeField] bool CanMove;
    [Header("Settings")]
    [SerializeField] float _playerSpeed;
    [Header("Control")]
    [SerializeField] float _slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;



    private void Awake()
    {
        if(_instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void Start()
    {
        GameManager.onStateChanged+= ChangedGameState;
    }
    private void OnDestroy()
    {
        GameManager.onStateChanged -= ChangedGameState;
    }

    void Update()
    {
        if (CanMove)
        {
            Moveforward();
            ManageControl();
        }
    }
    private void ChangedGameState(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Game)
        {
            StartPlaying();
        }
    }
    private void StartPlaying()
    {
        CanMove = true;
        playerAnimator.Run();
    }
    private void StopMoving()
    {
        CanMove = false;
        playerAnimator.Idle();
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
