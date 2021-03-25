package com.ivanpol.pr1_listview;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Spinner;
import android.widget.TextView;

public class VisualitzarMissatge extends AppCompatActivity {

    //Variables
    private TextView[] txts = new TextView[2];

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_visualitzar_missatge);

        //Assignem els controls a les variables
        txts[0] = findViewById(R.id.nomusuari);
        txts[1] = findViewById(R.id.missatge_rebut);

        //Assignem l'atribut de text dels controls, a els parametres rebuts per laltre activity
        txts[0].setText(this.getIntent().getStringExtra("usr"));
        txts[1].setText(this.getIntent().getStringExtra("msg"));

    }
}