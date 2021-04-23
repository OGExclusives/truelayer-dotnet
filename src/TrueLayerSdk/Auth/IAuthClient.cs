using System.Threading;
using System.Threading.Tasks;
using TrueLayerSdk.Auth.Models;

namespace TrueLayerSdk.Auth
{
    public interface IAuthClient
    {
        Task<GetAuthUriResponse> GetAuthUri(GetAuthUriRequest request);
        Task<ExchangeCodeResponse> ExchangeCode(ExchangeCodeRequest request, CancellationToken cancellationToken);
        Task<GetPaymentTokenResponse> GetPaymentToken(GetPaymentTokenRequest request, CancellationToken cancellationToken);
    }
}
