package com.ivanpol.pr1_listview;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

public class Notes extends AppCompatActivity {

    //Variables
    ListView llista;
    List<String> aliments;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_notes);

        //Definicio de la llista de aliments
        aliments = new ArrayList<>();

        //Assignacio de control en la variable
        llista = findViewById((R.id.listview));

        //Opcions a mostrar en el ListView
        aliments.add("Chocolate");
        aliments.add("Llet");
        aliments.add("Queso");
        aliments.add("Carn Picata");
        aliments.add("Galletas Dinosaurio");

        //Transforma la llista "aliments" en un adaptador de Array, que transforma l'item del ArrayList en un item de ListView
        ArrayAdapter adaptadorLlista = new ArrayAdapter(
                this,
                android.R.layout.simple_list_item_1,
                aliments
        );

        //Assigna els items del ListView
        llista.setAdapter(adaptadorLlista);

        //Event al clicar alguna opcio de la llista
        llista.setOnItemClickListener(new AdapterView.OnItemClickListener()
        {
            @Override
            public void onItemClick(AdapterView<?> adaptador, View v, int pos, long a3)
            {
                //Mostra per consola l'aliment premut
                String contingut = (String)adaptador.getItemAtPosition(pos);
                Log.i("Opcio seleccionada", contingut);
            }
        });
    }
}