package m9.uf3.ivancrescenti.a04;

import java.io.*;
import java.net.*;
import java.util.Scanner;

class Client {
	static final String HOST = "localhost";
	static final int PORT = 2234;

	public static void main(String[] arg) {
		Scanner escaner = new Scanner(System.in);

		try {
			//Socket amb la IP i Port a connectarse
			Socket socketClient = new Socket(HOST, PORT);
			
			//Pipes per rebre i enviar
			DataOutputStream outStream = new DataOutputStream(socketClient.getOutputStream());
			DataInputStream in = new DataInputStream(socketClient.getInputStream());

			boolean victoria = false;

			for (int i = 0; i<5 && !victoria; i++) {
				System.out.println("Numero a endevinar");
				String msg = escaner.nextLine();

				//enivament missatge
				outStream.writeUTF(msg);
				//resposta
				System.out.println(in.readUTF());
				//retorna si el numero ha estat acertat
				victoria = in.readBoolean();
			}

			if (!victoria)
			{
				System.out.println(in.readUTF());
			}
			
			//tenquem pipes
			escaner.close();
			outStream.close();
			in.close();
			socketClient.close();
		}
		catch (Exception e) {
			System.out.println(e.getMessage());
		}
	}
}