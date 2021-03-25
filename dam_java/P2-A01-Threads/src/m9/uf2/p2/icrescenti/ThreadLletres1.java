package m9.uf2.p2.icrescenti;

public class ThreadLletres1 extends Thread {
	//Creemn el constructor per al thread
	public ThreadLletres1() {
		super();
	}
	public void run() {
		//Mostrem de la a la z
		for (int i = 0; i < 26; i++)
			System.out.println("Thread lletres: " + (char)('a'+i));
	}
}
