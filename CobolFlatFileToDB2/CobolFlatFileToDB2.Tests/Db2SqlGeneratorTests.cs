using CobolFlatFileToDB2.Models;
using CobolFlatFileToDB2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobolFlatFileToDB2.Tests
{
    [TestClass]
    public class Db2SqlGeneratorTests
    {
        [TestMethod]
        public void GenerateInsertScript_ReturnsCorrectSql()
        {
            // Arrange
            var comptes = new List<CompteClient>
            {
                new CompteClient { NumeroCompte = "111", Nom = "NOM", Prenom = "PRENOM", Solde = 100 }
            };
            var generator = new Db2SqlGenerator();

            // Act
            string sql = generator.GenerateInsertScript(comptes);

            // Assert
            string attendu = "INSERT INTO Comptes (NumeroCompte, Nom, Prenom, Solde) VALUES ('111', 'NOM', 'PRENOM', 100);\n";
            Assert.AreEqual(attendu, sql.Replace("\r\n", "\n")); // Normalise fin de ligne Windows/Linux
        }
    }
}
