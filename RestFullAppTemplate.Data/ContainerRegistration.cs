﻿namespace RestFullAppTemplate.Data
{
    public static class ContainerRegistration
    {
        public static IReadOnlyDictionary<Type, Type> GetInterfaceBindings()
        {
            var result = new Dictionary<Type, Type>();
            return result;
        }
    }
}