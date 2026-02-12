namespace Assets._Project.Develop.Runtime.Utilies.Conditions
{
    public interface ICompositeCondition : ICondition
    {
        ICompositeCondition Add(ICondition condition);
        ICompositeCondition Remove(ICondition condition);
    }
}
