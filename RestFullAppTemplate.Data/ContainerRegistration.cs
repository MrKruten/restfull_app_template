using RestFullAppTemplate.Core.Repositories;
using RestFullAppTemplate.Data.Repositories;

namespace RestFullAppTemplate.Data
{
    public static class ContainerRegistration
    {
        public static IReadOnlyDictionary<Type, Type> GetInterfaceBindings()
        {
            var result = new Dictionary<Type, Type>();
            result.Add(typeof(IParticipantsRepository), typeof(ParticipantsRepository));
            result.Add(typeof(IPrizesRepository), typeof(PrizesRepository));
            result.Add(typeof(IPromotionsRepository), typeof(PromotionsRepository));
            return result;
        }
    }
}