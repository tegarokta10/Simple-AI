using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM_Tegar : StateMachine_Tegar
{
    // Kecepatan gerakan karakter
    public float speed = 4f;

    // Kekuatan lompatan karakter
    public float jumpForce = 14f;

    // Referensi ke komponen Rigidbody2D untuk pengaturan fisika
    public Rigidbody2D rigidbody;

    // Referensi ke komponen SpriteRenderer untuk mengubah warna sprite
    public SpriteRenderer spriteRenderer;

    // State-state yang akan dikelola oleh state machine
    [HideInInspector]
    public Idle_Tegar idleState;
    [HideInInspector]
    public Moving_Tegar movingState;
    [HideInInspector]
    public Jumping_Tegar jumpingState;

    private void Awake()
    {
        // Inisialisasi state-state dengan mengirimkan referensi ke state machine
        idleState = new Idle_Tegar(this);
        movingState = new Moving_Tegar(this);
        jumpingState = new Jumping_Tegar(this);
    }

    // Override GetInitialState untuk menentukan state awal dari state machine
    protected override BaseState_Tegar GetInitialState()
    {
        return idleState; // State awal adalah Idle
    }
}
