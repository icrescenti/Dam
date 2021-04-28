package m9.uf3.ivancrescenti.a03;

import java.net.*;

public class Exercici3 {
	public static void main (String[] args) {
		URL url;
		try {

			System.out.println("Constructor simple per a URL");
			url =new URL("http://docs.oracle.com");
			Visualitzar(url);
			
			System.out.println("Constructor simple per a URL");
			url =new URL("http://docs.oracle.com/javase/10");
			Visualitzar(url);
			
			System.out.println("Constructor simple per a URL");
			url =new URL("http://docs.oracle.com/javase/10/docs/api/java/net/URL.html");
			Visualitzar(url);

		}catch (MalformedURLException e) {
			System.out.println(e);
		}
	}
	
	private static void Visualitzar(URL url) {
		System.out.println("\tURL completa: " + url.toString());
		System.out.println("Protocol: " + url.getProtocol());
		System.out.println("Host: " + url.getHost());
		System.out.println("Port: " + url.getPort());
		System.out.println("Ruta: " + url.getPath());
		System.out.println("Informacio del l\'usuari': " + url.getUserInfo());
		System.out.println("Autoritat': " + url.getAuthority());
		System.out.println("Port per defecte': " + url.getDefaultPort());
	}
}
