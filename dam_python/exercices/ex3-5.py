#Exercici 3.5
parauleta = input()

comptador = 0
for c in parauleta:
    if (c == 'a' or c == 'e' or c == 'i' or c == 'o' or c == 'u'):
        comptador += 1

print("La paraula compte " + str(comptador) + " vocals")