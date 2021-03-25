#Exercici 3.1
valors = []
num = 0
continuar = 1

i = 0
while (bool(continuar)):
    num = int(input())
    valors.append(num)
    if (valors[i] < 0):
        
        print("---------------------------")
        print("Els valors parells son:")

        contador_valors = 0
        for v in valors:
            contador_valors += 1
            if (v % 2 == 0):
                print(str(v))
            
        print("---------------------------")

        print("Cadena finalitzada amb " + str(contador_valors) + " valors, degut a la insercio de " + str(valors[i]))
        continuar = 0
    i+=1