#Exercici 2.8
num = int(input())

valor= range(2,num)
contador = 0

for n in valor:
  if num % n == 0:
    contador +=1
 
if contador > 0 :
  print("El numero NO es primer")
else:
  print("El numero es primer")