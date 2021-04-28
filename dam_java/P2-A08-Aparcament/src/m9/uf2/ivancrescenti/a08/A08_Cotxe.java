//package m9.uf2.ivancrescenti.a08;

import java.util.Random;

public class A08_Cotxe extends Thread {
    String matricula = "0001 AAA";
    A08_Parquing parking;

    public A08_Cotxe(String nom, A08_Parquing parking, String matricula)
    {
        super(nom);
        this.matricula = matricula;
        this.parking = parking;
    }

	public void run() {
        Random rand = new Random();
        //Thread.sleep(rand.nextInt(10));
	}

    String retornarMatricula()
    {
        return matricula;
    }
}
