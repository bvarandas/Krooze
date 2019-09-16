using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Krooze.EntranceTest.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        
        protected new IActionResult Response(object result = null)
        {
            //if (IsValidOperation())
            //{
                return Ok(new
                {
                    success = true,
                    data = result
                });
            //}

            return BadRequest(new
            {
                success = false,
                //errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }
    }
}
