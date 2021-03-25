#Exercici 2.7
from random import randint

valor_intern = randint(1, 10)
valor = 0

while (valor != valor_intern):
    valor = int(input())

    if (valor > valor_intern):
        print("El valor es mes petit")
    elif (valor < valor_intern):
        print("El valor es mes gran")
    else:
        print("Has acertat el valor")