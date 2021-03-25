import os, sys

try:
    from objectesa import *
except:
    e = sys.exc_info()[0]
    print("Error, algunes clases/llibreries no existeixen")
    exit(0)

clear = lambda: os.system('cls')
clear()

#Definicio Objectes
#------------------------------------------------------------
modul_1 = Modul("Matematiques")
modul_2 = Modul("Catala")
modul_3 = Modul("Fisica")

notes_1 = Notes()
notes_2 = Notes()
notes_3 = Notes()

#Definicio de valors
#------------------------------------------------------------
try:
    notes_1.addnotes(5)
    notes_1.addnotes(3)

    notes_2.addnotes(7)
    notes_2.addnotes(6)

    notes_3.addnotes(2)
    notes_3.addnotes(3)
except:
    e = sys.exc_info()[0]
    print("Error, les notes han de ser valors numerics")
    exit(0)

modul_1.notes = notes_1.notes
modul_2.notes = notes_2.notes
modul_3.notes = notes_3.notes
#------------------------------------------------------------

dni_1 = DNI(1234678, 'N')
persona_1 = Persona(dni_1, "Josep", "Mas",
    [
        modul_1,
        modul_2,
        modul_3,
    ]
)

try:
    print(persona_1.__str__())
except:
    e = sys.exc_info()[0]
    print("Error, format de dades incorrecte")
    exit(0)