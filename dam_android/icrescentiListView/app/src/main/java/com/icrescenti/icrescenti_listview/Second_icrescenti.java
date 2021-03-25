package com.icrescenti.icrescenti_listview;

import androidx.appcompat.app.AppCompatActivity;

import android.net.sip.SipSession;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import java.util.ArrayList;
import java.util.List;

public class Second_icrescenti extends AppCompatActivity {
    //Declarem un component ListView que anomenarem llista.
    // ALT+Enter per importar el component
    ListView llista;
    List<String> androidVersionList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second_icrescenti);
        //1.Per connectar el listView al component visual
        //a través del id:listview ja definit
        llista= findViewById((R.id.listview));
        //Carreguem la llista d'elements
        androidVersionList = new ArrayList<>();
        //2. Carreguem elements a la llista
        androidVersionList.add("Pie");
        androidVersionList.add("Oreo");
        androidVersionList.add("Nougat");
        androidVersionList.add("Marshmallow");
        androidVersionList.add("Lollipop");
        androidVersionList.add("...");
        //3. Adaptador.Transforma aquesta llista d'strings al format visualitzable
        //del nostre listView. Es basa en una plantilla que li diu quin format
        //haurà de prendre
        ArrayAdapter adaptadorVersionsAndroid = new ArrayAdapter(
                //Per instanciar un objecte de tipus ArrayAdapter li hem de passar al Constructor
                // 3 paràmetres (1 Referència al context "this" per fer referència al MainActivity,
                // 2 referència al template layout "android.R.Layout.Simple_list_item_1",
                // 3 llista d'element que volem carregar sobre el listview "androidVersionList".)
        this,
                android.R.layout.simple_list_item_1,
                androidVersionList
 );
        //4. Ara vincularem l'adaptador amb el nostre listView anomenat 'llista'
        //i ja podrem veure la nostra llista
        llista.setAdapter(adaptadorVersionsAndroid);

        llista.setOnItemClickListener(new AdapterView.OnItemClickListener()
        {
            @Override
            public void onItemClick(AdapterView<?> adaptador, View v, int pos, long a3)
            {
                String contingut = (String)adaptador.getItemAtPosition(pos);
                Log.i("Opcio seleccionada", contingut);
            }
        });

    }

}