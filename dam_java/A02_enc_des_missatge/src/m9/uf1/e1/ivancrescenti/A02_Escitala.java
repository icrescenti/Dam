//============================================================================
// Name        : A02_Escitala.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : Ivan Crescenti © Copyright 2020
// Description : Encriptacio senzilla utilitzant el metode de escitala escrit amb JAVA
//============================================================================
package m9.uf1.e1.ivancrescenti;

import java.util.Scanner;

public class A02_Escitala
{
	
	private static int cares = 4;
	
	//region Funcio principal on es criden les funcions
	public static void main(String[] args)
	{
		//Inicialitza la classe A02_Escitala
		A02_Escitala escitala = new A02_Escitala();
		
		//Inicialitza i declara un objecte que ens permetra
		//inserir text des de la consola de comandes
		Scanner sca = new Scanner(System. in);
		
		String missatge = null;
		
		//Demana els parametres a l'usuari
		System.out.print("Insereix el nombre de cares per a encriptar: ");
		cares = Integer.parseInt(sca. nextLine());
		
		System.out.print("Insereix el missatge a encriptar: ");
		missatge = sca. nextLine();
		
		//Encripta el missatge i el mostra per consola
		missatge = escitala.encriptar(missatge);
		System.out.print("El missatge encriptat es: " + missatge + "\n");
		
		//Desencripta el missatge i el mostra per consola
		missatge = escitala.desencriptar(missatge);
		System.out.print("El missatge desencriptat es: " + missatge);
	}
	//endregion
	
	//region Funcio per encriptar
	public String encriptar(String missatge) 
	{
		//Valida que la string estigui plena
		if (validat(missatge)) 
		{
			//creem una variable de tipus matriu i la instanciem amb les mesures pertinents,
			//les cares a encripar com a altura i la allargada del missatge com a allargada
			char[][] matriu = new char[cares][calcColumnes(missatge.length())];
			
			//Emplena la matriu amb tots els caracters de la string
			A02_Escitala.emplenar_matriu( missatge, matriu );

			//Basicamnt funcio coneguda com a ToString en C# realitzada a ma
			//que converteix un vector de caracters a una string
			return A02_Escitala.aTexte( matriu );
		}
		return null;
	}
	//endregion
	
	//region Funcio per desencriptar
	public String desencriptar(String missatge) 
	{
		//Valida que la string estigui plena
		if (validat(missatge))
		{
			//Creem la variable matriu i la instanciem novament amb el nombre
			//de cares i la allargada de el missatge
			char[][] matriu = new char[calcColumnes(missatge.length())][cares];

			//Novament emplenem la matriu amb lletres de la string
			A02_Escitala.emplenar_matriu( missatge, matriu );

			//Convertim la matriu a una string i la retornem
			return A02_Escitala.aTexte( matriu );
		}
		return null;
	}
	//endregion

	//region Funcio per emplenar una matriu de lletres de la string
	private static void emplenar_matriu(String frase, char[][] array ) 
	{
		int posicio = 0;

		//El doble for ens permetra recorre totes les posicions de la matriu
		for (int i = 0; i < array.length; i++) 
		{
			for (int j = 0; j < array[i].length; j++) 
			{
				if (posicio < frase.length())
				{
					//Emplenem la matriu amb cada caracter a la posicio seguent
					array[i][j] = frase.charAt(posicio++);
				}
				else
				{
					//En cas de que la matriu sigui mes gra,n emplenarem la resta
					//de matriu amb espais per evitar que peti
					array[i][j] = ' ';
				}
			}
		}
	}
	//endregion
	
	//region Funcio per convertir una matriu en una cadena de text
	private static String aTexte(char[][] matriu) 
	{
		//Definim el constructor de la string amb la longitut de la matriu
		StringBuilder str_constructor = new StringBuilder( matriu.length * matriu[0].length );

		//Afegeix els caracters a la string
		for (int i = 0; i < matriu[0].length; i++) 
		{
			for (char[] fila : matriu)
			{
				str_constructor.append(fila[i]);
			}
		}
		return str_constructor.toString();
	}
	//endregion
	
	//region Funcio per a validar que la string sigui correcta
	private boolean validat(String missatge)
	{
		//Comprova que la string no sigui nula i que la seva allargada sigui
		//superior a el numero de cares
		return missatge != null && missatge.length() > cares;
	}
	//endregion

	//region Funcio per calcular les columnes que necessitara la matriu segons la allargada de la string
	private int calcColumnes(int longitud) 
	{
		//Segons el residu, sabrem si tenim un espai exacte o hem de donarli un marge de 1 caracter
		if (longitud % cares == 0) 
		{
			return longitud / cares;
		} 
		else 
		{
			return longitud / cares + 1;
		}
	}
	//endregion
}