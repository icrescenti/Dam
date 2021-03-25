//============================================================================
// Name        : A03_AlgorismeHash.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans © Copyright 2020
// Description : Programa per codificar missatges
//============================================================================

package m9.uf1.e1.ivancrescenti;

//LIBRERIES
import java.util.Scanner;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

public class A03_AlgorismeHash 
{

	public static void main(String[] args)
	{
		//Objectes
		Scanner escaner = new Scanner(System.in);
		MessageDigest codificador = null;

		//Variables
		String missatget = null;
		String missatget_codificat = null;
		String metode_encriptacio = null;
		byte[] vector_bytes;
		int opcio = 0;
		
		//Demana al usuari el missatge
		System.out.print("Inserir el missatget a encriptar: ");
		missatget = escaner.nextLine();
		
		//Demana al usuari la opcio
		System.out.print("Quin algorisme hash vols utilitzar per codificar? (1 - MD5, 2 - SHA1, 3 - SHA256): ");
		opcio = escaner.nextInt();
		
		//Tenquem el escaner properament
		escaner.close();
		
		//Assigna el metode de codificacio segons la opcio
		switch (opcio)
		{
			case 1:
			{
				metode_encriptacio = "MD5";
				break;
			}
			case 2:
			{
				metode_encriptacio = "SHA1";
				break;
			}
			case 3:
			{
				metode_encriptacio = "SHA-256";
				break;
			}
			default:
				//Notifica a l'usuari que la opcio no es valida
				System.out.print("Aqui tenim un problemilla, la opcio no es valida.");
			break;
		}
		
		try
		{
			//Assigna el metode de encriptacio seleccionat a l'objecte de codificar
			codificador = MessageDigest.getInstance(metode_encriptacio);
		}
		catch (NoSuchAlgorithmException ex)
		{
			//Mostra per pantalla el error
			System.err.println("Generador no disponible.");
		}
		
		//Guarda els bytes de la string en el objecte de codificador i els codifica
		codificador.update(missatget.getBytes());
		
		//Guardem els bytes en un vector de bytes
		vector_bytes = codificador.digest();
		
		//Converteix el vector de bytes en una string
		missatget_codificat = byteArrayToString(vector_bytes);
		
		//Mostra el missatge codificat
		System.out.print("El missatget condificat sera: " + missatget_codificat);
		
	}
	
	//Funcio que converteix una matriu de bytes en una string
	private static String byteArrayToString(byte[] transform) 
	{
		 StringBuffer hexString = new StringBuffer();
		 for (int i=0;i<transform.length;i++) 
		 {
			 //Concatena el contingut del StringBuffer amb el seguent byte convertit a valor hexadecimal
			 hexString.append(Integer.toHexString(0xFF & transform[i]));
		 }
		 return hexString.toString();
	}
}
