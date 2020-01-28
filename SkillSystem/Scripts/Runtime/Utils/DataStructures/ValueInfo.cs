using System;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    public abstract class AValueInfo
    {
        public object GetValue()
        {
            return ObjValue;
        }

        public void SetValue(AValueInfo value)
        {
            UpdateValue(value);
        }

        protected abstract void UpdateValue(AValueInfo value);
        
        public abstract void SetValueO(object vlaue);
        
        protected abstract object ObjValue { get; }

        public abstract Type ValueType { get; }
    }
    
    [Serializable]
    public class ValueInfo<T>:AValueInfo
    {
        public T Value;
        
        public static implicit operator T(ValueInfo<T> valueInfo)
        {
            return valueInfo.Value;
        }

        public static implicit operator ValueInfo<T>(T value)
        {
            return new ValueInfo<T>(){Value = value};
        }

        protected override void UpdateValue(AValueInfo value)
        {
            Value = ((ValueInfo<T>) value).Value;
        }

        public override void SetValueO(object vlaue)
        {
            Value = (T) vlaue;
        }

        protected override object ObjValue => Value;
        
        public override Type ValueType => Value?.GetType();

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}