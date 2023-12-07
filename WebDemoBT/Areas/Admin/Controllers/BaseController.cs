using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
namespace WebDemoBT.Areas.Admin.Controllers
{
	public class BaseController : Controller
	{
		protected void SetAlert(string msg, string type)
		{
			TempData["AlertMessage"] = msg;
			if (type == "success")
			{
				TempData["type"] = "alert-success";
			}
			if (type == "warning")
			{
				TempData["type"] = "alert-warning";
			}
			if (type == "error")
			{
				TempData["type"] = "alert-error";
			}
		}
	}
}
