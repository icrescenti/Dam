#Exercici 2.3
from calendar import monthrange

mes = int(input())

if (mes > 0 and mes < 13):
    print("El mes te " + str(monthrange(2021, mes)[1]) + " dies")