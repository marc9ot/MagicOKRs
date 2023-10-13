//this is the controller for keyresults that will be used to create, update, get and delete keyresults from KeyResult.cs
using Microsoft.AspNetCore.Mvc;
namespace MagicOKRs.Controllers;

[ApiController]
[Route("[controller]")]

public class KeyResultsController : ControllerBase
{
    //new get to fetch keyresults from the model KeyResult.cs and return them as a list  of keyresults
    [HttpGet]
    public IEnumerable<KeyResult> Get()
    {
        return KeyResults;
    }

    //new get method to fetch a specific keyresult from the model KeyResult.cs by KeyResultId
    //if keyresult cannot be found return not found error
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var keyresult = KeyResults.FirstOrDefault(o => o.KeyResultId == id);
        if (keyresult == null)
        {
            return NotFound("Key Result was not found");
        }
        return Ok(keyresult);
    }

    //new get method to fetch a specific keyresult from the model KeyResult.cs by ObjectiveId
    //if keyresult cannot be found return not found error
    [HttpGet("objective/{id}")]
    public IActionResult GetByObjectiveId(Guid id)
    {
        var keyresults = new List<KeyResult>();
        foreach (var keyres in KeyResults)
        {
            if (keyres.ObjectiveId == id)
            {
                keyresults.Add(keyres);
            }
        }
        if (keyresults == null)
        {
            return NotFound("Key Results were not found");
        }
        return Ok(keyresults);
    }

    //new post to add keyresults to the model KeyResult.cs and return the added keyresult
    //validate if the keyresult format is matched in case of an error return http statuscode 400
    [HttpPost]
    public IActionResult Post(KeyResult keyresult)
    {
        foreach (var keyres in KeyResults)
        {
            if (keyresult.KeyResultId == keyres.KeyResultId)
            {
                return BadRequest("Key Result already exists");
            }
        }
        KeyResults.Add(keyresult);
        return Ok(keyresult);
    }

    //new put method to update a specific keyresult from the model KeyResult.cs by KeyResultId
    //if keyresult cannot be found return not found error
    [HttpPut]
    public IActionResult Put(KeyResult keyresult)
    {
        var existingKeyResult = KeyResults.FirstOrDefault(o => o.KeyResultId == keyresult.KeyResultId);
        if (existingKeyResult == null)
        {
            return NotFound("Could not find the Key Result");
        }
        existingKeyResult.KeyResultTitle = keyresult.KeyResultTitle;
        existingKeyResult.KeyResultStatement = keyresult.KeyResultStatement;
        existingKeyResult.KeyResultDescription = keyresult.KeyResultDescription;
        existingKeyResult.KeyResultCategorie = keyresult.KeyResultCategorie;
        existingKeyResult.KeyResultOwnerId = keyresult.KeyResultOwnerId;
        return Ok(existingKeyResult);
    }

    //new delete method to delete a specific keyresult from the model KeyResult.cs by KeyResultId
    //if keyresult cannot be found return not found error
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var keyresult = KeyResults.FirstOrDefault(o => o.KeyResultId == id);
        if (keyresult == null)
        {
            return NotFound("Could not find the keyresult");
        }
        KeyResults.Remove(keyresult);
        return Ok();
    }

    //new delete method to delete all keyresults from the model KeyResult.cs by ObjectiveId
    //if keyresults cannot be found return not found error
    [HttpDelete("objective/{id}")]
    public IActionResult DeleteByObjectiveId(Guid id)
    {
        foreach (var keyresult in KeyResults)
        {
            if (keyresult.ObjectiveId == id)
            {
                KeyResults.Remove(keyresult);
            }
        }
        return Ok();
    }

    //this is a in memory list of keyresults that will be returned when the controller is called
    private static readonly List<KeyResult> KeyResults = new()
    {
        new KeyResult
        {
            KeyResultId = Guid.NewGuid(),
            ObjectiveId = Guid.NewGuid(),
            KeyResultTitle = "KeyResultTitle",
            KeyResultStatement = "KeyResultStatement",
            KeyResultDescription = "KeyResultDescription",
            KeyResultCategorie = "KeyResultCategorie",
            KeyResultOwnerId = "KeyResultOwnerId"
        },
        new KeyResult
        {
            KeyResultId = Guid.NewGuid(),
            ObjectiveId = Guid.NewGuid(),
            KeyResultTitle = "KeyResultTitle2",
            KeyResultStatement = "KeyResultStatement2",
            KeyResultDescription = "KeyResultDescription2",
            KeyResultCategorie = "KeyResultCategorie2",
            KeyResultOwnerId = "KeyResultOwnerId2"
        }
    };
}