using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TourGuideFamily.Bll.Models;
using TourGuideFamily.Bll.Services.Interfaces;
using TourGuideFamily.Domain.Models;
using TourGuideFamily.WebApi.Models;

namespace TourGuideFamily.WebApi.Controllers;

[ApiController]
[Route("api/{controller}")]
public class CreateController
{
    readonly ICreateService _createService;
    public CreateController(ICreateService createService)
    {
        _createService = createService;
    }

    [HttpPost("Guide")]
    public async Task<IActionResult> Guide(CreateGuideModel model, CancellationToken token)
    {
        try
        {
            return new JsonResult(await _createService.Guide(model, token));
        }
        catch (Exception ex)
        {
            return new JsonResult(new ErrorResponse
            {
                Error = ex.Message
            });
        }
    }

    [HttpPost("Promo")]
    public async Task<IActionResult> Promo(CreatePromoModel model, CancellationToken token)
    {
        try
        {
            return new JsonResult(await _createService.Promo(model, token));
        }
        catch (Exception ex)
        {
            return new JsonResult(new ErrorResponse
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

    [HttpPost("Tour")]
    public async Task<IActionResult> Tour(CreateTourModel model, CancellationToken token)
    {
        try
        {
            return new JsonResult(await _createService.Tour(model, token));
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