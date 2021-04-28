package m9.uf3.ivancrescenti.a03;

import java.net.*;

public class Exercici1 {
	public static void main(String[] args) {
		InetAddress dir=null;
		System.out.println("========================================================");
		System.out.println("Sortida per localhost");
		try {

			//LOCALHOST
			dir = InetAddress.getByName("localhost");
			provaMetodes(dir);

			//URL www.google.es
			System.out.println("====================================================");
			System.out.println("Sortida per a URL: ");
			dir = InetAddress.getByName("www.yahoo.es");
			provaMetodes(dir);
		}
		catch (UnknownHostException e1) {
			e1.printStackTrace();
		}
	}
	
	private static void provaMetodes(InetAddress dir) {
		System.out.println("\tMetode getByName(): " + dir);
		InetAddress dir2;
		try {
			dir2 = InetAddress.getLocalHost();
			System.out.println("\tMètode getLocalHost(): " + dir2);
			System.out.println("\tMètode getHostName(): " + dir.getHostName());
			System.out.println("\tMètode getAddress(): " + dir.getAddress());
			System.out.println("\tMètode getAddress(): " + dir.getHostAddress());
			System.out.println("\tMètode getCanonicalHostName(): " + dir.getCanonicalHostName());
		}
		catch (UnknownHostException e) {
			e.printStackTrace();
		}
	}
}
