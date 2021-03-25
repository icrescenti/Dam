//============================================================================
// Name        : A02-SLEEP-JOIN.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans @ Copyright 2021
// Description : Cursa entre Tortuga i Llebre
//============================================================================

package m9.uf2.ivancrescenti.a02;

public class CursaThreads {
    public static void main(String[] args){
		int metresCursa = 70;

		//Threads
		Thread llebre = new Thread(new MovimentLlebre(metresCursa));
		Thread tortuga = new Thread(new MovimentTortuga(metresCursa));

		//Thread que mostra el progress de la cursa
		Thread cursa = new Thread(new MostrarCursa(metresCursa));
		
		//Inicia els threads
		tortuga.start();
		llebre.start();
		cursa.start();

		//Espera a que acavin els threads per tonrar a excutar-se
		try
		{
			tortuga.join();
			llebre.join();
		}
		catch(InterruptedException ex)
		{
			Thread.currentThread().interrupt();
		}
	}
}
