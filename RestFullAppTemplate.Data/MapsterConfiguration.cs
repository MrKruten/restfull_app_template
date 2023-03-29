using Mapster;
using Microsoft.Extensions.DependencyInjection;
using RestFullAppTemplate.Core.Models;
using RestFullAppTemplate.Data.Entities;

namespace RestFullAppTemplate.Data
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Participant, EParticipant>.NewConfig()
                .Map(e => e.Id, p => p.Id)
                .Map(e => e.Name, p => p.Name)
                .Map(e => e.EPromoId, p => p.PromoId);

            TypeAdapterConfig<EParticipant, Participant>.NewConfig()
                .Map(e => e.Id, p => p.Id)
                .Map(e => e.Name, p => p.Name)
                .Map(e => e.PromoId, p => p.EPromoId);

            TypeAdapterConfig<Prize, EPrize>.NewConfig()
                .Map(e => e.Id, p => p.Id)
                .Map(e => e.Description, p => p.Description)
                .Map(e => e.EPromoId, p => p.PromoId);

            TypeAdapterConfig<EPrize, Prize>.NewConfig()
                .Map(e => e.Id, p => p.Id)
                .Map(e => e.Description, p => p.Description)
                .Map(e => e.PromoId, p => p.EPromoId);

            TypeAdapterConfig<PromoResult, EPromoResult>.NewConfig()
                .Map(e => e.ParticipantId, p => p.ParticipantId)
                .Map(e => e.PrizeId, p => p.PrizeId);

            TypeAdapterConfig<EPromoResult, PromoResult>.NewConfig()
                .Map(e => e.ParticipantId, p => p.ParticipantId)
                .Map(e => e.PrizeId, p => p.PrizeId);

            TypeAdapterConfig<Promo, EPromo>.NewConfig()
                .Map(e => e.Id, p => p.Id)
                .Map(e => e.Description, p => p.Description)
                .Map(e => e.Name, p => p.Name).IgnoreNullValues(true);

            TypeAdapterConfig<EPromo, Promo>.NewConfig()
                .Map(e => e.Id, p => p.Id)
                .Map(e => e.Description, p => p.Description)
                .Map(e => e.Name, p => p.Name).IgnoreNullValues(true);
        }
    }
}