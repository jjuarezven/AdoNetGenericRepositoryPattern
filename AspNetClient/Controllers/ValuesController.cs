using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections.Generic;

namespace AspNetClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public ValuesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Invoice>> Get()
        {
            return Ok(_invoiceService.GetAll());
        }
    }
}
