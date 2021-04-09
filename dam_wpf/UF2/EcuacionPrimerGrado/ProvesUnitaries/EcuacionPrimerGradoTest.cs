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
        public void TestMethod1()
        {
            testejarEquacio("2x - 1 = 0", 0.5);
        }

        void testejarEquacio(string equacio, double resultatEsperat)
        {
            EcuacionPrimerGrado.EcuacionPrimerGrado equacioProjecte = new EcuacionPrimerGrado.EcuacionPrimerGrado();

            double resultat = equacioProjecte.obtenerResultado("2x - 1 = 0");
            Assert.AreEqual(resultatEsperat, resultat, margeError, "Prova fallida");
        }
    }
}
