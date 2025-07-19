using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobolFlatFileToDB2.Models
{
    public class CompteClient
    {
        public string NumeroCompte { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public decimal Solde { get; set; }
    }
}
