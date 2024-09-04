using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BaseState_Tegar adalah kelas dasar (base class) yang mewakili satu state dalam state machine.
public class BaseState_Tegar 
{
    // Properti 'name' digunakan untuk menyimpan nama dari state.
    public string name;

    // 'stateMachine' adalah referensi ke state machine yang mengatur state ini.
    // Ini digunakan untuk mengakses atau mengubah state dari state machine lain jika diperlukan.
    protected StateMachine_Tegar stateMachine;
    
    // Tambahkan variabel protected untuk menyimpan referensi ke state machine tipe MovementSM_Tegar
    protected MovementSM_Tegar sm;
    
    // Konstruktor kelas BaseState_Tegar. Menerima dua parameter:
    // 1. 'name': nama state yang akan disimpan di properti 'name'.
    // 2. 'stateMachine': referensi ke state machine yang akan disimpan di properti 'stateMachine'.
    public BaseState_Tegar(string name, StateMachine_Tegar stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
        sm = (MovementSM_Tegar)stateMachine; // Casting stateMachine menjadi tipe MovementSM_Tegar
    }

    // Metode virtual 'Enter' dapat di-override di kelas turunan untuk menentukan
    // logika yang akan dijalankan ketika state ini diaktifkan.
    public virtual void Enter() {}

    // Metode virtual 'UpdateLogic' dapat di-override di kelas turunan untuk menentukan
    // logika update yang akan dijalankan setiap frame ketika state ini aktif.
    public virtual void UpdateLogic() {}

    // Metode virtual 'UpdatePhysics' dapat di-override di kelas turunan untuk menentukan
    // logika terkait fisika yang akan dijalankan setiap frame ketika state ini aktif.
    public virtual void UpdatePhysics() {}

    // Metode virtual 'Exit' dapat di-override di kelas turunan untuk menentukan
    // logika yang akan dijalankan ketika state ini di-nonaktifkan (exited).
    public virtual void Exit() {}
}
