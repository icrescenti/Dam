package m9.uf2.ivancrescenti.a06;

public class A06_Principal {
	public static void main(String arg[]) throws InterruptedException {
		A06_CompteCompartit compte = new A06_CompteCompartit();

		A06_ThreadAmic Pere = new A06_ThreadAmic(compte, "Pere");
		A06_ThreadAmic Caterina = new A06_ThreadAmic(compte, "Caterina");
		
		Pere.start();
		Caterina.start();
		
		//print("Recompte total: " + c.getValor());
	}

}
