package m9.uf2.ivancrescenti.a03;

public class ThredSleep extends Thread {

	int temps;

	public ThredSleep(String nom, int t) {
		super(nom);
		temps = t;
		start(); // Comença el fil
	}

	public void run() {

		try {
			System.out.println(getName() + " dura " + temps + " segons");
			for (int i = temps; i > 0; i--) {
				System.out.println(getName() + " queden " + i + " segons");
				Thread.sleep(1000);
			}
		} catch (InterruptedException e) {
			System.out.println("Interrupció del fil " + getName());
		}
		System.out.println(getName() + " acaba");
	}
}