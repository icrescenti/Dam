#Exercici 1.2
segons = 4200
h = segons // 3600
m = segons % 3600 // 60
s = segons % 3600 % 60
print('{:02d}:{:02d}:{:02d}'.format(h, m, s))