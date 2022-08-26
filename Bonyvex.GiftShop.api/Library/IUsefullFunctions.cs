using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Library
{
    public interface IUsefullFunctions
    {
        Task<bool> IsNullOrEmptyDecimal(decimal number);
    }
}
