using System;
using System.Threading.Tasks;
using Identifiers.AspNetCore.ModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Primitives;
using Moq;
using Xunit;

namespace Identifiers.AspNetCore.Tests.ModelBinders
{
    public class IdentifierModelBinderTests
    {
        [Fact]
        public async Task WhenModelBindingContextIsNull_ItShouldThrowArgumentNullException()
        {
            // Arrange
            var modelBinder = new IdentifierModelBinder<int>();

            // Act
            Task Act() => modelBinder.BindModelAsync(null);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public void WhenModelValueForModelNameIsNotFound_ItShouldReturnCompletedTask()
        {
            // Arrange
            var bindingContext = new Mock<ModelBindingContext>();

            bindingContext.Setup(x => x.ModelName)
                .Returns("id");
            bindingContext.Setup(x => x.ValueProvider.GetValue("id"))
                .Returns(ValueProviderResult.None);

            var modelBinder = new IdentifierModelBinder<int>();

            // Act    
            var task = modelBinder.BindModelAsync(bindingContext.Object);

            // Assert
            Assert.Same(Task.CompletedTask, task);
        }

        [Fact]
        public void WhenModelValueForModelNameIsNotNull_ItShouldReturnCompletedTaskAndSucceeded()
        {
            // Arrange
            var modelName = "id";
            var valueProviderResult = new ValueProviderResult(new StringValues("10"));

            var compositeMetadataDetailsProvider = new Mock<ICompositeMetadataDetailsProvider>();


            var data = new DefaultModelMetadataProvider(compositeMetadataDetailsProvider.Object);
            var modelMetadata = data.GetMetadataForType(typeof(Identifier));

            var valueProvider = new Mock<IValueProvider>();
            valueProvider.Setup(x => x.GetValue(modelName))
                .Returns(valueProviderResult);

            var bindingContext = new DefaultModelBindingContext
            {
                ModelName = modelName,
                ModelState = new ModelStateDictionary(),
                ValueProvider = valueProvider.Object,
                ModelMetadata = modelMetadata
            };

            var modelBinder = new IdentifierModelBinder<int>();

            // Act    
            var task = modelBinder.BindModelAsync(bindingContext);

            // Assert
            Assert.Same(Task.CompletedTask, task);
            Assert.True(bindingContext.Result.IsModelSet);
            Assert.NotNull(bindingContext.Result.Model);
            Assert.Equal("Success '10'", bindingContext.Result.ToString());
        }

        [Fact]
        public void WhenModelValueForModelNameIsNull_ItShouldReturnCompletedTask()
        {
            // Arrange
            var modelName = "id";
            var valueProviderResult = new ValueProviderResult(new StringValues(""));

            var compositeMetadataDetailsProvider = new Mock<ICompositeMetadataDetailsProvider>();


            var data = new DefaultModelMetadataProvider(compositeMetadataDetailsProvider.Object);
            var modelMetadata = data.GetMetadataForType(typeof(Identifier));

            var valueProvider = new Mock<IValueProvider>();
            valueProvider.Setup(x => x.GetValue(modelName))
                .Returns(valueProviderResult);

            var bindingContext = new DefaultModelBindingContext
            {
                ModelName = modelName,
                ModelState = new ModelStateDictionary(),
                ValueProvider = valueProvider.Object,
                ModelMetadata = modelMetadata
            };

            var modelBinder = new IdentifierModelBinder<int>();

            // Act    
            var task = modelBinder.BindModelAsync(bindingContext);

            // Assert
            Assert.Same(Task.CompletedTask, task);
            Assert.False(bindingContext.Result.IsModelSet);
            Assert.Null(bindingContext.Result.Model);
            Assert.Equal("Failed", bindingContext.Result.ToString());
        }

        [Fact]
        public void WhenModelValueForModelNameThrowsAnException_ItShouldReturnCompletedTask()
        {
            // Arrange
            var modelName = "id";
            var valueProviderResult = new ValueProviderResult(new StringValues("abc"));

            var compositeMetadataDetailsProvider = new Mock<ICompositeMetadataDetailsProvider>();


            var data = new DefaultModelMetadataProvider(compositeMetadataDetailsProvider.Object);
            var modelMetadata = data.GetMetadataForType(typeof(Identifier));

            var valueProvider = new Mock<IValueProvider>();
            valueProvider.Setup(x => x.GetValue(modelName))
                .Returns(valueProviderResult);

            var bindingContext = new DefaultModelBindingContext
            {
                ModelName = modelName,
                ModelState = new ModelStateDictionary(),
                ValueProvider = valueProvider.Object,
                ModelMetadata = modelMetadata
            };

            var modelBinder = new IdentifierModelBinder<int>();

            // Act    
            var task = modelBinder.BindModelAsync(bindingContext);

            // Assert
            Assert.Same(Task.CompletedTask, task);
            Assert.False(bindingContext.Result.IsModelSet);
            Assert.Null(bindingContext.Result.Model);
            Assert.Equal("Failed", bindingContext.Result.ToString());
        }
    }
}
