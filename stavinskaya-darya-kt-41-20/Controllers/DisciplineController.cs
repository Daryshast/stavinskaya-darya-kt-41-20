using Microsoft.AspNetCore.Mvc;
using stavinskaya_darya_kt_41_20.Data;
using stavinskaya_darya_kt_41_20.Filters.DisciplineFilter;
using stavinskaya_darya_kt_41_20.Interfaces.DisciplineInterfaces;

namespace stavinskaya_darya_kt_41_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplineController : ControllerBase
    {
        private readonly ILogger<DisciplineController> _logger;
        private readonly IDisciplineServices _disciplineService;
        private DisciplineDbContext _context;

        public DisciplineController(ILogger<DisciplineController> logger, IDisciplineServices gradeService, DisciplineDbContext context)
        {
            _logger = logger;
            _disciplineService = gradeService;
            _context = context;
        }


        [HttpPost("GetListOfDisciplines", Name = "GetListOfDisciplines")]
        public async Task<IActionResult> GetDisciplinesByDirectionAsync(DisciplineFilter filter, CancellationToken
            cancellationToken = default)
        {
            var disc = await _disciplineService.GetDisciplinesByDirectionAsync(filter, cancellationToken);
            return Ok(disc);
        }
    }
}