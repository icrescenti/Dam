#Exercici 3.6
parauleta = input()
lletra = input()
novaparaula = ""

for c in parauleta:
    novaparaula += (str(c) + str(lletra))

print("El text formatat sera: " + novaparaula)