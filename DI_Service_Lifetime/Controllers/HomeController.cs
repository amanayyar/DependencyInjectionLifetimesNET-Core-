using DI_Service_Lifetime.Models;
using DI_Service_Lifetime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DI_Service_Lifetime.Controllers
{
	public class HomeController : Controller
	{
		//Dependency Injection Lifetimes in .NET Core
		
		// Transient New Service - every time requested
		// Scoped New Service - once per request
		// Singleton New Service - once per application lifetime

		private readonly IScopedGuidService _scoped1;
		private readonly IScopedGuidService _scoped2;
		private readonly IScopedGuidService _scoped3;

		private readonly ISingletonGuidService _singleton1;
		private readonly ISingletonGuidService _singleton2;
		private readonly ISingletonGuidService _singleton3;

		private readonly ITransientGuidService _transient1;
		private readonly ITransientGuidService _transient2;
		private readonly ITransientGuidService _transient3;

		public HomeController(
			IScopedGuidService scoped1, IScopedGuidService scoped2, IScopedGuidService scoped3,
			ISingletonGuidService singleton1, ISingletonGuidService singleton2, ISingletonGuidService singleton3,
			ITransientGuidService transient1, ITransientGuidService transient2, ITransientGuidService transient3
			)
		{
			_scoped1 = scoped1;
			_scoped2 = scoped2;
			_scoped3 = scoped3;
			_singleton1 = singleton1;
			_singleton2 = singleton2;
			_singleton3 = singleton3;
			_transient1 = transient1;
			_transient2 = transient2;
			_transient3 = transient3;
		}

		public IActionResult Index()
		{
			StringBuilder messages = new StringBuilder();
			messages.Append($"Transient 1 : {_transient1.GetGuid()}\n");
			messages.Append($"Transient 2 : {_transient2.GetGuid()}\n");
			messages.Append($"Transient 3 : {_transient3.GetGuid()}\n\n\n");

			messages.Append($"Scoped 2 : {_scoped1.GetGuid()}\n");
			messages.Append($"Scoped 2 : {_scoped2.GetGuid()}\n");
			messages.Append($"Scoped 3 : {_scoped3.GetGuid()}\n\n\n");
			
			messages.Append($"Singleton 1 : {_singleton1.GetGuid()}\n");
			messages.Append($"Singleton 2 : {_singleton2.GetGuid()}\n");
			messages.Append($"Singleton 3 : {_singleton3.GetGuid()}\n\n\n");

			return Ok(messages.ToString());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}