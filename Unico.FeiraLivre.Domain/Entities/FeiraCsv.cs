using System.Collections.Generic;

namespace Unico.FeiraLivre.Domain.Entities
{
    public class FeiraCsv
    {
        public int ID { get; set; }
        public string LONG { get; set; }
        public string LAT { get; set; }
        public string SETCNS { get; set; }
        public string AREAP { get; set; }
        public string CODDIST { get; set; }
        public string DISTRITO { get; set; }
        public string CODSUBPREF { get; set; }
        public string SUBPREF { get; set; }
        public string REGIAO05 { get; set; }
        public string REGIAO08 { get; set; }
        public string NOMEFEIRA { get; set; }
        public string REGISTRO { get; set; }
        public string LOGRADOURO { get; set; }
        public string NUMERO { get; set; }
        public string BAIRRO { get; set; }
        public string REFERENCIA { get; set; }

        public override string ToString()
        {
            return $"ID {ID}: LONG: {LONG}, LAT: {LAT}";
        }

    }
}
