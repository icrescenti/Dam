package m9.uf2.ivancrescenti.a02;

import java.util.Random;

public class MovimentTortuga extends Thread {
    private int metres;
    public static int recorregut = 0;
    Random rand = new Random(); 

    //Creemn el constructor per al thread
	public MovimentTortuga(int metres) {
		super();
        this.metres = metres;
	}

	public void run() {
		while (recorregut<metres && MovimentLlebre.recorregut<metres)
        {
            //Genera la possibilitat 1-100
            int probabilitat = rand.nextInt(100);

            //Probabilitat 1 - Avança ràpid
            if (probabilitat < 50)
            {
                recorregut += 3;
            }
            //Rellisca
            else if (probabilitat >= 50 && probabilitat <= 70)
            {
                recorregut += 5;
            }
            //Avança lent
            else if (probabilitat >= 70)
            {
                recorregut++;
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
