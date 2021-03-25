package com.icrescenti.icrescenti_listview;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity
{
    private Button boto;

    public void oSecond_icrescenti()
    {
        Intent i = new Intent(this, Second_icrescenti.class);
        startActivity(i);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        boto = findViewById(R.id.finalitzar);
        boto.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                oSecond_icrescenti();
            }
        });
    }
}
