using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unico.FeiraLivre.Infrastructure.ViewModel
{
    public class FeiraModel
    {
        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string SetCens { get; set; }
        public string AreaP { get; set; }
        public string CodDist { get; set; }
        public string Distrito { get; set; }
        public string CodSubPref { get; set; }
        public string SubPref { get; set; }
        public string Regiao05 { get; set; }
        public string Regiao08 { get; set; }
        public string NomeFeira { get; set; }
        public string Registro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Referencia { get; set; }
    }
}
