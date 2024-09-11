using UnityEngine;

public class Idle : Grounded
{
    private float _horizontalInput;

    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) {}

    private Color _originalColor;

    public override void Enter()
    {
        base.Enter();
        if (_originalColor == default)
        {
            _originalColor = sm.spriteRenderer.color; // Simpan warna asli pertama kali
        }
        sm.spriteRenderer.color = _originalColor; // Kembalikan ke warna asli saat Idle
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");

        // Transition to Moving state if there is horizontal input
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
        {
            stateMachine.ChangeState(sm.movingState);
        }
    }
}
