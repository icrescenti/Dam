package m9.uf2.ivancrescenti.a08;

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
        try {
            Thread.sleep(rand.nextInt(10)*1000);
            print("Cotxe matrícula " + matricula +": vol aparcar");
            
            if (parking.places_lliures > 0)
            {
                parking.ocuparPlaca();
                print("Cotxe matrícula " + matricula +": ha entrat al pàrquing");

                Thread.sleep(rand.nextInt(20)*1000);
                parking.vuidarPlaca();

                print("Cotxe matrícula " + matricula + ": surt de pàrquing");
                print("Parquing: plaça alliberada, en queden " + parking.places_lliures);
            }
            else
            {
                print("Pàrquing: no queden places lliures t'has d'esperar");
                Thread.sleep(rand.nextInt(1000));
            }

        } catch (InterruptedException e) {
            e.printStackTrace();
        }
	}

    String retornarMatricula()
    {
        return matricula;
    }

    void print(String msg)
    {
        System.out.println(msg);
    }
}
