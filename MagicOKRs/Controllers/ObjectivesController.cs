using MagicOKRs.Queries;
using Microsoft.AspNetCore.Mvc;
namespace MagicOKRs.Controllers;

[ApiController]
[Route("[controller]")]
public class ObjectivesController : ControllerBase
{
    //new get to fetch objectives from the model Objective.cs and return them as a list  of objectives
    [HttpGet]
    public IEnumerable<Objective> Get()
    {   
        Objectives = ObjectiveQueries.GetObjectives();
        return Objectives;
    }

    //new post to add objectives to the model Objective.cs and return the added objective
    //validate if the objective format is matched in case of an error return http statuscode 400
    [HttpPost] 
    public IActionResult Post(Objective objective)
    {
    foreach (var obj in Objectives){
        if (objective.ObjectiveId == obj.ObjectiveId){
            return BadRequest("Guid already exists");
        }
    }
        Objectives.Add(objective);
        return Ok(objective);
    }
    //new get method to fetch a specific objective from the model Objective.cs by ObjectiveId
    //if objective cannot be found return an error

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var objective = Objectives.FirstOrDefault(o => o.ObjectiveId == id);
        if (objective == null)
        {
            return NotFound();
        }
        return Ok(objective);
    }

    //new put method to update a specific objective from the model Objective.cs by ObjectiveId
    //if objective cannot be found return an error
    [HttpPut]
    public IActionResult Put(Objective objective)
    {
        var existingObjective = Objectives.FirstOrDefault(o => o.ObjectiveId == objective.ObjectiveId);
        if (existingObjective == null)
        {
            return NotFound();
        }
        existingObjective.ObjectiveTitle = objective.ObjectiveTitle;
        existingObjective.ObjectiveStatement = objective.ObjectiveStatement;
        existingObjective.ObjectiveDescription = objective.ObjectiveDescription;
        existingObjective.ObjectiveCategorie = objective.ObjectiveCategorie;
        existingObjective.ObjectiveOwnerId = objective.ObjectiveOwnerId;
        existingObjective.ObjectiveDuration = objective.ObjectiveDuration;
        return Ok(existingObjective);
    }

    //new delete method to delete a specific objective from the model Objective.cs by ObjectiveId
    //if objective cannot be found return an error
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var objective = Objectives.FirstOrDefault(o => o.ObjectiveId == id);
        if (objective == null)
        {
            return NotFound();
        }
        Objectives.Remove(objective);
        return Ok();
    }

    //this is a in memory list of objectives that will be returned when the controller is called 
    public static List<Objective> Objectives = new List<Objective>
    {
        new Objective
        {
            ObjectiveId = new Guid("5dacb0ee-41ba-4d59-bcb8-4ef6e66e34a8"),
            CreationDate = new DateOnly(2021, 10, 10),
            ObjectiveTitle = "Objective 1",
            ObjectiveStatement = "Objective Statement 1",
            ObjectiveDescription = "Objective Description 1",
            ObjectiveCategorie = "Objective Categorie 1",
            ObjectiveOwnerId = "Objective Owner Id 1",
            ObjectiveDuration = "Objective Duration 1"
        },
        new Objective
        {
            ObjectiveId = new Guid("1dcca0ee-41ba-4d39-bcb8-4ef6e66e84a9"),
            CreationDate = new DateOnly(2021, 10, 10),
            ObjectiveTitle = "Objective 2",
            ObjectiveStatement = "Objective Statement 2",
            ObjectiveDescription = "Objective Description 2",
            ObjectiveCategorie = "Objective Categorie 2",
            ObjectiveOwnerId = "Objective Owner Id 2",
            ObjectiveDuration = "Objective Duration 2"
        }
    };
}
