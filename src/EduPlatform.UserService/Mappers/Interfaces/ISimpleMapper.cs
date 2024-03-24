using System.Collections.Generic;

namespace EduPlatform.UserService.Mappers.Interfaces
{
    public interface ISimpleMapper
    {
        public TDest ToMap<TSource, TDest>(TSource source)  where TDest : new();

        public TDest ToMap<TDest>(object source) where TDest : new();

        public List<TDest> ToMap<TSource, TDest>(List<TSource> sources) where TDest : new();
    }
}
