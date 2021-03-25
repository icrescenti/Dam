package m9.uf2.p2.icrescenti;

public class ThreadLletres2 implements Runnable {
	//Creemn el constructor per al thread
	public ThreadLletres2() {
		super();
	}
	public void run() {
		//Mostrem de la a la z
		for (int i = 0; i < 26; i++)
			System.out.println("Thread lletres: " + (char)('a'+i));
	}
}
