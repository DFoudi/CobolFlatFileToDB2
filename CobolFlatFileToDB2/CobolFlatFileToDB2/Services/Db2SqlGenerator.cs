using CobolFlatFileToDB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobolFlatFileToDB2.Services
{
    public class Db2SqlGenerator
    {
        public string GenerateInsertScript(List<CompteClient> comptes)
        {
            var sb = new StringBuilder();
            foreach (var c in comptes)
            {
                sb.AppendLine($"INSERT INTO Comptes (NumeroCompte, Nom, Prenom, Solde) VALUES ('{c.NumeroCompte}', '{c.Nom}', '{c.Prenom}', {c.Solde.ToString().Replace(',', '.')});");
            }
            return sb.ToString();
        }
    }
}
