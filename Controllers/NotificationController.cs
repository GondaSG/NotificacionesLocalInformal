using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Entity;
using NotificationService.Services.Imp;
using NotificationService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : Controller
    {
        public NotificationImpService _notificationImpService;

        public NotificationController()
        {

        }
        [HttpGet]
        public ResponseEntity NotificationEmail()
        {
            try
            {
                _notificationImpService = new NotificationService.Services.NotificationService();
                string valor = _notificationImpService.Create();
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }
        [HttpGet("GetEmailForRegion/{sRegion}")]
        public IActionResult GetEmailForRegion(string sRegion)
        {
            try
            {
                _notificationImpService = new NotificationService.Services.NotificationService();
                List<ExcelEntity> excels = _notificationImpService.GetEmailForRegion(sRegion);
                return Ok(excels);
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
    }
}