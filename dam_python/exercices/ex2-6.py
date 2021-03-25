#Exercici 2.6
num = int(input())


print("---------------------usant un for---------------------")
i = 1
for x in range(9):
    print(str(num) + " x " + str(i) + " = " + str(num * i))
    i+=1

print("---------------------usant un while-------------------")
i = 1
while i < 10:
    print(str(num) + " x " + str(i) + " = " + str(num * i))
    i+=1