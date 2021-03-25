#Exercici 2.1
def calcTemps(segons, minuts = None, hores = None):
    if (minuts == None and hores == None):
        hores = segons // 3600
        minuts = segons % 3600 // 60
        segons = segons % 3600 % 60
        return '{:02d}:{:02d}:{:02d}'.format(hores, minuts, segons)
    else:
        return str(int(hores) * 3600 + int(minuts) * 60 + int(segons)) + " segons"
        

print(calcTemps(4200))