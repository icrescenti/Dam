#Exercici 3.2
llista = ['Digues', 'bon', 'dia', 'a', 'papa']
nova_llista = [None] * len(llista)

i = 1
for item in llista:
    nova_llista[len(nova_llista)-i] = item
    i += 1

i = 0
for item in nova_llista:
    llista[i] = item
    print(llista[i])
    i += 1