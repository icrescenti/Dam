#Exercici 3.7
parauleta = input()
capitals = ""
paraules_capitals = ""

pos = 0
for c in parauleta:
    if (c.isupper()):
        capitals += (str(c))
    
    if (pos == 0):
        paraules_capitals += c.upper()
    else: paraules_capitals += c.lower()
    
    if (c == ' '):
        pos = 0
    else: pos += 1

print("Capitals: " + capitals)
print("Text en minuscules amb les capitals marcades: " + paraules_capitals)