﻿namespace ProjBarberFullStack.Server.Models
{
	public class ServiceResponseModel<T>
	{
		public T? Data { get; set; }
		public bool Success { get; set; } = true;
		public string Message { get; set; } = string.Empty;
	}
}
