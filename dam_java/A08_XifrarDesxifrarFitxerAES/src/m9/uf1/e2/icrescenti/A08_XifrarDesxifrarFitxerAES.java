//============================================================================
// Name        : A08_XifrarDesxifrarFitxerAES.java
// @Author     : Ivan Crescenti Hernandez
// Version     : 1.0
// Copyright   : IES Rafael Campalans © Copyright 2021
// Description : Encriptacio de un fitxer per contrasenya usant AES en mode ECB
//============================================================================

package m9.uf1.e2.icrescenti;

//Llibreries
import java.io.File;
import java.io.FileOutputStream;
import java.io.UnsupportedEncodingException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Arrays;
import java.util.Scanner;

import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;

public class A08_XifrarDesxifrarFitxerAES {
	
	//Definim la SecretKey i la clau (amb bytes)
	private static SecretKeySpec ClauSecreta;
    private static byte[] clau;
	
	public static void main (String[] args)
	{
		//Inicialitzem l'escaner
		Scanner escaner = new Scanner(System.in);
		
		//Contrasenya per a realitzar la encriptacio
		String contrasenya = "123456";
	    
		//Definim el nom del fitxer amb el que treballarem
		System.out.print("Insereix el nom del fixer a encriptar/desencriptar: ");
		String fitxer = escaner.nextLine();
		
		//Llegim el contingut del fitxer en mode binari i l'emmagatzemem en un vector de bytes
		byte[] contingut = llegirFitxer(fitxer);
	    //En cas de que el vector no sigui vuit (es a dir, el fitxer ha estat llegit)
		if (contingut != null)
	    {
			//Assignem la contrasenya per encriptar
	    	System.out.print("Insereix una contrasenya per a la encriptacio: ");
	    	contrasenya = escaner.nextLine();
	    	
	    	//Crearem una variable per guardar la informacio del fitxer original a borrar
	    	File old_fixer = new File(fitxer);
	    	
	    	//Definim en una variable l'extensio del fitxer
	    	int ext_pos = fitxer.lastIndexOf(".");
	    	String extensio = fitxer.substring(ext_pos+1);
	    	
	    	//En cas de que ja hagi estat encriptat, el desencriptarem
	    	if (extensio.equals("aes"))
	    	{
	    		//Desencriptem el contingut minjançant la contrasenya
	    		byte[] bytesDesencriptats = desencriptar(contingut, contrasenya);
	    		//Generem el nou fitxer amb el contingut desencriptat i la seva extensio original
	    		escriureFitxer(bytesDesencriptats, fitxer.substring(0,ext_pos));
	    		//Eliminem el fitxer original
	    		old_fixer.delete();
	    		System.out.print("El fitxer ha estat encriptat correctament");
	    	}
	    	//En cas que no estigui encriptat, l'encriptarem
	    	else
	    	{
	    		//Encriptem el contingut minjançant la contrasenya
	    		byte[] bytesEncriptats = encriptar(contingut, contrasenya);
	    		//Generem el nou fitxer amb el contingut encriptat i amb la extensio final de .aes
	    		escriureFitxer(bytesEncriptats, fitxer + ".aes");
	    		//Eliminem el fitxer original
	    		old_fixer.delete();
	    		System.out.print("El fitxer ha estat desencriptat correctament");
	    	}
	    }
	    else
	    {
	    	//En cas de que el contingut estigui en vui, notificarem al usuari que no ha estat
	    	//possible llegir el fitxer
	    	System.out.print("El fitxer " + fitxer + " no existeix o es inaccesible");
	    }
	}
	
	static byte[] llegirFitxer(String ruta)
	{
		//Creem un objecte de fitxer en memoria amb la ruta del fitxer com a parametre
		File f = new File(ruta);
		//en cas de que el fitxer existeixi i no sigui una carpeta/directori, entrara en el if
		if(f.exists() && !f.isDirectory())
		{
			//intenta llegir els bytes del fitxer i els retorna
			try
			{
				return Files.readAllBytes(Paths.get(ruta));
			}
			catch (Exception e) {
				return null;
			}
		}
		else return null;
	}
	
	static void escriureFitxer(byte[] contingut, String fitxer)
	{
		//Intenta escriure els bytes passats per parametre en el fitxer amb la ruta tambe pasada per parametre
		try (FileOutputStream fos = new FileOutputStream(fitxer)) {
			   fos.write(contingut);
			   //tenca el fitxer
			   fos.close();
		}
		catch (Exception e)
		{
			System.out.print("No ha estat possible crear el fitxer");
		}
	}
	
    public static void assignarClau(String clau_secreta) 
    {
    	//Creem un MessageDigest que posteriorment usarem
        MessageDigest xifrador = null;
        try {
        	//Convertim la cadena de caracters a un vector de bytes usant la codificacio UTF-8
            clau = clau_secreta.getBytes("UTF-8");
            
            //Definim la variable xifrador amb un nou MessageDigest amb l'algorisme SHA-1
            xifrador = MessageDigest.getInstance("SHA-1");
            
            //Xifrem el vector de bytes que conte la nostra cadea de caracters amb la clau i ho tornem a
            //emmagatzemar al mateix vector
            clau = xifrador.digest(clau);
            clau = Arrays.copyOf(clau, 16); 
            
            //Definim l'objecte amb un nou SecretKeySpec, amb els parametres de la clau xifrada i l'algorisme AES
            ClauSecreta = new SecretKeySpec(clau, "AES");
        } 
        catch (NoSuchAlgorithmException e) {
        	//En cas de no existir l'algorisme d'encriptacio es mostrara a l'usuari com un error,
        	//en aquest cas no es mostrara mai degut a que  sempre usem l'alogorisme AES
            e.printStackTrace();
        }
        catch (UnsupportedEncodingException e) {
        	//En cas de que no es pugui codificar, es mostrara a l'usuari com un error,
        	//novament en aquest cas sempre usem UTF-8
            e.printStackTrace();
        }
    }
 
    public static byte[] encriptar(byte[] contingut, String clausecreta) 
    {
        try
        {
        	//executem la funcio assignarClau amb la contrasenya, aixo fara que es generi la SecretKey
        	assignarClau(clausecreta);
        	//Creem e inicialitzem una variable amb l'objecte cipher amb el mode d'encriptacio AES ECB
            Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
            //Definim que el mode del cipher sera d'encriptacio, i tambe usarem la SecretKey com a parametre
            cipher.init(Cipher.ENCRYPT_MODE, ClauSecreta);
            //retornem la cadena de bytes
            return cipher.doFinal(contingut);
        } 
        catch (Exception e) 
        {
            System.out.println("Error while encrypting: " + e.toString());
        }
        return null;
    }
 
    public static byte[] desencriptar(byte[] contingut, String secret) 
    {
        try
        {
        	//executem la funcio assignarClau amb la contrasenya, aixo fara que es generi la SecretKey
        	assignarClau(secret);
        	//Creem e inicialitzem una variable amb l'objecte cipher amb el mode d'encriptacio AES ECB
            Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5PADDING");
            //Definim que el mode del cipher sera de desencriptacio, i tambe usarem la SecretKey com a parametre
            cipher.init(Cipher.DECRYPT_MODE, ClauSecreta);
            //retornem la cadena de bytes
            return cipher.doFinal(contingut);
        } 
        catch (Exception e)
        {
            System.out.println("Error while decrypting: " + e.toString());
        }
        return null;
    }
	
}
