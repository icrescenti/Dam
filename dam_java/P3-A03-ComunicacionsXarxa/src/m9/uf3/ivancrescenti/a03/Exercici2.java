//package m9.uf3.ivancrescenti.a03;

import java.net.*;
import java.util.Scanner;

public class Exercici2 {
	public static void main(String[] args) {

		Scanner escaner = new Scanner(System.in);

		InetAddress dir=null;
		System.out.println("========================================================");
		System.out.println("Sortida per localhost");
		try {
			//LOCALHOST
			dir = InetAddress.getByName("localhost");
			provaMetodes(dir);//
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
		}
		catch (UnknownHostException e) {
			e.printStackTrace();
		}
	}
}
