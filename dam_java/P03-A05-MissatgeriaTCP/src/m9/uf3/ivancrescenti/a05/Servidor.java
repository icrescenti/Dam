package m9.uf3.ivancrescenti.a05;

import java.io.*;
import java.net.*;
import java.util.Scanner;

class Servidor {
	public static void main(String[] arg) {
		try {
			
			Scanner escaner = new Scanner(System.in);
			InetAddress direccio = InetAddress.getByName("localhost");
			int PORT;

			print(direccio.getHostAddress().toString() + "\n");

			print("Port a escoltar: ");
			PORT = escaner.nextInt();

			ServerSocket socketServidor = new ServerSocket(PORT);
			System.out.println("Escolto el port " + PORT);
			
			Socket socketServei = socketServidor.accept();
			print("La IP del client es: " + socketServei.getInetAddress());
			DataInputStream in = new DataInputStream(socketServei.getInputStream());

			Boolean execucio = true;
			while (execucio)
			{
				String msg = in.readUTF();
				if (msg.equals("prou"))
					execucio = false;

				print(msg + "\n");
			}

			in.close();
			socketServei.close();
			socketServidor.close();

		} catch (Exception e) {
			System.out.println(e.getMessage());
		}
	}

	static void print(String msg)
	{
		System.out.print(msg);
	}
}