using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Tegar : BaseState_Tegar
{
    private MovementSM_Tegar stateMachine;

    // Constructor untuk Moving_Tegar
    public Moving_Tegar(MovementSM_Tegar stateMachine) : base("Moving", stateMachine)
    {
        this.stateMachine = stateMachine; // Simpan referensi ke MovementSM_Tegar
    }

    // Override method Enter() untuk melakukan pengaturan ketika memasuki state ini
    public override void Enter()
    {
        base.Enter(); // Panggil method Enter() dari BaseState_Tegar
        // Setel warna sprite menjadi merah saat memasuki state Moving
        stateMachine.spriteRenderer.color = Color.red;
    }

    // Override method UpdateLogic() untuk menjalankan logika dari state ini
    public override void UpdateLogic()
    {
        base.UpdateLogic(); // Panggil method UpdateLogic() dari BaseState_Tegar

        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput == 0)
        {
            // Transisi ke state Idle jika tidak ada input horizontal
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }

    // Override method UpdatePhysics() untuk memperbarui fisika dari state ini
    public override void UpdatePhysics()
    {
        base.UpdatePhysics(); // Panggil method UpdatePhysics() dari BaseState_Tegar

        // Gerakkan karakter
        float moveInput = Input.GetAxis("Horizontal");
        stateMachine.rigidbody.velocity = new Vector2(moveInput * stateMachine.speed, stateMachine.rigidbody.velocity.y);
    }

    // Override method Exit() untuk melakukan pengaturan ketika keluar dari state ini
    public override void Exit()
    {
        base.Exit(); // Panggil method Exit() dari BaseState_Tegar
        // Reset warna sprite saat keluar dari state Moving
        stateMachine.spriteRenderer.color = Color.white;
    }
}
