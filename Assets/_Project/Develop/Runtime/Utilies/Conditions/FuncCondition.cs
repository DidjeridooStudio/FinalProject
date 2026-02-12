using System;

namespace Assets._Project.Develop.Runtime.Utilies.Conditions
{
    public class FuncCondition : ICondition
    {
        private Func<bool> _condition;

        public FuncCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        #region Interface

        public bool Evaluate() => _condition.Invoke();

        #endregion
    }
}
