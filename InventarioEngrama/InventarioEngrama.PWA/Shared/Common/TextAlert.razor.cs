﻿using Microsoft.AspNetCore.Components;

using MudBlazor;

using System.Reflection.Metadata;

namespace InventarioEngrama.PWA.Shared.Common
{
	public partial class TextAlert
	{
		[Parameter] public string Mensaje { get; set; }
		[Parameter] public Severity Tipo { get; set; }
	}
}
