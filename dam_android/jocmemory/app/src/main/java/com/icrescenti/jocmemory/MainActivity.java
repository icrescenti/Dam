package com.icrescenti.jocmemory;

import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
public class MainActivity extends AppCompatActivity {
    Button play, sortir;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        play = findViewById(R.id.botoMainJugar);
        sortir = findViewById(R.id.botoMainSortir);
        play.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                System.out.println("Iniciant el joc...");
                iniciarJoc();
            }
        });
        sortir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish(); //Tanca l'aplicació - fil principal
            }
        });
    }

    private void iniciarJoc(){
        Intent i = new Intent(this, Joc.class);
        startActivity(i);
    }
}