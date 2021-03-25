package m9.uf2.p2.icrescenti;

public class ImplementarRunnable {
	public static void main(String[] args) {
		//Thread 1 de numeros
		Thread numeros = new Thread(new ThreadNumeros2());
		//Thread 2 de lletres
		Thread lletres = new Thread(new ThreadLletres2());
		
		//Iniciem els threads
		numeros.start();
		lletres.start();
	}
}
