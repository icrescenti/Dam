package m9.uf3.ivancrescenti.a04;

import java.io.*;
import java.net.*;

class Client {
	static final String HOST = "localhost";
	static final int PORT = 5000;
	public static void main(String[] arg) {
		try {
			Socket socketClient = new Socket(HOST, PORT);
			DataInputStream in = new
			DataInputStream(socketClient.getInputStream());
			System.out.println(in.readUTF());
			in.close();
			socketClient.close();
		}
		catch (Exception e) {
			System.out.println(e.getMessage());
		}
	}
}