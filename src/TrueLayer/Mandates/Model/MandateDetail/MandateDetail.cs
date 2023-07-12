using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneOf;
using TrueLayer.Payments.Model;
using static TrueLayer.Payments.Model.Provider;
using static TrueLayer.Payments.Model.Beneficiary;

namespace TrueLayer.Mandates.Model.MandateDetail
{
    using Provider = OneOf<UserSelected, Preselected>;
    using Beneficiary = OneOf<ExternalAccount, MerchantAccount>;

    public abstract record MandateDetail(
        string Id,
        string Currency,
        Beneficiary Beneficiary,
        string Reference,
        PaymentUser User,
        DateTime CreatedAt,
        Constraints Constraints,
        Dictionary<string, string> Metadata,
        Provider ProviderSelection
    );
}
