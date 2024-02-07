using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // Get All Activities
        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        //Get Single Activity
        [HttpGet("{id}")] // api/activities/idofitem
        public async Task<ActionResult<Activity>> GetActivity(Guid id) {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        //Create new Activity
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            await Mediator.Send(new Create.Command { Activity = activity });

            return Ok();
        }

        //Edit Single Activity
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid Id, Activity activity)
        {
            activity.Id = Id;
            await Mediator.Send(new Edit.Command{Activity = activity});
            return Ok();
        }

        //Delete Single Activity
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await Mediator.Send(new Delete.Command{Id = id});

            return Ok();
        }
    }
}