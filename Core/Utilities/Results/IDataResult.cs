using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult //<T> -- Hangi tipi döndüreceğini bana söyle! Generic.
    {
        T Data { get; } //IResulttaki sabitlerim var ve burada aynı zamanda ürün ya da ürünlerim olabilir.
    }
}