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

}
