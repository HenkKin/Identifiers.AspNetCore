using System;
using Identifiers.TypeConverters;
using Newtonsoft.Json;

namespace Identifiers.AspNetCore.JsonConverters
{
    public class IdentifierJsonConverter<TDatabaseClrType> : JsonConverter where TDatabaseClrType : IConvertible
    {
        public override bool CanConvert(Type typeToConvert)
            => typeToConvert == typeof(Identifier) || typeToConvert == typeof(Identifier?);

        public override object ReadJson(JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            object target;
            if (IsNullable(objectType) && reader.Value == null)
            {
                target = null;
            }
            else
            {
                if (reader.Value != null)
                {
                    target = new Identifier(serializer.Deserialize<TDatabaseClrType>(reader));
                }
                else
                {
                    target = new Identifier();
                }

            }
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is Identifier identifier))
                throw new JsonSerializationException("Expected Identifier object value.");

            // custom response 
            writer.WriteValue(IdentifierTypeConverter.FromIdentifier<TDatabaseClrType>(identifier));
        }

        private bool IsNullable(Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }
    }
}
