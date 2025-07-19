using CobolFlatFileToDB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobolFlatFileToDB2.Services
{
    public class AnomalyReportService
    {
        public List<CompteClient> DetectAnomalies(List<CompteClient> comptes)
        {
            return comptes
                .Where(c => c.Solde < 0 || string.IsNullOrWhiteSpace(c.NumeroCompte) || string.IsNullOrWhiteSpace(c.Nom) || string.IsNullOrWhiteSpace(c.Prenom))
                .ToList();
        }

        public void ExportAnomaliesToCsv(List<CompteClient> anomalies, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("NumeroCompte,Nom,Prenom,Solde");
                foreach (var c in anomalies)
                {
                    writer.WriteLine($"{c.NumeroCompte},{c.Nom},{c.Prenom},{c.Solde}");
                }
            }
        }
    }
}
