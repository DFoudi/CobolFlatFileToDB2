using System;
using CobolFlatFileToDB2.Services;
using CobolFlatFileToDB2.Models;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "comptes.txt"; // Assure-toi que ton fichier est bien à la racine du projet (copie locale de sortie = Toujours copier)

        var parser = new CobolFileParser();
        var comptes = parser.Parse(filePath);

        Console.WriteLine("Comptes chargés depuis le fichier :");
        foreach (var c in comptes)
        {
            Console.WriteLine($"{c.NumeroCompte} | {c.Nom} | {c.Prenom} | {c.Solde}");
        }

        var sqlGenerator = new Db2SqlGenerator();
        string script = sqlGenerator.GenerateInsertScript(comptes);

        Console.WriteLine("\nScript SQL DB2 généré :");
        Console.WriteLine(script);

        var anomalyService = new AnomalyReportService();
        var anomalies = anomalyService.DetectAnomalies(comptes);

        Console.WriteLine("\nAnomalies détectées :");
        foreach (var a in anomalies)
        {
            Console.WriteLine($"{a.NumeroCompte} | {a.Nom} | {a.Prenom} | {a.Solde}");
        }

        // (Bonus export CSV)
        if (anomalies.Any())
        {
            string anomalyFile = "anomalies.csv";
            anomalyService.ExportAnomaliesToCsv(anomalies, anomalyFile);
            Console.WriteLine($"\nRapport d'anomalies exporté vers : {anomalyFile}");
        }
    }
}
