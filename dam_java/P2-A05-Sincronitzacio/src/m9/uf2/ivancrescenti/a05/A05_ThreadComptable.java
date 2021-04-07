package m9.uf2.ivancrescenti.a05;

	
	public class A05_ThreadComptable extends Thread {

		A05_Comptador comptador;

		public A05_ThreadComptable(A05_Comptador c) {
			comptador = c;
		}

		public void run() {
			int i;
			
			for (i = 1; i <= 100000; i++)
				comptador.incrementa();
		}
	}

