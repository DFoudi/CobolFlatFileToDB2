using Microsoft.VisualStudio.TestTools.UnitTesting;
using CobolFlatFileToDB2.Models;
using CobolFlatFileToDB2.Services;
using System.Collections.Generic;

namespace CobolFlatFileToDB2.Tests
{
    [TestClass]
    public class AnomalyReportServiceTests
    {
        [TestMethod]
        public void DetectAnomalies_DetectsNegativeAndMissingFields()
        {
            // Arrange
            var comptes = new List<CompteClient>
            {
                new CompteClient { NumeroCompte = "123", Nom = "A", Prenom = "B", Solde = -50 },   // négatif
                new CompteClient { NumeroCompte = "", Nom = "C", Prenom = "D", Solde = 100 },      // numéro manquant
                new CompteClient { NumeroCompte = "124", Nom = "", Prenom = "E", Solde = 10 },     // nom manquant
                new CompteClient { NumeroCompte = "125", Nom = "F", Prenom = "G", Solde = 10 }     // OK
            };
            var service = new AnomalyReportService();

            // Act
            var anomalies = service.DetectAnomalies(comptes);

            // Assert
            Assert.AreEqual(3, anomalies.Count);
        }

        [TestMethod]
        public void ExportAnomaliesToCsv_CreeLeBonFichier()
        {
            // Arrange
            var anomalies = new List<CompteClient>
            {
                new CompteClient { NumeroCompte = "111", Nom = "A", Prenom = "B", Solde = -50 }
            };
            var service = new AnomalyReportService();
            string tempFile = Path.GetTempFileName();

            // Act
            service.ExportAnomaliesToCsv(anomalies, tempFile);

            // Assert
            var contenu = File.ReadAllText(tempFile);
            Assert.IsTrue(contenu.Contains("111,A,B,-50"));

            // Cleanup
            File.Delete(tempFile);
        }
    }
}
