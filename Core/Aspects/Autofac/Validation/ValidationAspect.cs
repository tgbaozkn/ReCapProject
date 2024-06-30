using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect :MethodInterception
    {
        private Type _type;
        public ValidationAspect(Type type)
        {
            if(!typeof(IValidator).IsAssignableFrom(type))
            {
                throw new Exception("Hatalı doğrulama tipi");
            }
                _type = type;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_type);
            var entityType = _type.BaseType.GetGenericArguments()[0];   
            var entities = invocation.Arguments.Where(t=>t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
