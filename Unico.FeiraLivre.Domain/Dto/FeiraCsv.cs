using System.Collections.Generic;
using TinyCsvParser.Mapping;

namespace Unico.FeiraLivre.Domain.Dto
{
    public class FeiraCsv
    {
        public int ID { get; set; }
        public string LONG { get; set; }
        public string LAT { get; set; }
        public string SETCENS { get; set; }
        public string AREAP { get; set; }
        public string CODDIST { get; set; }
        public string DISTRITO { get; set; }
        public string CODSUBPREF { get; set; }
        public string SUBPREFE { get; set; }
        public string REGIAO5 { get; set; }
        public string REGIAO8 { get; set; }
        public string NOME_FEIRA { get; set; }
        public string REGISTRO { get; set; }
        public string LOGRADOURO { get; set; }
        public string NUMERO { get; set; }
        public string BAIRRO { get; set; }
        public string REFERENCIA { get; set; }
    }

    public class ImportFeiraCsvMapping : CsvMapping<FeiraCsv>
    {
        public ImportFeiraCsvMapping() : base()
        {
            MapProperty(0, x => x.ID);
            MapProperty(1, x => x.LONG);
            MapProperty(2, x => x.LAT);
            MapProperty(3, x => x.SETCENS);
            MapProperty(4, x => x.AREAP);
            MapProperty(5, x => x.CODDIST);
            MapProperty(6, x => x.DISTRITO);
            MapProperty(7, x => x.CODSUBPREF);
            MapProperty(8, x => x.SUBPREFE);
            MapProperty(9, x => x.REGIAO5);
            MapProperty(10, x => x.REGIAO8);
            MapProperty(11, x => x.NOME_FEIRA);
            MapProperty(12, x => x.REGISTRO);
            MapProperty(13, x => x.LOGRADOURO);
            MapProperty(14, x => x.NUMERO);
            MapProperty(15, x => x.BAIRRO);
            MapProperty(16, x => x.REFERENCIA);
        }
    }
}
