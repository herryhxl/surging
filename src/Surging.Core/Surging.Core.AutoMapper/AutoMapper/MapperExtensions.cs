using AutoMapper;

namespace Surging.Core.AutoMapper
{
    public static class MapperExtensions
    {
        public static T MapTo<T>(this IMapper mapper, object obj) where T : class
        {
            return mapper.Map<T>(obj);
        }

        public static TDestination MapTo<TSource, TDestination>(this IMapper mapper, TSource obj, TDestination entity) where TSource : class where TDestination : class
        {
            return mapper.Map<TSource, TDestination>(obj, entity);
        }
    }
}
