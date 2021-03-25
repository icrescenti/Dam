//============================================================================
// Name        : A10_GenerarClausAssimetriques.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans � Copyright 2021
// Description : Programa per generar dues claus i mostrarles per pantalla
//============================================================================

package m9.uf1.e2.icrescenti;

import java.security.Key;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.security.SecureRandom;
import java.util.Base64;

public class A10_GenerarClausAssimetriques {
	
	//Definicio de variables
	private static KeyPairGenerator generador = null;
	private static SecureRandom rand = new SecureRandom();
	
	public static void main (String[] args)
	{
		//Definim el generador
		iniciaGenerador();
		
		//Generem dues claus, i separem amb dues variables, la clau publica i privada
		KeyPair claus = generador.genKeyPair();
		PublicKey clauPublica = claus.getPublic();
		PrivateKey clauPrivada = claus.getPrivate();
		
		//Transformem les dues claus a strings per poder visualitzarles
		String stringClauPublica = visualitzar(clauPublica);
		String stringClauPrivada = visualitzar(clauPrivada);
		
		//Mostra les claus per pantalla
		System.out.print("La clau publica sera: " + stringClauPublica + "\nLa clau privada sera: " + stringClauPrivada);
	}
	
	private static void iniciaGenerador() 
	{
		try
		{
			//Inicialitza el generador amb RSA i 1024 bits
			if(generador == null)
				generador = KeyPairGenerator.getInstance("RSA");
			
			generador.initialize(1024, rand);
		} 
		catch(Exception e) 
		{
			e.printStackTrace();
		}
	}
	
	public static String visualitzar(Key clau)
	{
		//obtenim els bytes de la clau
		byte[] vectorBytes = clau.getEncoded();
		//transformem el vector de bytes a una string usant base64
    	return Base64.getEncoder().encodeToString(vectorBytes);
	}

	
}
