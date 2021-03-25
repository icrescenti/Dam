package com.icrescenti.jocmemory;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;
import androidx.annotation.Nullable;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
public class Joc extends Activity {
    //Declaració dels 16 components de la vista
    ImageButton imb00, imb01, imb02, imb03, imb04, imb05, imb06, imb07,
            imb08, imb09,
            imb10, imb11, imb12, imb13, imb14, imb15;
    ImageButton[] taulell = new ImageButton[16];
    //Declaració botons de funció
    Button botoReiniciar, botoSortir;
    //Botó puntuació
    TextView textPuntuacio;
    int puntuacio;
    int encerts;
    //Imatges
    int[] imatges;
    int fondo;
    //Variables de la lógica del joc
    ArrayList<Integer> arrayDesordenat;
    ImageButton primer;
    int numeroPrimer, numeroSegon;
    boolean bloqueig = false;
    final Handler handler = new Handler();
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
//Li diguem quin Activity ha d'obrir
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_joc);
        init();
    }
//Carreguem les imatges

    private void carregarTaulell(){
        imb00 = findViewById(R.id.boto00);
        imb01 = findViewById(R.id.boto01);
        imb02 = findViewById(R.id.boto02);
        imb03 = findViewById(R.id.boto03);
        imb04 = findViewById(R.id.boto04);
        imb05 = findViewById(R.id.boto05);
        imb06 = findViewById(R.id.boto06);
        imb07 = findViewById(R.id.boto07);
        imb08 = findViewById(R.id.boto08);
        imb09 = findViewById(R.id.boto09);
        imb10 = findViewById(R.id.boto10);
        imb11 = findViewById(R.id.boto11);
        imb12 = findViewById(R.id.boto12);
        imb13 = findViewById(R.id.boto13);
        imb14 = findViewById(R.id.boto14);
        imb15 = findViewById(R.id.boto15);
//Fem la càrrega al taulell
        taulell[0] = imb00;
        taulell[1] = imb01;
        taulell[2] = imb02;
        taulell[3] = imb03;
        taulell[4] = imb04;
        taulell[5] = imb05;
        taulell[6] = imb06;
        taulell[7] = imb07;
        taulell[8] = imb08;
        taulell[9] = imb09;
        taulell[10] = imb10;
        taulell[11] = imb11;
        taulell[12] = imb12;
        taulell[13] = imb13;
        taulell[14] = imb14;
        taulell[15] = imb15;
    }
    //Carreguem els botons
    private void carregarBotons(){
        botoReiniciar = findViewById(R.id.botoJocReiniciar);
        botoSortir = findViewById(R.id.botoJocSortir);
        botoReiniciar.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                init();
            }
        });
        botoSortir.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                finish(); //Tanca l'activity i torna a la vista principal
            }
        });
    }
    private void carregarText(){
        textPuntuacio = findViewById(R.id.text_puntuacio);
        puntuacio = 0;
        encerts = 0;
        textPuntuacio.setText("Puntuació: " + puntuacio);
    }

    private void carregarImatges(){
        imatges = new int[]{
                R.drawable.la0,
                R.drawable.la1,
                R.drawable.la2,
                R.drawable.la3,
                R.drawable.la4,
                R.drawable.la5,
                R.drawable.la6,
                R.drawable.la7
        };
        fondo = R.drawable.fondo;
    }
    private ArrayList<Integer> barrejar(int longitut) {
        ArrayList<Integer> result = new ArrayList<Integer>();
        for(int i=0; i<longitut*2; i++){
            result.add(i % longitut);
        }
        Collections.shuffle(result);
        return result;
    }
    private void comprovar(int i, final ImageButton imgb){
        if(primer == null){
            primer = imgb;
            primer.setScaleType(ImageView.ScaleType.CENTER_CROP);
            primer. setImageResource((imatges[arrayDesordenat.get(i)]));
            primer.setEnabled(false);
            numeroPrimer = arrayDesordenat.get(i);
        }else{
            bloqueig = true;
            imgb.setScaleType(ImageView.ScaleType.CENTER_CROP);
            imgb. setImageResource((imatges[arrayDesordenat.get(i)]));
            imgb.setEnabled(false);
            numeroSegon = arrayDesordenat.get(i);
            if(numeroPrimer == numeroSegon){
                primer = null;
                bloqueig = false;
                encerts++;
                puntuacio++;
                textPuntuacio.setText("Puntuació: " + puntuacio);
                if(encerts == imatges.length){
                    Toast toast =
                            Toast.makeText(getApplicationContext(), "Has guanyat!!",
                                    Toast.LENGTH_LONG);
                    toast.show();
                }
            }else{
                handler.postDelayed(new Runnable() {
                    @Override

                    public void run() {

                        primer.setScaleType(ImageView.ScaleType.CENTER_CROP);
                        primer. setImageResource(fondo);
                        primer.setEnabled(true);
                        imgb.setScaleType(ImageView.ScaleType.CENTER_CROP);
                        imgb. setImageResource(fondo);
                        imgb.setEnabled(true);
                        bloqueig = false;
                        primer = null;
                        puntuacio--;

                        textPuntuacio.setText("Puntuació: " +

                                puntuacio);
                    }
                },1000); //Aturem un segon
            }
        }
    }

    private void init(){
        carregarTaulell();
        carregarBotons();
        carregarText();
        carregarImatges();
        arrayDesordenat = barrejar(imatges.length);
        //carreguem les imatges
        for(int i=0; i<taulell.length; i++){
            taulell[i].setScaleType(ImageView.ScaleType.CENTER_CROP);
            //mostrem les imatges uns segons
            taulell[i].setImageResource((imatges[arrayDesordenat.get(i)]));
            //taulell[i].setImageResource(fondo);
        }
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                for(int i=0; i<taulell.length; i++) {
                    taulell[i].setScaleType(ImageView.ScaleType.CENTER_CROP);


                    taulell[i].setImageResource((imatges[arrayDesordenat.get(i)]));
                    taulell[i].setImageResource(fondo);
                }
            }
        }, 500);
        for(int i=0; i<taulell.length; i++){
            final int j = i;
            taulell[i].setEnabled(true);
            taulell[i].setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    if(!bloqueig)
                        comprovar(j,taulell[j]);
                }
            });
        }
    }
}