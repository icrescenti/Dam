package m9.uf2.ivancrescenti.a05;

public class A05_Principal {
	public static void main(String arg[]) throws InterruptedException {

		// Genera comptador
		A05_Comptador c = new A05_Comptador();
		
		// Inicialitza dos Threads passant com a valor principal
		// el comptador generat anteriorment
		A05_ThreadComptable c1 = new A05_ThreadComptable(c);
		A05_ThreadComptable c2 = new A05_ThreadComptable(c);

		// Comen�arem l'execuci� (run) dels dos Threads
		c1.start();
		c1.join();
		c2.start();
		c2.join();
		// Eseprem que tots els threads acabin
		
		

		// Mostrem el recompte total
		System.out.println("Recompte total: " + c.getValor());
	}
		
}
