using System.Threading.Tasks;
using OneOf;
using Shouldly;
using TrueLayer.Payments.Model;
using Xunit;

namespace TrueLayer.AcceptanceTests
{
    using ProviderUnion = OneOf<Provider.UserSelected, Provider.Preselected>;
    using AccountIdentifierUnion = OneOf<AccountIdentifier.SortCodeAccountNumber, AccountIdentifier.Iban>;

    public class PaymentProvidersTests : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _fixture;

        public PaymentProvidersTests(ApiTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Can_get_payments_provider_with_payments_capabilities()
        {
            const string providerId = "mock-payments-gb-redirect";

            var response = await _fixture.Client.PaymentsProviders.GetPaymentsProvider(providerId);

            response.IsSuccessful.ShouldBeTrue();
            response.Data.ShouldNotBeNull();
            response.Data.Id.ShouldBe(providerId);
            response.Data.DisplayName.ShouldNotBeNull();
            response.Data.IconUri.ShouldNotBeNull();
            response.Data.LogoUri.ShouldNotBeNull();
            response.Data.BgColor.ShouldNotBeNull();
            response.Data.CountryCode.ShouldNotBeNull();
            response.Data.Capabilities.Payments.BankTransfer.ShouldNotBeNull();
            response.Data.Capabilities.Payments.BankTransfer.ReleaseChannel.ShouldNotBeNull();
            response.Data.Capabilities.Payments.BankTransfer.Schemes.ShouldHaveSingleItem();
        }

        [Fact]
        public async Task Can_get_payments_provider_with_mandates_capabilities()
        {
            const string providerId = "ob-uki-mock-bank-sbox";

            var response = await _fixture.Client.PaymentsProviders.GetPaymentsProvider(providerId);

            response.IsSuccessful.ShouldBeTrue();
            response.Data.ShouldNotBeNull();
            response.Data.Id.ShouldBe(providerId);
            response.Data.DisplayName.ShouldNotBeNull();
            response.Data.CountryCode.ShouldNotBeNull();
            response.Data.Capabilities.Mandates.VrpSweeping.ShouldNotBeNull();
            response.Data.Capabilities.Mandates.VrpSweeping.ReleaseChannel.ShouldNotBeNull();
        }
    }
}
