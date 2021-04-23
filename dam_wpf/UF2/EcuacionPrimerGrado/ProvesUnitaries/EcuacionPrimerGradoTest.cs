using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EcuacionPrimerGrado;

namespace ProvesUnitaries
{
    [TestClass]
    public class EcuacionPrimerGradoTest
    {
        const float margeError = 0.001f;

        [TestMethod]
        public void testejarEquacions()
        {
            testejarEquacio("2x - 1 = 0", 0.5f);
            testejarEquacio("2x + 1 = 0", -0.5);
            testejarEquacio("2x + 1 = 10", 4.5f);
            testejarEquacio("2x + 1 = -10", -5.5f);
            
            //ERROR
            //testejarEquacio("hola", -4.5);
        }

        void testejarEquacio(string equacio, double resultatEsperat)
        {
            EcuacionPrimerGrado.EcuacionPrimerGrado equacioProjecte = new EcuacionPrimerGrado.EcuacionPrimerGrado();

            double resultat = equacioProjecte.obtenerResultado(equacio);
            Assert.AreEqual(resultatEsperat, resultat, margeError, "Prova fallida");
        }
    }

    [TestClass]
    public class ParsejadorTest
    {
        const float margeError = 0.001f;

        [TestMethod]
        public void testejarParts()
        {
            EcuacionPrimerGrado.Parseador classeParsejador = new EcuacionPrimerGrado.Parseador();

            testejarParsejador1(classeParsejador, "2x + 10 = 15", 2);
            testejarParsejador1(classeParsejador, "14x - 1 = -20", 14);

            testejarParsejador2(classeParsejador, "1x - 1 = 0", -1);
            testejarParsejador2(classeParsejador, "1x + 2 = 2", 2);

            testejarParsejador3(classeParsejador, "1x + 2 = -7", -7);
            testejarParsejador3(classeParsejador, "1x + 2 = 4", 4);

            testejarParsejadorOperador(classeParsejador, "1x + 2 = 4", "+");
            testejarParsejadorOperador(classeParsejador, "1x - 2 = 4", "-");
        }

        void testejarParsejador1(EcuacionPrimerGrado.Parseador classeParsejador, string equacio, double resultatEsperat)
        {
            double resultat = classeParsejador.obtenerParte1(equacio);
            Assert.AreEqual(resultatEsperat, resultat, margeError, "Prova fallida");
        }
        
        void testejarParsejador2(EcuacionPrimerGrado.Parseador classeParsejador, string equacio, double resultatEsperat)
        {
            double resultat = classeParsejador.obtenerParte2(equacio);
            Assert.AreEqual(resultatEsperat, resultat, margeError, "Prova fallida");
        }
        
        void testejarParsejador3(EcuacionPrimerGrado.Parseador classeParsejador, string equacio, double resultatEsperat)
        {
            double resultat = classeParsejador.obtenerParte3(equacio);
            Assert.AreEqual(resultatEsperat, resultat, margeError, "Prova fallida");
        }
        
        void testejarParsejadorOperador(EcuacionPrimerGrado.Parseador classeParsejador, string equacio, string resultatEsperat)
        {
            string resultat = classeParsejador.obtenerOperador(equacio);
            Assert.AreEqual(resultatEsperat, resultat);
        }
    }
}
