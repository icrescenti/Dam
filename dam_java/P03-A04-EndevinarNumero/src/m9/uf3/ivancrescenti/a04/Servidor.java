package m9.uf3.ivancrescenti.a04;

import java.io.*;
import java.net.*;
import java.util.Random;

class Servidor {
	static final int PORT = 2234;
	public static void main(String[] arg) {
		try {
			//Iniciem un socket amb el port 2234
			ServerSocket socketServidor = new ServerSocket(PORT);
			System.out.println("Escolto el port " + PORT);

			//Auto-acceptem qualsevol peticio de algun client
			Socket socketServei = socketServidor.accept();

			//Generem el numero aleatori
			Random rand = new Random();
			int numeroAleatori = rand.nextInt(100);
			System.out.println("(Secret) El numero generat es: " + numeroAleatori);

			//Obrim 2 pipes, per rebre i enviar informacio
			DataInputStream in = new DataInputStream(socketServei.getInputStream());
			DataOutputStream outStream = new DataOutputStream(socketServei.getOutputStream());
			boolean correcte = false;

			try {
				for (int i = 0; i<5 && !correcte; i++)
				{
					//Parseja el valor del client
					int numero = Integer.parseInt(in.readUTF());

					if (numero == numeroAleatori)
					{
						outStream.writeUTF("Molt bé has endevinat el número");
						correcte = true;
					}
					else if (numero < numeroAleatori)
						outStream.writeUTF("El número a endevinar és major al número " + numero);
					else
						outStream.writeUTF("El número a endevinar és menor al número " + numero);
				
					outStream.writeBoolean(correcte);
				}

				if (!correcte)
					outStream.writeUTF("Has esgotat els intents, el número era el " + numeroAleatori);

			} catch (NumberFormatException e) {
				outStream.writeUTF("El missatge rebut no és correcte, ha de ser un número entre 1 i 99");
			}

			//Tenquem les pipes i els sockets
			outStream.close();
			in.close();
			socketServei.close();
			socketServidor.close();
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}
	}
}