//============================================================================
// Name        : A07_XifrarDesxifrarAES.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans @ Copyright 2020
// Description : Encriptacio i desencriptacio de un text
//============================================================================

//Nom del paquet
package m9.uf1.e2.icrescenti;

//Libreries
import java.security.MessageDigest;
import java.util.Arrays;
import java.util.Base64;
import java.util.Scanner;

import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;

public class A07_XifrarDesxifrarAES {
	static byte[] IV_PARAM = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
	
	public static void main (String[] args)
	{
		Scanner escaner = new Scanner(System.in);
		String clau, missatge = null;
		int opcio =  0;
		boolean execucio = true;
		
		while (execucio)
		{
			//Solicitaci� de la opcio
			System.out.print("Selecciona una acci� a realitzar:\n(1) Xifrar\n(2) Desxifrar\n(3) Tancar Programa\n------------\nOpcio: ");
			opcio = Integer.parseInt(escaner. nextLine());
			
			switch(opcio)
			{
				//Encriptar un missatge
				case 1:
					System.out.print("Insereix un missatge: ");
					missatge = escaner.nextLine();
					System.out.print("Clau per xifrar: ");
					clau = escaner.nextLine();
					missatge = encriptar(clau, missatge);
					
					System.out.print("Missatge encriptat: " + missatge + "\n");
				break;
				//Desencriptar un missatge
				case 2:
					System.out.print("Insereix un missatge: ");
					missatge = escaner.nextLine();
					System.out.print("Clau per desxifrar: ");
					clau = escaner.nextLine();
					missatge = desencriptar(clau, missatge);
					
					System.out.print("Missatge desencriptat: " + missatge + "\n");
				break;
				//Tencar el programa
				case 3:
					execucio = false;
				break;
				default:
					System.out.print("Opcio incorrecta");
				break;
			}
		}
	}
	
	
	//Les dues funcions son for�a semblants, per aixo molts comentaris son iguals
	static String encriptar(String clau, String missatge)
	{
		try
		{
			//Metode de xifratge
			MessageDigest mdigest = MessageDigest.getInstance("SHA-256");
			
			//Emmagatzema els bytes de la string amb format UTF-8
			byte[] clauBytes = mdigest.digest(clau.getBytes("UTF-8"));
			
			//Limitem a 128 bits la clau
			clauBytes = Arrays.copyOf(clauBytes, 16);
			
			//Assignem AES com a metode de encriptacio
			SecretKeySpec sclausp = new SecretKeySpec(clauBytes, "AES");
			
			//Cipher inicialitzat amb AES CBC i ho encripta
			Cipher cp = Cipher.getInstance("AES/CBC/PKCS5Padding");
			cp.init(Cipher.ENCRYPT_MODE, sclausp, new IvParameterSpec(IV_PARAM));
			
			//Converteix i retorna la string
			byte[] resultat = cp.doFinal(missatge.getBytes());
			return Base64.getMimeEncoder().encodeToString(resultat);
		}
		catch (Exception e) {
			return null;
		}
		
    }
	
	static String desencriptar(String clau, String missatge_encriptat) {
		try 
		{
			//Metode de xifratge
			MessageDigest md = MessageDigest.getInstance("SHA-256");
			
			//Emmagatzema els bytes de la string amb format UTF-8
	        byte[] clauBytes = md.digest(clau.getBytes("UTF-8"));
	        
	        //Limitem a 128 bits la clau
	        clauBytes = Arrays.copyOf(clauBytes, 16);
	        
	        //Bytes del text encriptat
	        byte[] encriptat = Base64.getMimeDecoder().decode(missatge_encriptat);
	        
	        //Assignem AES com a metode de encriptacio
	        SecretKeySpec secretKeySpec = new SecretKeySpec(clauBytes, "AES");
	        
	        //Cipher inicialitzat amb AES CBC i ho desencripta
	        Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
	        cipher.init(Cipher.DECRYPT_MODE, secretKeySpec, new IvParameterSpec(IV_PARAM));

	        //Converteix i retorna la string
	        byte[] resultat = cipher.doFinal(encriptat);
	        return new String(resultat);
		}
		catch (Exception e) {
			return null;
		}
	}
	
}
