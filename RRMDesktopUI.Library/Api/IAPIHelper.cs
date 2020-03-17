using RRMDesktopUI.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RRMDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}