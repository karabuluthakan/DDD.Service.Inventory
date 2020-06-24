using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [
        ApiController,
        Route("api/[controller]"),
        Produces(MediaTypeNames.Application.Json)
    ]
    public class VirtualStocksController : ControllerBase
    {
    }
}