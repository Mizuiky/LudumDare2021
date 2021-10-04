using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsometricPlayerMovementController : MonoBehaviour
{
    //public
    public float movementSpeed = 0.05f;

    //private
    IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rbody;
    Vector2 initialPos;
    Vector2 finalPos;
    bool moving = false;
    string lastButton = "up";

    [SerializeField]
    Orientation upPos;
    [SerializeField]
    Orientation downPos;
    [SerializeField]
    Orientation leftPos;
    [SerializeField]
    Orientation rightPos;

    float horizontalMovement = 3.2f;
    float verticalalMovement = 1.4f;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void Update()
    {
        MovingDirection();

        if(moving)
        {
            rbody.position = Vector2.LerpUnclamped(rbody.position, finalPos, movementSpeed);
        }

        if(Vector2.Distance(rbody.position, finalPos) < 0.2)
        {
            CanMoveAgain();
            rbody.position = finalPos;
        }

        isoRenderer.SetDirection(lastButton, moving);
    }

    private void MovingDirection()
    {
        if(!moving)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Move(upPos);
                lastButton = "up";
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move(downPos);
                lastButton = "down";
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(leftPos);
                lastButton = "left";
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(rightPos);
                lastButton = "right";
            }
        }
    }

    

    private void Move(Orientation or)
    {
        if(or.hasTile)
        {
            initialPos = rbody.position;
            finalPos = new Vector2(or.tileBounds.center.x, or.tileBounds.center.y);
            Debug.Log(finalPos);
            moving = true;
        }   
    }

    private void CanMoveAgain()
    {
        moving = false;
    }

}