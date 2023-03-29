using RestFullAppTemplate.Core.Services;
using RestFullAppTemplate.Services.Services;

namespace RestFullAppTemplate.Services
{
    public static class ContainerRegistration
    {
        public static IReadOnlyDictionary<Type, Type> GetInterfaceBindings()
        {
            var result = new Dictionary<Type, Type>();
            result.Add(typeof(IParticipantsService), typeof(ParticipantsService));
            result.Add(typeof(IPrizesService), typeof(PrizesService));
            result.Add(typeof(IPromotionsService), typeof(PromotionsService));
            return result;
        }
    }
}