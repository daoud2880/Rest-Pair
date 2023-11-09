using Microsoft.AspNetCore.Mvc;

namespace RestPair.Controllers;

[ApiController]
[Route("[controller]")]
public class MusicRecordsController : ControllerBase
{
    private readonly MusicRecordsRepo _musicRecordsRepo;

    public MusicRecordsController(MusicRecordsRepo musicRecordsRepo)
    {
        _musicRecordsRepo = musicRecordsRepo;
    }

    [HttpGet]
    [Route("GetAllMusicRecords")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<MusicRecord>> GetAllMusicRecords()
    {
        return Ok(_musicRecordsRepo.GetAllMusicRecords());
    }

}
