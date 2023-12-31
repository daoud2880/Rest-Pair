using Microsoft.AspNetCore.Mvc;

namespace RestPair.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MusicRecordsController : ControllerBase
{
    private readonly MusicRecordsRepo _musicRecordsRepo;

    public MusicRecordsController(MusicRecordsRepo musicRecordsRepo)
    {
        _musicRecordsRepo = musicRecordsRepo;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<MusicRecord?>> GetAllMusicRecords([FromQuery] string? filter)
    {
        return Ok(_musicRecordsRepo.GetAllMusicRecords(filter));
    }

    [HttpGet("recordName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<MusicRecord?>> GetFromRecord([FromQuery] string? recordName)
    {
        return Ok(_musicRecordsRepo.GetFromRecord(recordName));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<MusicRecord?> AddMusicRecord([FromBody] MusicRecord record)
    {
        try
        {
            MusicRecord addedRecord = _musicRecordsRepo.Add(record);
            return Created("/" + record.Title, addedRecord);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<MusicRecord?> DeleteMusicRecord(string title)
    {
        try
        {
            MusicRecord? deleted = _musicRecordsRepo.Delete(title);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{title}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<MusicRecord?> Put(string title, [FromBody] MusicRecord record)
    {
        try
        {
            MusicRecord? updated = _musicRecordsRepo.Update(title, record);

            if (updated != null)
            {
                return Ok(updated);
            }

            return NotFound();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
