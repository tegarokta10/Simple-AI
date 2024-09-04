using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded_Tegar : BaseState_Tegar
{
    protected MovementSM_Tegar sm;

    // Constructor untuk Grounded_Tegar
    // Menginisialisasi state dengan nama dan state machine yang diberikan
    public Grounded_Tegar(string name, MovementSM_Tegar stateMachine) : base(name, stateMachine)
    {
        sm = (MovementSM_Tegar)this.stateMachine; // Cast stateMachine menjadi MovementSM_Tegar
    }

    // Override method UpdateLogic() untuk menjalankan logika dari state ini
    public override void UpdateLogic()
    {
        base.UpdateLogic(); // Panggil method UpdateLogic() dari BaseState_Tegar

        // Periksa jika tombol ruang ditekan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Pindah ke state Jumping jika tombol ruang ditekan
            stateMachine.ChangeState(sm.jumpingState);
        }
    }
}
