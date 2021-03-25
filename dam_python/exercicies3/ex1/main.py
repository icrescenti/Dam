from objectes import *
import os
clear = lambda: os.system('cls')
clear()

dni1 = DNI(1234678, 'N')
persona1 = Persona(dni1, "Josep", "Mas")

print(persona1.__str__())