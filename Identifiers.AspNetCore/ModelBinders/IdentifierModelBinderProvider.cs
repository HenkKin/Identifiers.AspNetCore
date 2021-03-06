﻿using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Identifiers.AspNetCore.ModelBinders
{
    internal class IdentifierModelBinderProvider<TInternalClrType> : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Identifier))
            {
                return new BinderTypeModelBinder(typeof(IdentifierModelBinder<TInternalClrType>));
            }

            if (context.Metadata.ModelType == typeof(Identifier?))
            {
                return new BinderTypeModelBinder(typeof(IdentifierModelBinder<TInternalClrType>));
            }

            return null;
        }
    }
}