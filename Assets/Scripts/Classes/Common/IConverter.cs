namespace BattleCity.Common
{
    public interface IConverter<T1, T2>
    {
        public T1 Convert(T2 argument);
    }
}