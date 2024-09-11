using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementSM : StateMachine
{
    public float speed = 4f;
    public float jumpForce = 14f;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public Jumping jumpingState;

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jumping(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
    
        void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            ChangeState(idleState);
        }

    } 

}