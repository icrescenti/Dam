//============================================================================
// Name        : Sincronitzacio.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans @ Copyright 2021
// Description : 
//============================================================================

package m9.uf2.ivancrescenti.a04;

public class Sincronitzacio {

	final static int tamanyMatrix = 10000;

    public static void main(String[] args)
	{
		Resultat resultat = new Resultat();
		int[][] matriu = emplenarmatriu();

		FilApex[] fils = new FilApex[5];

		fils[0] = new FilApex("fil 0", resultat, matriu);
		fils[1] = new FilApex("fil 1", resultat, matriu);
		fils[2] = new FilApex("fil 2", resultat, matriu);
		fils[3] = new FilApex("fil 3", resultat, matriu);
		fils[4] = new FilApex("fil 4", resultat, matriu);

		for (FilApex fil : fils) {
			fil.start();
		}

		for (FilApex fil : fils) {
			while (fil.isAlive()) {}
		}
		
		print(resultat.getResultat());
	}

	//Funcio per emplenar una matriu amb 1
	public static int[][] emplenarmatriu()
	{
		int[][] matriuGran = new int [tamanyMatrix][tamanyMatrix];

		for (int i = 0; i<tamanyMatrix; i++)
			for (int j = 0; j<tamanyMatrix; j++)
				matriuGran[i][j] = 1;

		return matriuGran;
	}

	//Mostra un missatge
	private static void print(long l)
	{
		System.out.print(l);
	}
}