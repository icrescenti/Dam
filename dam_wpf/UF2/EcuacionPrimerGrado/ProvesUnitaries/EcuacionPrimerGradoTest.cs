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
            testejarParsejador("2x - 1 = 0", 2);
            //testejarParsejador("24x - 15 = -3", 2);
        }

        void testejarParsejador(string equacio, double resultatEsperat)
        {
            EcuacionPrimerGrado.Parseador classeParsejador = new EcuacionPrimerGrado.Parseador();

            double resultat = classeParsejador.obtenerParte1(equacio);
            Assert.AreEqual(resultatEsperat, resultat, margeError, "Prova fallida");
        }
    }
}
