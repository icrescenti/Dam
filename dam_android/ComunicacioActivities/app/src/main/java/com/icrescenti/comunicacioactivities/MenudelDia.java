package com.icrescenti.comunicacioactivities;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import java.util.Date;
import java.util.Calendar;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

public class MenudelDia extends AppCompatActivity {

    //Variables
    private TextView titol;
    private EditText data;
    private ListView llista;
    List<String> plats;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menudel_dia);

        //Busquem els controls en el diseny i els assignem als de les variables
        titol = findViewById(R.id.titol);
        data = findViewById(R.id.data_actual);
        llista = findViewById((R.id.llista_plats));

        //Creem un ArrayList(Llista) per emmagatzemar els plats
        plats = new ArrayList<>();

        //Obtenim la data actual
        Date ara = Calendar.getInstance().getTime();

        //Inserim la data en el text
        data.setText(ara.getDay() + "/" + ara.getMonth() + "/" + ara.getYear());
        data.setEnabled(false);

        //Mostrem el missatge de benvinguda a el usuari segons el mail
        titol.setText(getResources().getString(R.string.benvingut) + " " + this.getIntent().getStringExtra("email") + "!");

        //Inserim uns plats de exemple
        plats.add("Caprese");
        plats.add("Lasaña de carne");
        plats.add("Parmigiana di melanzane");
        plats.add("Carpaccio");
        plats.add("Pasta al pesto");


        /*---ESPECULACIO---*/

        //Transformem la llista en elements "item" del ListView
        ArrayAdapter adaptadorLlista = new ArrayAdapter(
                this,
                android.R.layout.simple_list_item_1,
                plats
        );

        //Apliquem els items a la llista
        llista.setAdapter(adaptadorLlista);
    }
}