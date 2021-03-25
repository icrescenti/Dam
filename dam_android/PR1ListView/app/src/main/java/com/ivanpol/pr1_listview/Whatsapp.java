package com.ivanpol.pr1_listview;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Spinner;
import android.widget.TextView;

public class Whatsapp extends AppCompatActivity {

    //Variables
    private TextView[] msgs = new TextView[5];
    private TextView[] usuaris = new TextView[5];

    //Funcio per iniciar activity que ens mostrara el missatge
    public void oMissatge(String usuari, String missatge)
    {
        //Intent amb l'activity a inciar
        Intent i = new Intent(this, VisualitzarMissatge.class);

        //Parametres a passar
        i.putExtra("usr", usuari);
        i.putExtra("msg", missatge);

        //Inicia el Intent
        startActivity(i);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_whatsapp);

        //Assignem els controls a les variables
        usuaris[0] = findViewById(R.id.nom1);
        usuaris[1] = findViewById(R.id.nom2);
        usuaris[2] = findViewById(R.id.nom3);
        usuaris[3] = findViewById(R.id.nom4);
        usuaris[4] = findViewById(R.id.nom5);

        msgs[0] = findViewById(R.id.missatge1);
        msgs[1] = findViewById(R.id.missatge2);
        msgs[2] = findViewById(R.id.missatge3);
        msgs[3] = findViewById(R.id.missatge4);
        msgs[4] = findViewById(R.id.missatge5);


        //Mitjançant un bucle, assignem a cada TextView un event, que al ser clicat obria l'activity amb els parametres corresponents
        for (int i = 0; i<5; i++)
        {
            final int j = i;
            msgs[i].setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    oMissatge(usuaris[j].getText().toString(), msgs[j].getText().toString());
                }
            });
        }
    }
}