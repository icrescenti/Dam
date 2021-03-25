//============================================================================
// Name        : Desperta.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans @ Copyright 2021
// Description : Interrupcions a threads
//============================================================================

package m9.uf2.ivancrescenti.a03;

import java.util.Random;

public class Desperta {
    public static void main(String[] args)
	{
		//Threads
		Thread thread1 = new Thread(new ThredSleep("", tempsAleatori()));
		Thread thread2 = new Thread(new ThredSleep("", tempsAleatori()));
		Thread thread3 = new Thread(new ThredSleep("", tempsAleatori()));

		//Inicia els threads
		thread1.start();
		thread2.start();
		thread3.start();

		//S'atura la execucio fins que un thread acaba
		while (thread1.isAlive() && thread2.isAlive() && thread3.isAlive()) { }

		thread1.interrupt();
		thread2.interrupt();
		thread3.interrupt();

		while (thread1.isAlive() || thread2.isAlive() || thread3.isAlive()) { }

		System.out.println("Els 3 fils han finalitzat");
	}

	static int tempsAleatori()
	{
		Random rand = new Random(); 
		return rand.nextInt(20-5)+5;
	}
}