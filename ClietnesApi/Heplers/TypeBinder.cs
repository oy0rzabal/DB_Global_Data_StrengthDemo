using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ClientesAPI.Heplers
{
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bidingContext) 
        {
            var nombrePropiedad = bidingContext.ModelName;
            var proveedorDeValores = bidingContext.ValueProvider.GetValue(nombrePropiedad);

            if (proveedorDeValores == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            try
            {
                var valorDeserializado = JsonConvert.DeserializeObject<List<T>>(proveedorDeValores.FirstValue);
                bidingContext.Result = ModelBindingResult.Success(valorDeserializado);
            }

            catch
            {
                bidingContext.ModelState.TryAddModelError(nombrePropiedad, "valor invalido para tipo List<int>");
            }

            return Task.CompletedTask;
        }
    }
}
