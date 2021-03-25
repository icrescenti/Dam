#Exercici 1.1
temps = "1:00:00"
h, m, s = temps.split(':')
print(str(int(h) * 3600 + int(m) * 60 + int(s)) + " segons")