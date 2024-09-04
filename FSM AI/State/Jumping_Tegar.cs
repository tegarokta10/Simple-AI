using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping_Tegar : BaseState_Tegar
{
    private MovementSM_Tegar _sm;

    private bool _grounded;
    private int _groundLayer = 1 << 6;

    // Constructor untuk Jumping_Tegar
    // Menginisialisasi state dengan nama "Jumping" dan state machine yang diberikan
    public Jumping_Tegar(MovementSM_Tegar stateMachine) : base("Jumping", stateMachine)
    {
        _sm = (MovementSM_Tegar)this.stateMachine; // Cast stateMachine menjadi MovementSM_Tegar
    }

    // Override method Enter() untuk melakukan pengaturan ketika memasuki state ini
    public override void Enter()
    {
        base.Enter(); // Panggil method Enter() dari BaseState_Tegar
        _sm.spriteRenderer.color = Color.green; // Karakter berubah warna menjadi hijau saat lompat

        // Simpan kecepatan horizontal dan terapkan gaya lompat
        Vector2 vel = _sm.rigidbody.velocity;
        vel.y = _sm.jumpForce; // Terapkan gaya lompat pada komponen Rigidbody2D
        _sm.rigidbody.velocity = vel;
    }

    // Override method UpdateLogic() untuk menjalankan logika dari state ini
    public override void UpdateLogic()
    {
        base.UpdateLogic(); // Panggil method UpdateLogic() dari BaseState_Tegar

        // Periksa apakah karakter sudah mendarat (grounded)
        if (_grounded)
        {
            // Pindah kembali ke state Idle, yang akan mengubah warna menjadi hitam
            stateMachine.ChangeState(_sm.idleState);
        }
    }

    // Override method UpdatePhysics() untuk memperbarui fisika state ini
    public override void UpdatePhysics()
    {
        base.UpdatePhysics(); // Panggil method UpdatePhysics() dari BaseState_Tegar

        // Pertahankan gerakan horizontal saat di udara
        float moveInput = Input.GetAxis("Horizontal");
        _sm.rigidbody.velocity = new Vector2(moveInput * _sm.speed, _sm.rigidbody.velocity.y);

        // Periksa apakah karakter berada di tanah (grounded)
        _grounded = _sm.rigidbody.velocity.y < Mathf.Epsilon && _sm.rigidbody.IsTouchingLayers(_groundLayer);

    }
}
