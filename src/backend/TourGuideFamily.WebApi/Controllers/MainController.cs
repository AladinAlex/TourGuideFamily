using Microsoft.AspNetCore.Mvc;
using TourGuideFamily.Bll.Models;
using TourGuideFamily.Bll.Services.Interfaces;
using TourGuideFamily.WebApi.Models;

namespace TourGuideFamily.WebApi.Controllers;

[ApiController]
[Route("api/{controller}")]
public class MainController
{
    readonly IGetTourService _getTourService;
    readonly ICreateService _createService;

    public MainController(IGetTourService getTourService, ICreateService createService)
    {
        _getTourService = getTourService;
        _createService = createService;
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

    [HttpGet("Tour/{slug}")]
    public async Task<IResult> Tour(string slug, CancellationToken token)
    {
        try
        {
            return Results.Ok(await _getTourService.Tour(slug, token));
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new ErrorResponse
            {
                Error = ex.Message
            });
        }
    }

    [HttpPost("Feedback")]
    public async Task<IActionResult> Feedback(CreateFeedbackModel model, CancellationToken token)
    {
        try
        {
            return new JsonResult(await _createService.Feedback(model, token));
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