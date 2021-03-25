#Exercici 3.4
llista = ['Matemàtiques', 'Física', 'Química', 'Història', 'Llengua']
suspeses = []

i = 1
nota_usuari = 0
while ( i < len(llista) ):
    print("Nota de " + llista[i] + ":")
    nota_usuari = int(input())
    if (nota_usuari < 5):
        suspeses.append(llista[i])
        llista[i] = None
    i += 1

for item in suspeses:
    print("Es te que repetir " + item)