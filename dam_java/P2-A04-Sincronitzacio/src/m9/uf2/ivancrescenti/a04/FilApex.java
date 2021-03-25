package m9.uf2.ivancrescenti.a04;

public class FilApex extends Thread {

    //Variables globals
    int[][] matriu;
    Resultat resultat;

    public FilApex(String nom, Resultat resultat, int[][] matriu) {

        super(nom);

        //Assignacio de parametres a vartiables globals
        this.resultat = resultat;
        this.matriu = matriu;
	}

    //Sumem el resultat obtingut a el resultat total
    public synchronized void sumarResultat(int valorSuma)
    {
        resultat.incrementaResultat(valorSuma);
    }

    public void run()
    {
        int suma = 0;
        switch(getName())
        {
            case "fil 0":
                suma += sumaFila(0, 2000);
            break;
            
            case "fil 1":
                suma += sumaFila(2000, 4000);
            break;
            
            case "fil 2":
                suma += sumaFila(4000, 6000);
            break;
            
            case "fil 3":
                suma += sumaFila(6000, 8000);
            break;
            
            case "fil 4":
                suma += sumaFila(8000, 10000);
            break;
        }
        sumarResultat(suma);
    }

    //Suma una fila de la matriu
    public int sumaFila(int inicial, int ultim)
    {
        int suma = 0;
        for (int i = inicial; i<ultim; i++)
            for (int j = 0; j<10000; j++)
            {
                suma += matriu[i][j];
            }

        return suma;
    }
}
