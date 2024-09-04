using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StateMachine_Tegar adalah kelas yang mengatur state-state dalam game.
// Kelas ini bertanggung jawab untuk memindahkan antara state yang berbeda.
public class StateMachine_Tegar : MonoBehaviour
{
    // Variabel 'currentState' menyimpan state yang sedang aktif.
    BaseState_Tegar currentState;

    // Method Start() dipanggil saat script pertama kali dijalankan.
    // Ini menginisialisasi state pertama dan memanggil metode Enter() dari state tersebut.
    void Start()
    {
        currentState = GetInitialState(); // Mendapatkan state awal
        if (currentState != null)
            currentState.Enter(); // Memasuki state awal
    }

    // Method Update() dipanggil sekali per frame.
    // Ini digunakan untuk menjalankan logika state yang aktif.
    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic(); // Update logika dari state saat ini
    }

    // Method LateUpdate() dipanggil setelah Update() setiap frame.
    // Ini digunakan untuk menjalankan logika fisika dari state yang aktif.
    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics(); // Update fisika dari state saat ini
    }

    // Method GetInitialState() menentukan state awal.
    // Di kelas ini, ia hanya mengembalikan null dan bisa di-override di kelas turunan untuk mengembalikan state yang diinginkan.
    protected virtual BaseState_Tegar GetInitialState()
    {
        return null; // Secara default, tidak ada state awal
    }

    // Method ChangeState(BaseState_Tegar newState) digunakan untuk mengganti state yang aktif.
    // Ini memanggil Exit() pada state saat ini dan Enter() pada state baru.
    public void ChangeState(BaseState_Tegar newState)
    {
        currentState.Exit(); // Keluar dari state saat ini

        currentState = newState; // Ubah state ke state baru
        newState.Enter(); // Memasuki state baru
    }

    // Method OnGUI() digunakan untuk menampilkan GUI sederhana di layar.
    // Ini menampilkan nama state yang sedang aktif.
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f)); // Menentukan area GUI
        string content = currentState != null ? currentState.name : "(no current state)"; // Menampilkan nama state saat ini
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>"); // Label yang menampilkan nama state
        GUILayout.EndArea(); // Mengakhiri area GUI
    }
}
