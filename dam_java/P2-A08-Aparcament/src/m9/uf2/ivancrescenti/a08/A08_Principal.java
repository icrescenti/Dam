package m9.uf2.ivancrescenti.a08;

public class A08_Principal {
	public static void main(String arg[]) throws InterruptedException {
		final int max_coxes = 10;
		final int places_lliures = 5;

		A08_Parquing parking = new A08_Parquing(places_lliures);
		A08_Cotxe[] cotxes = new A08_Cotxe[max_coxes];

		for (int i = 0; i<max_coxes; i++)
		{
			cotxes[i] = new A08_Cotxe("cotxe_" + i, parking, "000" + i + " AAA");
		}

		for (int i = 0; i<max_coxes; i++)
		{
			cotxes[i].start();
		}
	}
}
