using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Threading.Tasks;

namespace ClientesAPI.Heplers
{
    public class TypeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bidingContext) 
        {
            var nombrePropiedad = BindingMetadataProviderContext.ModelName;
            var proveedorDeValores = ModelBindingContext.ValueProvider.GetValue(nombrePropiedad);

            if (proveedorDeValores == ValuesProviderResult.None)
        }
    }
}
