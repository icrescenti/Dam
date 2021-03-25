class Persona:
  def __init__(self, dni, nom, edat, moduls):
    self.nom = nom
    self.edat = edat
    self.DNI = dni
    self.moduls = moduls
  
  def __str__(self):
    dynInfo = "Nom: " + self.nom + "\nEdat: " + str(self.edat) + "\nDNI: " + str(self.DNI.numero) + self.DNI.lletra + "\n-------------Notes-------------"
    for modul in self.moduls:
      dynInfo = dynInfo + "\nNotes de " + modul.modul + ": "
      for nota in modul.notes:
        dynInfo = dynInfo + str(nota) + ", "
    return dynInfo

class DNI:
  def __init__(self, numero, lletra):
    self.numero = numero
    self.lletra = lletra

class Modul:
  def __init__(self, modul):
    self.modul = modul
    self.notes = []

  def __str__(self):
    dynNotes = ""

    for nota in self.notes:
      dynNotes = dynNotes + str(nota) + ", "
    return "Notes de " + self.modul + ": " + dynNotes
  
  def mitjana(self):
    dynNota =  0

    for nota in self.notes:
      dynNota = dynNota + nota
    return "La mitjana de " + self.modul + " sera: " + str(dynNota/len(self.notes))

class Notes:

  def __init__(self):
    self.notes = []
    self = self
  
  def addnotes(self, nota):
    self.notes.append(nota)

  def modnotes(self, pos, nota):
    self.notes[pos] = nota

  def delnotes(self, pos):
    self.notes.pop(pos)