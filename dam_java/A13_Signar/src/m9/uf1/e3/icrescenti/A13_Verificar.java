package m9.uf1.e3.icrescenti;

import java.io.File;
import java.io.FileInputStream;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.PublicKey;
import java.security.Signature;
import java.security.cert.Certificate;
import java.security.cert.CertificateFactory;
import java.util.Scanner;

public class A13_Verificar {
	
	public static void main (String[] args)
	{
		//Creacio del escanner, per inserir dades
		Scanner escaner = new Scanner(System.in);
				
		print("Fitxer a verificar: ");
		String fitxer = escaner.nextLine();
		escaner.close();
				
		PublicKey clauPublica = llegirCertificatPublic("certificatDSA.cer");
		
		File f = new File(fitxer);
		if(f.exists())
		{ 
			try
			{
				byte[] vectorBytesFitxer = Files.readAllBytes(Paths.get(fitxer));
				byte[] vectorBytesSignatura = Files.readAllBytes(Paths.get("signatura.dat"));
				
				//PROCESS DE FIRMADOR FIRMA
				Signature firmador = Signature.getInstance("DSA");
				firmador.initVerify(clauPublica);
				firmador.update(vectorBytesFitxer);
				boolean verificat = firmador.verify(vectorBytesSignatura);
				
				if (verificat)
					print("La firma del fitxer es valida");
				else
					print("La firma del fitxer NO es valida");
					
			}
			catch (Exception e)
	    	{
				print(e.toString());
			}
		}
	}
	
	static void print(String msg)
	{
		System.out.print(msg);
	}

	public static PublicKey llegirCertificatPublic(String fitxer)
    {
    	try
    	{
    		FileInputStream fis = new FileInputStream(fitxer);
    		CertificateFactory certFabricador = CertificateFactory.getInstance("X.509");
    		Certificate certificate = certFabricador.generateCertificate(fis);
    		return certificate.getPublicKey();
    	}
    	catch (Exception e) {
    		return null;
    	}
    }
}
