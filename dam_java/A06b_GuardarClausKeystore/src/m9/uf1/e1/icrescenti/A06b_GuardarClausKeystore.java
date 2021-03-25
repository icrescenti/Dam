//============================================================================
// Name        : A06b_GuardarClausKeystore.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans © Copyright 2020
// Description : Programa per emmagatzemar una clau secreta
//============================================================================

//Nom del paquet
package m9.uf1.e1.icrescenti;

//Llibreries
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.security.KeyStore;
import java.security.NoSuchAlgorithmException;

import javax.crypto.KeyGenerator;
import javax.crypto.SecretKey;

public class A06b_GuardarClausKeystore {
	
	public static void main (String[] args)
	{
		//GENERACIO DE CLAU
		SecretKey clau = clauSimetricaAtzar("AES", 192);
		
		//MOSTREM LA CLAU
		System.out.print("Clau simètrica a l'atzar: " + byteArrayToString(clau.getEncoded()));
		
		//ESCRIPTURA I LECTURA (EXERCICI)
		EmmagatzemarKeyStore(clau, "fitxer123456", "clau123456");
		System.out.print("\nClau simètrica de fitxer: " + byteArrayToString(RecuperarKeyStore("fitxer123456", "clau123456").getEncoded()));
	}

	public static SecretKey clauSimetricaAtzar(String algorisme, int keySize) 
	{
		SecretKey sKey = null;

		if (
				((keySize == 128 || keySize == 192 || keySize == 256) && algorisme == "AES") ||
				(keySize == 56 && algorisme == "DES") ||
				((keySize == 112 || keySize == 168) && algorisme == "DESede")
			)
			   {
				 try 
				 {
			         KeyGenerator kgen = KeyGenerator.getInstance(algorisme);

			         kgen.init(keySize);

			         sKey = kgen.generateKey();
			     }
			     catch (NoSuchAlgorithmException ex) 
				 {
			    	System.err.println("Generador no disponible.");
			     }
			  }
		return sKey;
	}

	static void EmmagatzemarKeyStore(SecretKey secretKey, String contrasenyaFitxer, String contrasenyaClau)
	{
		String fileName = "clausimetrica.dat"; //fitxer on es guarda el keystore
		String alias = "clau0"; //nom identificador de la clau

		File file = new File(fileName);
		
		try 
		{
			// Es crea un keystore de tipus JCEKS		
			KeyStore keyStore = KeyStore.getInstance("JCEKS");

			// Si el keystore existex, es recupera el que hi ha, si no se'n crea un de temporal
			if (file.exists()) {
				keyStore.load(new FileInputStream(file), contrasenyaFitxer.toCharArray());
			} else {
				keyStore.load(null, null);
			}

			// Guardar la clau com una nova Entry del KeyStore
			keyStore.setKeyEntry(alias, secretKey, contrasenyaClau.toCharArray(), null);

			// Guardar el keyStore al fitxer
			keyStore.store(new FileOutputStream(file), contrasenyaFitxer.toCharArray());
		}
		catch(Exception e)
		{
			System.err.println("No ha estat possible emmagatzemar la clau en el fitxer " + fileName);
		}
	}

	static SecretKey RecuperarKeyStore(String contrasenyaFitxer, String contrasenyaClau)
	{
		String fileName = "clausimetrica.dat"; //fitxer on es guarda el keystore
		String alias = "clau0"; //nom identificador de la clau

		SecretKey clau = null;
		
		try
		{
			KeyStore ks = KeyStore.getInstance("JCEKS");

			ks.load(new FileInputStream(fileName), contrasenyaFitxer.toCharArray());

			clau = (SecretKey) ks.getKey(alias, contrasenyaClau.toCharArray());
		}
		catch(Exception e) 
		{
			System.err.println("No es pot llegir el fitxer o la contrasenya es incorrecta, torna a intentar-ho");
		}
		
		return clau;
	}
	
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
