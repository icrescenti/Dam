class Persona:
  def __init__(self, dni, nom, edat):
    self.nom = nom
    self.edat = edat
    self.DNI = dni
  
  def __str__(self):
    return "Nom: " + self.nom + "\nEdat: " + str(self.edat) + "\nDNI: " + str(self.DNI.numero) + self.DNI.lletra

class DNI:
  def __init__(self, numero, lletra):
    self.numero = numero
    self.lletra = lletra