package com.icrescenti.ciclevidanomivan

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        Log.i("CicleVida", "Executem el mètode 'onCreate'")
    }

    override fun onStart() {
        super.onStart()
        Log.i("CicleVida", "Executem el mètode 'onStart'")
    }

    override fun onResume() {
        super.onResume()
        Log.i("CicleVida", "Executem el mètode 'onResume'")
    }

    override fun onPause() {
        super.onPause()
        Log.i("CicleVida", "Executem el mètode 'onPause'")
    }

    override fun onStop() {
        super.onStop()
        Log.i("CicleVida", "Executem el mètode 'onStop'")
    }

    override fun onDestroy() {
        super.onDestroy()
        Log.i("CicleVida", "Executem el mètode 'onDestroy'")
    }
}