import java.security.NoSuchAlgorithmException;
import javax.crypto.KeyGenerator;
import javax.crypto.SecretKey;

public class codifeina {
	
	public static void main(String args[])
	{
		SecretKey sc = keygenKeyGeneration(128);
		System.out.println("Resultat: " + sc);
	}

	public static SecretKey keygenKeyGeneration(int keySize) {
		SecretKey sKey = null;
		if ((keySize == 128)||(keySize == 192)||(keySize == 256)) {
			try {
				KeyGenerator kgen = KeyGenerator.getInstance("AES");
				kgen.init(keySize);
				sKey = kgen.generateKey();
			}
			catch (NoSuchAlgorithmException ex) {
				System.err.println("Generador no disponible.");
			}
		}
		
		return sKey;
	}
	
}
