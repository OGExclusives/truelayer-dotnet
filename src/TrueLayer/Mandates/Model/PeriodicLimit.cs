using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueLayer.Mandates.Model
{
    public record PeriodicLimit(
        PeriodicLimitDetail Day,
        PeriodicLimitDetail Week,
        PeriodicLimitDetail Fortnight,
        PeriodicLimitDetail Month,
        PeriodicLimitDetail HalfYear,
        PeriodicLimitDetail Year
    );
}
