package campdeproves;

import java.security.MessageDigest;
import java.util.Arrays;
import java.util.Base64;

import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;

public class feine {
	public static void main(String[] args) throws Exception {
		byte[] IV_PARAM = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
		String res = encrypt("12345", IV_PARAM, "Avui és dimecres 2 de novembre");
		System.out.print(res);
    }

	public static String encrypt(String key, byte[] iv, String msg) throws Exception {
        byte[] bytesOfKey = key.getBytes("UTF-8");
        MessageDigest md = MessageDigest.getInstance("SHA-256");
        byte[] keyBytes = md.digest(bytesOfKey);

        final byte[] ivBytes = iv;

        keyBytes = Arrays.copyOf(keyBytes, 16);
        SecretKeySpec secretKeySpec = new SecretKeySpec(keyBytes, "AES");
        Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
        cipher.init(Cipher.ENCRYPT_MODE, secretKeySpec, new IvParameterSpec(ivBytes));

        final byte[] resultBytes = cipher.doFinal(msg.getBytes());
        return Base64.getMimeEncoder().encodeToString(resultBytes);
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
