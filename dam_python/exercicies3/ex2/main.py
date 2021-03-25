from objectes import *
import os
clear = lambda: os.system('cls')
clear()

modul1 = Modul("Matematiques")
modul2 = Modul("Catala")

notes1 = Notes()
notes2 = Notes()

notes1.addnotes(4)
notes1.addnotes(7)
notes1.addnotes(5)

notes2.addnotes(4)
notes2.addnotes(3)
notes2.addnotes(1)

notes1.modnotes(0,10)

notes1.delnotes(1)

modul1.notes = notes1.notes
modul2.notes = notes2.notes

print(modul1.__str__())
print(modul2.__str__())
print(modul1.mitjana())
print(modul2.mitjana())