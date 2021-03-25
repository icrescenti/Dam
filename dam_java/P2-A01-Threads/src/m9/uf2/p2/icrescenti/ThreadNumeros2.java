package m9.uf2.p2.icrescenti;

public class ThreadNumeros2 implements Runnable {
	//Creemn el constructor per al thread
	public ThreadNumeros2() {
		super();
	}
	public void run() {
		//Mostrem del 1 al 10
		for (int i = 1; i < 11; i++)
			System.out.println("Thread números: " + i);
	}
}
