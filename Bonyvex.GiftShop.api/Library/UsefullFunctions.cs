using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Library
{
    public class UsefullFunctions : IUsefullFunctions
    {
        public async Task<bool> IsNullOrEmptyDecimal(decimal number)
        {
            if (number == null || number == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
