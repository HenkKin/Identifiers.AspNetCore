using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Identifiers.AspNetCore.ModelBinders
{
    public class IdentifierModelBinderProvider<TDatabaseClrType> : IModelBinderProvider where TDatabaseClrType : IConvertible
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Identifier))
            {
                return new BinderTypeModelBinder(typeof(IdentifierModelBinder<TDatabaseClrType>));
            }

            if (context.Metadata.ModelType == typeof(Identifier?))
            {
                return new BinderTypeModelBinder(typeof(IdentifierModelBinder<TDatabaseClrType>));
            }

            return null;
        }
    }
}