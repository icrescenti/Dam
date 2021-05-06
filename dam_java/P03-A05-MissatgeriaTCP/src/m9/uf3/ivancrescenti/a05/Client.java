package m9.uf3.ivancrescenti.a05;

import java.io.DataOutputStream;
import java.io.IOException;
import java.net.*;
import java.util.Scanner;

class Client {
	public static void main(String[] arg) {
		Scanner escaner = new Scanner(System.in);
		Socket socketClient;

		String HOST;
		int PORT;

		try {

			InetAddress direccio = InetAddress.getByName("localhost");
			print(direccio.getHostAddress().toString());
		
			print("Insereix les dades del socket\n");
			print("IP: ");
			HOST = escaner.nextLine();
			print("Port: ");
			PORT = escaner.nextInt();
			escaner.nextLine();
			
			socketClient = new Socket(HOST, PORT);

			DataOutputStream outStream = new DataOutputStream(socketClient.getOutputStream());

			Boolean execucio = true;
			while (execucio)
			{
				print("Missatge a enviar: ");
				String msg = escaner.nextLine();

				if (msg.equals("prou"))
					execucio = false;

				outStream.writeUTF(msg);
			}
			

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