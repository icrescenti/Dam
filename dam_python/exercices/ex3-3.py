#Exercici 3.3
llista = ['Queso', 'Coco', 'Huevo', 'Caramelo', 'Dulce de leche', 'Nata', 'Coco']
parauleta = input()

i = 0
comptador = 0
while ( i < len(llista) ):
    if (llista[i] == parauleta):
        comptador += 1
    i+=1

if (comptador > 0):
    print("La cadena existeix en la llista")
else:
    print("La cadena NO existeix en la llista")