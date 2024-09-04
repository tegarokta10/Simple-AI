using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_Tegar : Grounded_Tegar
{
    private float _horizontalInput;

    // Constructor untuk Idle_Tegar
    // Memanggil constructor dari Grounded_Tegar dengan nama "Idle" dan state machine
    public Idle_Tegar(MovementSM_Tegar stateMachine) : base("Idle", stateMachine) {}

    // Override method Enter() untuk melakukan pengaturan ketika memasuki state ini
    public override void Enter()
    {
        base.Enter(); // Panggil method Enter() dari Grounded_Tegar
        sm.spriteRenderer.color = Color.black; // Karakter berubah warna menjadi hitam saat idle
        _horizontalInput = 0f; // Inisialisasi input horizontal ke 0
    }

    // Override method UpdateLogic() untuk menjalankan logika dari state ini
    public override void UpdateLogic()
    {
        base.UpdateLogic(); // Panggil method UpdateLogic() dari Grounded_Tegar
        _horizontalInput = Input.GetAxis("Horizontal"); // Ambil input horizontal dari pengguna

        // Transisi ke state Moving jika ada input horizontal
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
        {
            stateMachine.ChangeState(sm.movingState); // Ubah state ke Moving
        }
    }
}
