using UnityEngine;

public class Jumping : BaseState
{
    private MovementSM _sm;

    private bool _grounded;
    private int _groundLayer = 1 << 6;

    public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine)
    {
        _sm = (MovementSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        // Preserve horizontal velocity and apply jump force
        Vector2 vel = _sm.rigidbody.velocity;
        vel.y = _sm.jumpForce; // Apply the jump force
        _sm.rigidbody.velocity = vel;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // Check if the character has landed (is grounded)
        if (_grounded)
        {
            // Transition back to Idle state, which will set the color to black
            stateMachine.ChangeState(_sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Maintain horizontal movement while in the air
        float moveInput = Input.GetAxis("Horizontal");
        _sm.rigidbody.velocity = new Vector2(moveInput * _sm.speed, _sm.rigidbody.velocity.y);

        // Check if the character is grounded
        _grounded = _sm.rigidbody.velocity.y < Mathf.Epsilon && _sm.rigidbody.IsTouchingLayers(_groundLayer);
    }
}
