package com.ivanpol.pr1_listview;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Spinner;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    //Variables
    private Spinner llista;

    //Funcions per instanciar les activities
    public void oNotes()
    {
        Intent i = new Intent(this, Notes.class);
        startActivity(i);
    }
    public void oWhatsapp()
    {
        Intent i = new Intent(this, Whatsapp.class);
        startActivity(i);
    }



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Assignacio de controls a variables
        llista = findViewById(R.id.spinner);

        //Event per detectar que el item del spinner ha estat cambiat
        llista.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parentView, View selectedItemView, int position, long id) {
                //Segons l'index del item premut, iniciara una o l'altra activity
                if(position == 1)
                {
                    oNotes();
                }
                else if (position == 2)
                {
                    oWhatsapp();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parentView) { }

        });
    }
}