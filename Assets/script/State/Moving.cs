using UnityEngine;

public class Moving : BaseState
{
    
    private MovementSM stateMachine;

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput == 0)
        {
            // Transition to Idle state if no horizontal input
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Move the character
        float moveInput = Input.GetAxis("Horizontal");
        stateMachine.rigidbody.velocity = new Vector2(moveInput * stateMachine.speed, stateMachine.rigidbody.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        // Reset the sprite color when exiting the Moving state
        stateMachine.spriteRenderer.color = Color.white;
    }
}