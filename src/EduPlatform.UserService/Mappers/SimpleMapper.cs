using EduPlatform.UserService.Mappers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EduPlatform.UserService.Mappers
{
    public class SimpleMapper : ISimpleMapper
    {
        public TDest ToMap<TSource, TDest>(TSource source) where TDest : new() => ToMap<TDest>(source!);

        public TDest ToMap<TDest>(object source) where TDest : new()
        {
            var sourceProps = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var destProps = typeof(TDest).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            var result = new TDest();

            foreach ( var destProp in destProps)
            {
                var sourceProrp = sourceProps.FirstOrDefault(p => p.Name == destProp.Name);

                if (sourceProrp != null && sourceProrp.CanRead && destProp.CanWrite)
                {
                    destProp.SetValue(result, sourceProrp.GetValue(source));
                }
            }

            return result;
        }

        public List<TDest> ToMap<TSource, TDest>(List<TSource> sources) where TDest : new()
        {
            var resultList = new List<TDest>();

            foreach (var source in sources)
            {
                resultList.Add(ToMap<TDest>(source!));
            }

            return resultList;
        }
    }
}
