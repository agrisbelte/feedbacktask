using Bdp.Components.Models;

namespace Bdp.Mappers;

using Bdp.Data.Models;
using Mapster;
public static class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Feedback, FeedbackModel>
            .NewConfig();

        TypeAdapterConfig<FeedbackModel, Feedback>
            .NewConfig();
    }
}
