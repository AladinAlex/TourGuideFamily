using Microsoft.AspNetCore.Mvc;
using TourGuideFamily.Bll.Services;
using TourGuideFamily.Bll.Services.Interfaces;
using TourGuideFamily.WebApi.Models;

namespace TourGuideFamily.WebApi.Controllers;

[ApiController]
[Route("api/{controller}")]
public class MainController
{
    readonly IGetTourService _getTourService;

    public MainController(IGetTourService getTourService)
    {
        _getTourService = getTourService;
    }

    [HttpGet("Main")]
    public async Task<IActionResult> Main(CancellationToken token)
    {
        try
        {
            return new JsonResult(await _getTourService.Main(token));
        }
        catch (Exception ex)
        {
            return new JsonResult(new ErrorResponse
            {
                Error = ex.Message
            });
        }
    }

    [HttpGet("Tour/{tourId}")]
    public async Task<IActionResult> Tour(long tourId, CancellationToken token)
    {
        try
        {
            return new JsonResult(await _getTourService.Tour(tourId, token));
        }
        catch (Exception ex)
        {
            return new JsonResult(new ErrorResponse
            {
                Error = ex.Message
            });
        }
    }
}