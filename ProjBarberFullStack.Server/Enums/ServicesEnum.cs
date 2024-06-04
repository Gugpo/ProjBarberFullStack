using System.Text.Json.Serialization;

namespace ProjBarberFullStack.Server.Enums
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum ServicesEnum
	{
		Haircut,
		Beard
	}
}
