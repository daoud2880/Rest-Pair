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
    public ActionResult<List<MusicRecord>> GetAllMusicRecords()
    {
        return Ok(_musicRecordsRepo.GetAllMusicRecords());
    }

}
