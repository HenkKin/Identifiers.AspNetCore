using System;
using Identifiers.AspNetCore.ModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Moq;
using Xunit;

namespace Identifiers.AspNetCore.Tests.ModelBinders
{
    public class IdentifierModelBinderProviderTests
    {
        [Fact]
        public void WhenModelBinderProviderContextIsNull_ItShouldThrowArgumentNullException()
        {
            // Arrange
            var modelBinderProvider = new IdentifierModelBinderProvider<int>();

            // Act
            IModelBinder Act() => modelBinderProvider.GetBinder(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Act);
        }

        [Fact]
        public void WhenModelTypeIsOfTypeIdentifier_ItShouldReturnBinderTypeModelBinder()
        {
            // Arrange
            var modelBinderProvider = new IdentifierModelBinderProvider<int>();
            var modelBinderProviderContext = new Mock<ModelBinderProviderContext>();

            // modelBinderProviderContext.Metadata.ModelType
            var compositeMetadataDetailsProvider = new Mock<ICompositeMetadataDetailsProvider>();


            var data = new DefaultModelMetadataProvider(compositeMetadataDetailsProvider.Object);
            var modelMetadata = data.GetMetadataForType(typeof(Identifier));

            modelBinderProviderContext.Setup(x => x.Metadata)
                .Returns(modelMetadata);

            // Act    
            var modelBinder = modelBinderProvider.GetBinder(modelBinderProviderContext.Object);

            // Assert
            Assert.NotNull(modelBinder);
        }

        [Fact]
        public void WhenModelTypeIsOfTypeNullableIdentifier_ItShouldReturnBinderTypeModelBinder()
        {
            // Arrange
            var modelBinderProvider = new IdentifierModelBinderProvider<int>();
            var modelBinderProviderContext = new Mock<ModelBinderProviderContext>();

            // modelBinderProviderContext.Metadata.ModelType
            var compositeMetadataDetailsProvider = new Mock<ICompositeMetadataDetailsProvider>();


            var data = new DefaultModelMetadataProvider(compositeMetadataDetailsProvider.Object);
            var modelMetadata = data.GetMetadataForType(typeof(Identifier?));

            modelBinderProviderContext.Setup(x => x.Metadata)
                .Returns(modelMetadata);

            // Act    
            var modelBinder = modelBinderProvider.GetBinder(modelBinderProviderContext.Object);

            // Assert
            Assert.NotNull(modelBinder);
        }


        [Fact]
        public void WhenModelTypeIsOfTypeUnknown_ItShouldReturnNull()
        {
            // Arrange
            var modelBinderProvider = new IdentifierModelBinderProvider<int>();
            var modelBinderProviderContext = new Mock<ModelBinderProviderContext>();

            // modelBinderProviderContext.Metadata.ModelType
            var compositeMetadataDetailsProvider = new Mock<ICompositeMetadataDetailsProvider>();


            var data = new DefaultModelMetadataProvider(compositeMetadataDetailsProvider.Object);
            var modelMetadata = data.GetMetadataForType(typeof(DateTime));

            modelBinderProviderContext.Setup(x => x.Metadata)
                .Returns(modelMetadata);

            // Act    
            var modelBinder = modelBinderProvider.GetBinder(modelBinderProviderContext.Object);

            // Assert
            Assert.Null(modelBinder);
        }
    }
}