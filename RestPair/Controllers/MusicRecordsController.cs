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
    public ActionResult<List<MusicRecord>> GetAllMusicRecords([FromQuery] string? filter)
    {
        return Ok(_musicRecordsRepo.GetAllMusicRecords(filter));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<MusicRecord> AddMusicRecord([FromBody] MusicRecord record)
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

}
