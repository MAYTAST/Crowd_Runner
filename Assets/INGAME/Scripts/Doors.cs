using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BonusType { Additon, Subtraction, Product, Division }
public class Doors : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SpriteRenderer _rightDoorSprite;
    [SerializeField] SpriteRenderer _leftDoorSprite;
    [SerializeField] TextMeshPro _rightDoorText;
    [SerializeField] TextMeshPro _leftDoorText;
    [SerializeField] Collider _doorCollider;
    [Header("RIGHT-DOOR")]
    [SerializeField] BonusType _rightBounusType;
    [SerializeField] int _rightTextValue;
    [SerializeField] Color _rightDoorColor;
    [Header("LEFT-DOOR")]
    [SerializeField] BonusType _leftBounusType;
    [SerializeField] int _leftTextValue;
    [SerializeField] Color _leftDoorColor;
    // Start is called before the first frame update
   
    void Start()
    {
        _rightDoorSprite.color = _rightDoorColor;
        _leftDoorSprite.color = _leftDoorColor;
    }
    void Update()
    {
        switch (_rightBounusType)
        {
            case BonusType.Additon:
                _rightDoorText.text = "+"+_rightTextValue;
                break;
            case BonusType.Subtraction:
                _rightDoorText.text = "-" + _rightTextValue;
                break;
            case BonusType.Product:
                _rightDoorText.text = "x" + _rightTextValue;
                break;
            case BonusType.Division:
                _rightDoorText.text = "/" + _rightTextValue;
                break;
            default:
                break;
        }
        switch (_leftBounusType)
        {
            case BonusType.Additon:
                _leftDoorText.text = "+" + _leftTextValue;
                break;
            case BonusType.Subtraction:
                _leftDoorText.text = "-" + _leftTextValue;
                break;
            case BonusType.Product:
                _leftDoorText.text = "x" + _leftTextValue;
                break;
            case BonusType.Division:
                _leftDoorText.text = "/" + _leftTextValue;
                break;
            default:
                break;
        }

    }
    public int GetBonusAmount(float playerXPosition)
    {
        if(playerXPosition>0)
        {
            return _rightTextValue;
        }
        else
        {
            return _leftTextValue;
        }
        
    }
    public BonusType GetBonusType(float playerXPosition)
    {
        if (playerXPosition > 0)
        {
            return _rightBounusType;
        }
        else
        {
            return _leftBounusType;
        }
    }
    public void DisableCollider()
    {
        _doorCollider.enabled = false;
    }
}
