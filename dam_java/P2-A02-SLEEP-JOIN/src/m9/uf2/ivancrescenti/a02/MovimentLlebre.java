package m9.uf2.ivancrescenti.a02;

import java.util.Random;

public class MovimentLlebre extends Thread {
    private int metres;
    public static int recorregut = 0;
    Random rand = new Random(); 

	//Creemn el constructor per al thread
	public MovimentLlebre(int metres) {
        super();
        this.metres = metres;
	}

	public void run() {
		while (recorregut<metres && MovimentTortuga.recorregut<metres)
        {
            //Genera la possibilitat 1-100
            int probabilitat = rand.nextInt(100);

            //No avança
            if (probabilitat < 20)
            {
                
            }
            //9 metres endavant
            else if (probabilitat >= 20 && probabilitat <= 40)
            {
                recorregut += 9;
            }
            //12 metres enrere
            else if (probabilitat >= 40 && probabilitat <= 50)
            {
                if (recorregut >= 0)
                    recorregut -= 12;
            }
            //1 metre endavant
            else if (probabilitat >= 50 && probabilitat <= 80)
            {
                recorregut++;
            }
            //2 metres enrere
            else if (probabilitat < 80)
            {
                if (recorregut >= 0)
                    recorregut -= 2;
            }

            //Espera 1 segon
            try
            {
                Thread.sleep(1000);
            }
            catch (InterruptedException ex)
            {
                Thread.currentThread().interrupt();
            }
        }
	}
}