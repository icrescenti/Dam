package m9.uf1.e3.icrescenti;

import java.io.File;
import java.io.FileInputStream;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.KeyStore;
import java.security.PrivateKey;
import java.security.Signature;
import java.util.Scanner;

public class A13_Signar {
	
	public static void main (String[] args)
	{
		//Creacio del escanner, per inserir dades
		Scanner escaner = new Scanner(System.in);
		
		print("Fitxer a signar: ");
		String fitxer = escaner.nextLine();
		escaner.close();
		
		PrivateKey clauPrivada = llegirMagatzemClaus("magatzemclausDSA.jks", "clausegura123");
		
		File f = new File(fitxer);
		if(f.exists())
		{ 
			try
			{
				byte[] vectorBytesFitxer = Files.readAllBytes(Paths.get(fitxer));

				//PROCESS DE FIRMADOR FIRMA
				Signature firmador = Signature.getInstance("DSA");
				firmador.initSign(clauPrivada);
				firmador.update(vectorBytesFitxer);
				byte[] vectorBytesSignat = firmador.sign();
				
				Files.write(Paths.get("signatura.dat"), vectorBytesSignat);
				print("Fitxer signat successivament.");
			}
			catch (Exception e)
	    	{
				
			}
		}
	}
	
	static void print(String msg)
	{
		System.out.print(msg);
	}
	
	public static PrivateKey llegirMagatzemClaus(String fitxer, String contrasenya) {
    	
    	String alias = "selfsigned";
		PrivateKey clau = null;
		
		try
		{
			KeyStore claustore = KeyStore.getInstance("JCEKS");
			FileInputStream fitxerStream = new FileInputStream(fitxer);
			
			claustore.load(fitxerStream, contrasenya.toCharArray());

			clau = (PrivateKey) claustore.getKey(alias, contrasenya.toCharArray());
		}
		catch(Exception e) 
		{
			System.err.println("No ha estat possible llegir el certificat");
		}
		
		return clau;
    	
    }
}
