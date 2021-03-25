package com.icrescenti.comunicacioactivities;

import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.app.AlertDialog;

public class MainActivity extends AppCompatActivity {

    //Variables
    private Boolean logejat = false;

    private Button[] botons = new Button[3];
    private EditText[] Camps = new EditText[2];

    //Inicialitzadors de activities
    public void oQuiSom()
    {
        Intent i = new Intent(this, QuiSom.class);
        startActivity(i);
    }
    public void oMenuDia(String email)
    {
        Intent i = new Intent(this, MenudelDia.class);
        i.putExtra("email", email);
        startActivity(i);
    }



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Assignacio de controls amb variables
        botons[0] = findViewById(R.id.boto_1);
        botons[1] = findViewById(R.id.boto_2);
        botons[2] = findViewById(R.id.boto_login);

        Camps[0] = findViewById(R.id.txt_email);
        Camps[1] = findViewById(R.id.txt_password);

        //Funcio d'obrir les finestres corresponents al preme el boto
        botons[0].setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            oQuiSom();
                        }
                    });
        botons[1].setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            if (logejat)
                                oMenuDia(Camps[0].getText().toString());
                            else
                                oMenuDia(getResources().getString(R.string.descdonegut));
            }
        });


        //Boto de inici de sessio
        botons[2].setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                //He optat a usar un AlertDialog(Finestra de avis) per a visualitzar erros i missatges, aixis es tot mes entenedor per al usuari
                AlertDialog alertDialog = new AlertDialog.Builder(MainActivity.this).create();

                //Emmagatzemem temporalment els valors amb variables
                String email = Camps[0].getText().toString();
                String contrasenya = Camps[1].getText().toString();

                //Valida que el email no estigui vuit, que contingui una @ i un punt
                if (!email.isEmpty() && email.contains("@") && email.contains("."))
                {
                    //Valida que la contrasenya no estigui vuida i sigui un valor numeric
                    if (!contrasenya.isEmpty() && esNumeric(contrasenya))
                    {
                        //Cambia la condicio de iniciat i ho mostra per pantalla
                        logejat = true;
                        alertDialog.setTitle(getResources().getString(R.string.sessioiniciada));
                        alertDialog.setMessage(getResources().getString(R.string.sessioiniciada_msg) + " " + email);
                        mostrarAlerta(alertDialog);
                    }
                    else
                    {
                        //Notifica que el format de la contrasenya no es correcta
                        alertDialog.setTitle(getResources().getString(R.string.contrasenya_incorrecta));
                        alertDialog.setMessage(getResources().getString(R.string.contrasenya_incorrecta_msg));
                        mostrarAlerta(alertDialog);
                    }
                }
                //Notifica que el email es incorrecte
                else
                {
                    alertDialog.setTitle(getResources().getString(R.string.email_incorrecte));
                    alertDialog.setMessage(getResources().getString(R.string.email_incorrecte_msg));
                    mostrarAlerta(alertDialog);
                }

            }
        });
    }

    //Mostra el AlertDialog amb el missatge i un boto de acceptar
    void mostrarAlerta(AlertDialog alertDialog)
    {
        alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL, getResources().getString(R.string.acceptar),
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                });
        alertDialog.show();
    }

    //Aquesta funcio es un simple try catch per comprovar que la string es pot transformar en integer
    boolean esNumeric(String v) {
        try {
            Integer.parseInt(v);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }
}