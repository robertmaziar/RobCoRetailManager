using RRMDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace RRMDesktopUI.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}