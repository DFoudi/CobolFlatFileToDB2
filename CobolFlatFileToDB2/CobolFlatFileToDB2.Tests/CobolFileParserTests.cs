using Microsoft.VisualStudio.TestTools.UnitTesting;
using CobolFlatFileToDB2.Services;
using CobolFlatFileToDB2.Models;
using System.Collections.Generic;
using System.IO;

namespace CobolFlatFileToDB2.Tests
{
    [TestClass]
    public class CobolFileParserTests
    {
        [TestMethod]
        public void Parse_ValidFile_ReturnsCorrectComptes()
        {
            // Arrange
            string[] lines = {
                "0000012345DUPONT     JEAN      00010200",
                "0000012346MARTIN     MARIE     00004500"
            };
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, lines);

            var parser = new CobolFileParser();

            // Act
            var comptes = parser.Parse(tempFile);

            // Assert
            Assert.AreEqual(2, comptes.Count);
            Assert.AreEqual("0000012345", comptes[0].NumeroCompte);
            Assert.AreEqual("DUPONT", comptes[0].Nom);
            Assert.AreEqual("JEAN", comptes[0].Prenom);
            Assert.AreEqual(1020, comptes[0].Solde);

            // Cleanup
            File.Delete(tempFile);
        }

        [TestMethod]
        public void Parse_LigneTropCourte_IgnoreLaLigne()
        {
            // Arrange
            string[] lines = { "TROPCOURT" };
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, lines);

            var parser = new CobolFileParser();

            // Act
            var comptes = parser.Parse(tempFile);

            // Assert
            Assert.AreEqual(0, comptes.Count);

            // Cleanup
            File.Delete(tempFile);
        }
    }
}
