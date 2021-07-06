using System.Threading.Tasks;
using Unico.FeiraLivre.Domain.Common;

namespace Unico.FeiraLivre.Service.Contract
{
    public interface IImportFeiraService{
        Task<Response<string>> ImportFeiraAsync(bool import, string path);
    }
}