package m9.uf3.ivancrescenti.a05;

import java.io.DataOutputStream;
import java.io.IOException;
import java.net.*;
import java.util.Scanner;

class Client {
	public static void main(String[] arg) {
		//Escaner i Socol
		Scanner escaner = new Scanner(System.in);
		Socket socketClient;

		//Host i port
		String HOST;
		int PORT;

		try {

			//IP de la maquina
			InetAddress direccio = InetAddress.getByName("localhost");
			print(direccio.getHostAddress().toString());
		
			//Definicio de host i port
			print("Insereix les dades del socket\n");
			print("IP: ");
			HOST = escaner.nextLine();
			print("Port: ");
			PORT = escaner.nextInt();
			escaner.nextLine();
			
			//obrir socol
			socketClient = new Socket(HOST, PORT);

			//obrir pipe per enviar
			DataOutputStream outStream = new DataOutputStream(socketClient.getOutputStream());

			//enivar missatges fins dir prou
			Boolean execucio = true;
			while (execucio)
			{
				print("Missatge a enviar: ");
				String msg = escaner.nextLine();

				if (msg.equals("prou"))
					execucio = false;

				outStream.writeUTF(msg);
			}
			
			//tancar pipes
			escaner.close();
			outStream.close();
			socketClient.close();

		} catch (UnknownHostException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}

	}

	static void print(String msg)
	{
		System.out.print(msg);
	}
}