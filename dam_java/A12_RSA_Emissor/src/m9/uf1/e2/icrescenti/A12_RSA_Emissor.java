//============================================================================
// Name        : A12_RSA_Emissor.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans @ Copyright 2021
// Description : Encriptacio i desencriptacio mitjançant un certificat
//============================================================================

package m9.uf1.e2.icrescenti;

import java.io.FileInputStream;
import java.security.KeyPairGenerator;
import java.security.PublicKey;
import java.security.SecureRandom;
import java.security.cert.Certificate;
import java.security.cert.CertificateFactory;
import java.util.Base64;
import java.util.Scanner;

import javax.crypto.Cipher;

public class A12_RSA_Emissor {
	
	//Defineix les variables
	private static KeyPairGenerator generador = null;
	private static SecureRandom rand = new SecureRandom();
	
	public static void main (String[] args)
	{
		//Creacio del escanner, per inserir dades
		Scanner escaner = new Scanner(System.in);
		Cipher xifrador = null;
		
		try
		{
			//Definiexi el generador amb el metode RSA i 1024 bits
			generador = KeyPairGenerator.getInstance("RSA");
			generador.initialize(1024, rand);
		}
		catch (Exception e)
		{
			
		}
		
		try {
			//Defineix el objecte que xifra amb el metode RSA ECB
			xifrador = Cipher.getInstance("RSA/ECB/PKCS1Padding", "SunJCE"); 
		} catch (Exception e) { }
		
		//Sol·licita inserir un missatge al usuari
		print("Insereix el teu missatge:");
		String missatge = escaner.nextLine();
		escaner.close();
		
		//Llegeix la clau publica de un certificat
		PublicKey clauPublica = llegirCertificatPublic("certpublic.cer");
		
		//Mostra el missatge encriptat
		print(encriptar(xifrador, missatge, clauPublica));
	}
	
	static void print(String msg)
	{
		System.out.print(msg);
	}
	
    public static String encriptar(Cipher xf, String missatge, PublicKey clau)
    {
    	try
    	{
    		//Defineix el cipher en mode desencriptacio
    		xf.init(Cipher.ENCRYPT_MODE, clau);
    		//Realitza la desencriptacio amb el vector de bytes del missatge
    		return Base64.getEncoder().encodeToString(xf.doFinal(missatge.getBytes()));
    	}
    	catch (Exception e)
    	{
			return null;
		}
    }
    
    public static PublicKey llegirCertificatPublic(String fitxer)
    {
    	try
    	{
    		//Obrim un "stream" per poder realitzar modificiacions al fitxer
    		FileInputStream fitxeret = new FileInputStream(fitxer);
    		
    		//Generacio de certificat
    		CertificateFactory generadorCertificat = CertificateFactory.getInstance("X.509");
    		Certificate certificat = generadorCertificat.generateCertificate(fitxeret);
    		
    		//Retorna la clau publica del certificat generat
    		return certificat.getPublicKey();
    	}
    	catch (Exception e){
    		return null;
    	}
    }
    
}