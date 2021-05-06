package m9.uf3.ivancrescenti.a05;

import java.io.*;
import java.net.*;
import java.util.Scanner;

class Servidor {
	public static void main(String[] arg) {
		try {
			
			//Escanner ip de la maquina i port
			Scanner escaner = new Scanner(System.in);
			InetAddress direccio = InetAddress.getByName("localhost");
			int PORT;

			print(direccio.getHostAddress().toString() + "\n");

			//Port
			print("Port a escoltar: ");
			PORT = escaner.nextInt();

			//Obrir socol
			ServerSocket socketServidor = new ServerSocket(PORT);
			System.out.println("Escolto el port " + PORT);
			
			//Acceptar connexions
			Socket socketServei = socketServidor.accept();
			print("La IP del client es: " + socketServei.getInetAddress());

			//Pipe per rebre
			DataInputStream in = new DataInputStream(socketServei.getInputStream());

			//Llegir missatges rebuts fins dir prou
			Boolean execucio = true;
			while (execucio)
			{
				String msg = in.readUTF();
				if (msg.equals("prou"))
					execucio = false;

				print(msg + "\n");
			}

			//Tencar pipes
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