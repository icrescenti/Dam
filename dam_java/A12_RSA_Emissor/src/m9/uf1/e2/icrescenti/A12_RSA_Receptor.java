package m9.uf1.e2.icrescenti;

import java.io.FileInputStream;
import java.security.KeyStore;
import java.security.PrivateKey;
import java.util.Base64;
import java.util.Scanner;

import javax.crypto.Cipher;

public class A12_RSA_Receptor {
	
	public static void main (String[] args)
	{
		//Defineix les variables
		Scanner escaner = new Scanner(System.in);
		Cipher xifrador = null;
		
		try {
			//Defineix el objecte que xifra amb el metode RSA ECB
			xifrador = Cipher.getInstance("RSA/ECB/PKCS1Padding", "SunJCE");
		} catch (Exception e) { }
		
		//Sol·licita inserir un missatge al usuari
		print("Insereix el teu missatge:");
		String missatge = escaner.nextLine();
		escaner.close();
		
		//Llegeix la clau privada de un certificat
		PrivateKey clauPrivada = llegirMagatzemClaus("magatzemclaus.jks", "clausegura123");

		//Mostra el missatge desencriptat
		print(desencriptar(xifrador, missatge, clauPrivada));
	}
	
	static void print(String msg)
	{
		System.out.print(msg);
	}
	
	public static String desencriptar(Cipher xf, String missatge, PrivateKey clau)
	{
		try
		{
			//Defineix el cipher en mode desencriptacio
			xf.init(Cipher.DECRYPT_MODE, clau);
			
			//Desencipta el missatge (bytes del msisatge, conversort de base64 a hexadecimal,
			//lectura novament dels bytes i la generacio de la string amb aquests mateixos)
			return new String(xf.doFinal(Base64.getDecoder().decode(missatge)));
		}
		catch (Exception e) {
			return null;
		}
    }
	
	public static PrivateKey llegirMagatzemClaus(String fitxer, String contrasenya) {
    	
		//Variables
    	String alias = "selfsigned";
		PrivateKey clau = null;
		
		try
		{
			//Defineix el keystore amb la instancia JCEKS
			KeyStore claustore = KeyStore.getInstance("JCEKS");
			FileInputStream fixerStream = new FileInputStream(fitxer);
			
			//Llegeix el key store (de windows) amb la contrasenya
			claustore.load(fixerStream, contrasenya.toCharArray());

			//Emmagatzemem la clau privada
			clau = (PrivateKey) claustore.getKey(alias, contrasenya.toCharArray());
		}
		catch(Exception e) 
		{
			System.err.println("No ha estat possible llegir el certificat");
		}
		
		return clau;
    	
    }

}