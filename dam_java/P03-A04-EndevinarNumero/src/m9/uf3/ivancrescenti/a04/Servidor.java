package m9.uf3.ivancrescenti.a04;

import java.io.*;
import java.net.*;

class Servidor {
	static final int PORT = 5000;
	public static void main(String[] arg) {
		try {
			ServerSocket socketServidor = new ServerSocket(PORT);
			System.out.println("Escolto el port " + PORT);
			for (int nClients = 0; nClients < 3; nClients++) {
				Socket socketServei = socketServidor.accept();
				System.out.println("Serveixo al client " + nClients);
				DataOutputStream out = new
				DataOutputStream( socketServei .getOutputStream());
				out.writeUTF("Hola client " + nClients);
				out.close();
				socketServei .close();
			}
			System.out.println("Massa clients per avui");
			socketServidor.close();
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}
	}
}