using CobolFlatFileToDB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CobolFlatFileToDB2.Services
{
    public class CobolFileParser
    {
        public List<CompteClient> Parse(string filePath)
        {
            var comptes = new List<CompteClient>();
            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.Length < 38)
                    continue; // Ligne trop courte ou vide

                var numeroCompte = line.Substring(0, 10).Trim();
                var nom = line.Substring(10, 10).Trim();
                var prenom = line.Substring(20, 10).Trim();
                var soldeStr = line.Substring(30, 8).Trim();

                // Gestion du solde avec ou sans signe
                decimal solde = 0;
                decimal.TryParse(soldeStr, out solde);

                comptes.Add(new CompteClient
                {
                    NumeroCompte = numeroCompte,
                    Nom = nom,
                    Prenom = prenom,
                    Solde = solde
                });
            }
            return comptes;
        }
    }
}
