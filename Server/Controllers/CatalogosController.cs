using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBlazor.Server.Data;
using PizzaBlazor.Shared.Model;

namespace PizzaBlazor.Server.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]
	[ApiController]
	public class CatalogosController : ControllerBase
	{
		private readonly AplicationDbContext context;

		public CatalogosController(AplicationDbContext context)//le estamos insertando el puente
        {
			this.context = context;
		}
        [HttpGet]//cuando solo sea uno se puede dejar sin nombre 
		public async Task<List<Tamanos>>Tamanos()

		{
			List<Tamanos> tamanos = new List<Tamanos>();

			tamanos = await context.Tamanos.ToListAsync();

			//tamanos = new List<Tamanos>()
			//{
			//	new Tamanos{Id = 1, Tamano="Personal", Precio=10.0f },
			//	new Tamanos{Id = 2, Tamano="Chica", Precio=20.0f },
			//	new Tamanos{Id = 3, Tamano="Mediana", Precio=30.0f },
			//	new Tamanos{Id = 4, Tamano="Grande", Precio=40.0f },
			//};
			return tamanos;
			//return NotFound();
			//return NoContent();
		}
		
		[HttpGet("tipomasa")]//si se tiene mas de uno es mejor ponerle un nombre si es 
		//diferente el http pueden no tener nombre, si ya hay mas de uno entonces si
		public async Task<List<TipoMasa>>Masas()
		{
			List<TipoMasa> tipos = new List<TipoMasa>();
			tipos = await context.TipoMasa.ToListAsync();

			/*tipos = new List<TipoMasa>()
			//{
			//	new TipoMasa{Id = 1, Tipo="Tradicional", Precio=20.0f },
			//	new TipoMasa{Id = 2, Tipo="Orilla rellena de queso", Precio=25.0f },
			//	new TipoMasa{Id = 3, Tipo="Crunch", Precio=37.0f },
			//	new TipoMasa{Id = 4, Tipo="Sarten", Precio=42.0f },

			};*/
			return tipos;
		
		}
		[HttpGet("ingrediente")]
		public async Task<List<Ingrediente>>Ingredientes()
		{
			List<Ingrediente> ingredientes = new List<Ingrediente>();
			ingredientes = await context.Ingredientes.ToListAsync();
			/*//ingredientes = new List<Ingrediente>()
			//{
			//	new Ingrediente{Id = 1, Nombre="Piña", Precio=10.0f },
			//	new Ingrediente{Id = 2, Nombre="Japon", Precio=15.0f },
			//	new Ingrediente{Id = 3, Nombre="Peperoni", Precio=7.0f },
			//	new Ingrediente{Id = 4, Nombre="Hongos", Precio=23.0f },
			//	new Ingrediente{Id = 5, Nombre="Pastor", Precio=20.0f },

			//};*/
			return ingredientes;
		
		}
		[HttpPost("newingrediente")]
		public async Task<int> NuevoIngrediente(Ingrediente newingrediente)
		{
			context.Add(newingrediente);
			await context.SaveChangesAsync();
			return newingrediente.Id;
		}
	}
}
