namespace BattleCity.Common
{
    public interface IConverter<out T1, in T2>
    {
        public T1 Convert(T2 argument);
    }
}