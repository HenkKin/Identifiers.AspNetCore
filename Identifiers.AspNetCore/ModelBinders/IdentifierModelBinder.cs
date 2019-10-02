using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Identifiers.AspNetCore.ModelBinders
{
    internal class IdentifierModelBinder<TInternalClrType> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            var valueProviderResult =
                bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName,
                valueProviderResult);

            try
            {
                var value = valueProviderResult.FirstValue;
                object model;
                if (string.IsNullOrWhiteSpace(value))
                {
                    //empty fields, means null model
                    model = null;
                }
                else
                {
                    //model = IdentifierTypeConverter.ToIdentifier<TInternalClrType>(value);
                    model = new Identifier(Convert.ChangeType(value, typeof(TInternalClrType)));
                }
                //if model is null and type is not nullable
                //return a required field error
                if (model == null &&
                    !bindingContext.ModelMetadata
                        .IsReferenceOrNullableType)
                {
                    bindingContext.ModelState.TryAddModelError(
                        bindingContext.ModelName,
                        bindingContext.ModelMetadata
                        .ModelBindingMessageProvider.ValueMustNotBeNullAccessor(
                            valueProviderResult.ToString()));

                    return Task.CompletedTask;
                }
                else
                {
                    bindingContext.Result = ModelBindingResult.Success(model);
                    return Task.CompletedTask;
                }
            }
            catch (Exception exception)
            {
                //in case parsers throw a FormatException
                //add error to the model state.

                bindingContext.ModelState.TryAddModelError(
                    bindingContext.ModelName,
                    exception,
                    bindingContext.ModelMetadata);


                return Task.CompletedTask;
            }
        }
    }
}
