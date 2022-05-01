using Microsoft.AspNetCore.Mvc;

namespace Reports.WebApi.Controllers.Base
{
	public abstract class ApiController : ControllerBase
	{
		protected ActionResult ResponseAsAccept()
			=> Accepted();
		protected ActionResult<T> ResponsePost<T>(string action, object route, T result)
		{
			if (result == null)
				return NoContent();

			return CreatedAtAction(action, route, result);
		}
	}
}
