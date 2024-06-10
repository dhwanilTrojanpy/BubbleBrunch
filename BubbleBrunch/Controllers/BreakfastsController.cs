using BubbleBrunch.Contracts.Breakfasts;
using BubbleBrunch.Models;
using Microsoft.AspNetCore.Mvc;

namespace BubbleBrunch.Controllers;

[ApiController]
[Route("breakfasts")] // all routes will be prefixed with /breakfasts 

// [Route("[controller]")] // all routes wiil be prefixed with the name of the controller, i.e. BreakfastsController for this controller.
public class  BreakfastsController : ControllerBase
{
    private readonly IbreakfastServices _breakfastServices;

    public BreakfastsController(IbreakfastServices breakfastServices){
        _breakfastServices = breakfastServices;
    }


    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {   
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.Now,
            request.Savory,
            request.Sweet
        );

        _breakfastServices.CreateBreakfast(breakfast);

        var response = new BreakfastResponse( 
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );

        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id },
            value: response
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        var breakfast = _breakfastServices.GetBreakfast(id);

        var Response =  new BreakfastResponse( 
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        ); 
        return Ok(Response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.Now,
            request.Savory,
            request.Sweet
        );

        _breakfastServices.UpsertBreakfast(breakfast);

       return NoContent();
    }

   

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        _breakfastServices.DeleteBreakfast(id);
        return NoContent();
    }
}   