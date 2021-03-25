package m9.uf2.ivancrescenti.a02;

public class MostrarCursa extends Thread {
	private int metres;

	//Creemn el constructor per al thread
	public MostrarCursa(int metres) {
		super();
        this.metres = metres;
	}

    public void run()
	{
		//Mostra el progrss de la cursa, sempre que no hagi acabat
		while (MovimentTortuga.recorregut < metres && MovimentLlebre.recorregut < metres)
		{
			clear();
			System.out.println("La cursa acaba de començar");
			generarLineas("Tortuga", MovimentTortuga.recorregut);
			generarLineas("Llebre", MovimentLlebre.recorregut);
		}

		//Mostra el guanyador
		if (MovimentTortuga.recorregut >= metres)
			System.out.print("La senyora tortugeta ha guanyat!");
		else
			System.out.print("Desaforunadament, la llebre ha guanyat.");
	}

	//Genera de manera visual amb guions la cursa
	private static void generarLineas(String nom, int recorregut)
	{
		System.out.print(nom + "(" + recorregut + "): ");
		for (int i = 0; i < recorregut-1; i++)
		{
			System.out.print("-");
		}
		System.out.println(">");
	}

	//Neteja la pantalla
	public static void clear() {
        System.out.print("\033[H\033[2J");
        System.out.flush();
    }
}
