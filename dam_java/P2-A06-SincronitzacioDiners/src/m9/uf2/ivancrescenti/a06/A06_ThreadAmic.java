package m9.uf2.ivancrescenti.a06;

	
public class A06_ThreadAmic extends Thread {
    
    A06_CompteCompartit compte;
    String nom;

    public A06_ThreadAmic(A06_CompteCompartit compte, String nom) {
        super(nom);

        this.compte = compte;
        this.nom = nom;
    }

    public synchronized void retirarDiners(double valorRetirar)
    {
        if(compte.retirarDiners(valorRetirar))
            print(nom + ": retirada de diners realitzada correctament.");
        else
            print(nom + ": no s'han pogut treure els diners.");

        print(nom + ": el saldo és de " + compte.saldo + "€");
    }

    public void run() {
        for (int i = 0; i<3; i++)
        {
            retirarDiners(10);
        }
    }

    //Mostra un missatge
	private static void print(String msg)
	{
		System.out.println(msg);
	}
}
