using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourGuideFamily.Dal.Settings;

public record DalOptions
{
    public required string PostgresConnectionString { get; init; } = string.Empty;
}