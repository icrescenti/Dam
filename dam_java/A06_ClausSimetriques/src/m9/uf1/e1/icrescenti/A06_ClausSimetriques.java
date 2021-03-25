//============================================================================
// Name        : A06_ClausSimetriques.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans © Copyright 2020
// Description : Diferentes encriptacions amb diferents codificadors e algorismes
//============================================================================

//Nom del paquet
package m9.uf1.e1.icrescenti;

//LLIBRERIES
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Arrays;
import java.util.Scanner;

import javax.crypto.KeyGenerator;
import javax.crypto.SecretKey;
import javax.crypto.spec.SecretKeySpec;

public class A06_ClausSimetriques {
	
	public static void main (String[] args)
	{
		//Mostrem per pantalla 3 xifratges, 3 usant encriptacio aleatoria
		//i 3 xifrant a partir de un text amb diferents algorismes
		
		System.out.print("Claus simètriques a l'atzar\n");

		System.out.print("AES (192 bits): " + byteArrayToString(keygenKeyGeneration("AES", 192).getEncoded()) + "\n");
		System.out.print("DES (56 bits):" + byteArrayToString(keygenKeyGeneration("DES", 56).getEncoded()) + "\n");
		System.out.print("DES (15 bits): " + keygenKeyGeneration("DES", 15) + "\n");
		
		System.out.print("\nClaus simètriques a partir de la contrasenya 123456789\n");
		
		System.out.print("DESede (168 bits - hash: SHA-1): " + byteArrayToString(passwordKeyGeneration("123456789", "SHA-1", "DESede", 168, "UTF-8").getEncoded()) + "\n");
		System.out.print("AES (192 bits - hash: MD5): " + byteArrayToString(passwordKeyGeneration("123456789", "MD5", "AES", 192, "UTF-8").getEncoded()) + "\n");
		System.out.print("Escítala (4 bits): " + passwordKeyGeneration("123456789", "MD5", "Escítala", 4, "UTF-8"));
		
		//escaner.nextLine();
	}
	
	//Funcio per xifrar aleatoriament
	public static SecretKey keygenKeyGeneration(String algorisme, int keySize) {
			//Creem un objecte skey definit com a null, aqui s'emmagatzemara la nostra clau secreta
		   SecretKey sKey = null;
		   //Validem que els parametres inserits en la funcio son valids
		   if (
				   ((keySize == 128 || keySize == 192 || keySize == 256) && algorisme == "AES") ||
				   (keySize == 56 && algorisme == "DES") ||
				   ((keySize == 112 || keySize == 168) && algorisme == "DESede")
			  )
		   {
			   //Intenta xifrar usant tant el algorisma com el tamany de la clau
		      try {
		    	 //Defineix el generador de la clau
		         KeyGenerator kgen = KeyGenerator.getInstance(algorisme);
		         //Defineix el tamany de la clau sobre el generador
		         kgen.init(keySize);
		         //Defineix la clau secreta previament mencionada, a la generacio de la clau
		         //mitjançant l'objecte kgen
		         sKey = kgen.generateKey();
		      }
		      catch (NoSuchAlgorithmException ex) {
		    	  //En cas de que no es pugui realitzar, es mostrara el seguent missatge per pantalla
		         System.err.println("Generador no disponible.");
		      }
		   }
		   return sKey;
	}
	
	//Funcio per xifrar a partir de un text
	public static SecretKey passwordKeyGeneration(String text, String algorisme_hash, String algorisme, int keySize, String codificacio)
	{
		   //Novament creem un obejcte de clau secreta definit a null
		   SecretKey sKey = null;
		   //Comprova que tant, el algorisme, el metode hash, i el tamany de la clau siguin compatibles
		   if (  
				 (
				   ((keySize == 128 || keySize == 192 || keySize == 256) && algorisme == "AES") ||
				   (keySize == 56 && algorisme == "DES") ||
				   ((keySize == 112 || keySize == 168) && algorisme == "DESede")
				 ) &&
				 (
					algorisme_hash == "SHA-256" ||
					algorisme_hash == "SHA-1" ||
					algorisme_hash == "MD5"
				 )
			  )
		   {
		      try {
		    	 //Usant el codificador definit, emmagatzema temporalment la cadena de caracters
		    	 //a un vector de bytes per a realitzar el xifrantge
		         byte[] data = text.getBytes(codificacio);
		         //Definim un MessageDigest amb el metode hash definit per parametre
		         MessageDigest md = MessageDigest.getInstance(algorisme_hash);
		         //Emmagatzemem el hash del vector de bytes
		         byte[] hash = md.digest(data);
		         //Realitza una copia de el array amb el metode hash i la longitud de la clau dividit per 8
		         byte[] key = Arrays.copyOf(hash, keySize/8);
		         //Emmagatzema la clau, que es el vector de bytes previament definit amb l'algorisme definit
		         //com a parametre
		         sKey = new SecretKeySpec(key, algorisme);
		      } 
		      catch (Exception ex) {
		    	 //En cas de que no es pugui realitzar, es mostrara el seguent missatge per pantalla
		         System.err.println("Error generant la clau:" + ex);
		      }
		   }

		   return sKey;

		 }

	//Funcio per convertir un vector de bytes a una cadena de caracters(string)
	//com be indica el seu nom
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
