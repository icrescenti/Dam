package m9.uf2.p2.icrescenti;

public class ExtendreThread {
	public static void main(String[] args) {
		//Thread 1 de numeros
		Thread numeros = new ThreadNumeros1();
		//Thread 1 de lletres
		Thread lletres = new ThreadLletres1();
		
		//Iniciem els threads
		numeros.start();
		lletres.start();
	}
}