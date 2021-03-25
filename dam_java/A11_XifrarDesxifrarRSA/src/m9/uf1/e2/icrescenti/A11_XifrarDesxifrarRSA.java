//============================================================================
// Name        : A11_XifrarDesxifrarRSA.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans @ Copyright 2021
// Description : Encriptar i desencriptar un missatge
//============================================================================

package m9.uf1.e2.icrescenti;

import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.security.SecureRandom;
import java.util.Base64;

import javax.crypto.Cipher;

public class A11_XifrarDesxifrarRSA {

	//Definicio de variables
	private static KeyPairGenerator generador = null;
	private static SecureRandom rand = new SecureRandom();
	
	public static void main (String[] args)
	{
		//Definim el generador
		iniciaGenerador();
		
		//Creem i definim el cipher
		Cipher xifrador = generarCipher();
		
		//Variable de missatge
		String missatge = "Monkey";
		
		//Generem dues claus, i separem amb dues variables, la clau publica i privada
		KeyPair claus = generador.genKeyPair();
		PublicKey clauPublica = claus.getPublic();
		PrivateKey clauPrivada = claus.getPrivate();
		
		//Encriptacio i desencriptacio
		byte[] textencriptat = encriptar(xifrador, missatge, clauPublica);
		print(Base64.getEncoder().encodeToString(textencriptat) + "\n");
		print(desencriptar(xifrador, textencriptat, clauPrivada));
	}
	
	static void print(String msg)
	{
		System.out.print(msg);
	}
	
	private static void iniciaGenerador() 
	{
		try
		{
			//Creem el KeyPairGenerator, el definim amb RSA i una allargada de 1024
			if(generador == null)
				generador = KeyPairGenerator.getInstance("RSA");
			
			generador.initialize(1024, rand);
		}
		catch(Exception e) 
		{
			e.printStackTrace();
		}
	}
	
	static Cipher generarCipher()
	{
		try
		{
			//Instanciem el cipher amb rsa ecb
			return Cipher.getInstance("RSA/ECB/PKCS1Padding", "SunJCE");
		}
		catch (Exception e) {
			return null;
		}
	}
	
	public static String desencriptar(Cipher xf, byte[] missatge, PrivateKey clau)
	{
		try
		{
			//Defineix el cipher en mode desencriptacio
			xf.init(Cipher.DECRYPT_MODE, clau);
			//Realitza la encriptacio amb la string
			return new String(xf.doFinal(missatge));
		}
		catch (Exception e) {
			return null;
		}
    }

    public static byte[] encriptar(Cipher xf, String missatge, PublicKey clau)
    {
    	try
    	{
    		//Defineix el cipher en mode desencriptacio
    		xf.init(Cipher.ENCRYPT_MODE, clau);
    		//Realitza la desencriptacio amb el vector de bytes del missatge
    		return xf.doFinal(missatge.getBytes());
    	}
    	catch (Exception e)
    	{
			return null;
		}
    }

}
