using ExpenseAppAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAppAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CDNPersonController : Controller
    {
        private readonly ExpenseAppContext _context;
        private readonly ILogger<ExpenseAppContext> _logger;
        public CDNPersonController(ExpenseAppContext context, ILogger<ExpenseAppContext> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CDNPerson>>> CDNPersonList()
        {
            List<CDNPerson> CDNPersonData = new List<CDNPerson>();
            try
            {
                CDNPersonData = await _context.Database.SqlQuery<CDNPerson>($"EXECUTE [ExpenseApp].[dbo].[sp_CDNPersonList]").ToListAsync();
                return CDNPersonData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return CDNPersonData;
            }

        }
        [HttpPost]
        public async Task<ActionResult<CDNPerson>> DeleteCDNPerson(CDNPerson exp)
        {
            CDNPerson e = new CDNPerson();
            try
            {
                await _context.Database.ExecuteSqlAsync($"EXECUTE [ExpenseApp].[dbo].[sp_CDNDeletePerson] @cdnid={exp.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());

            }
            return e;
        }

        [HttpPost]
        public async Task<ActionResult<CDNPerson>> UpdateCDNPersonUpdate(CDNPerson cdn)
        {
            CDNPerson e = new CDNPerson();
            try
            {
                await _context.Database.ExecuteSqlAsync($"EXECUTE [ExpenseApp].[dbo].[sp_CDNPersonUpdate] @id={cdn.Id},@uername={cdn.Username},@email={cdn.Email},@phonenumber={cdn.PhoneNumber},@archive={cdn.archieve}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());

            }
            return e;
        }

        [HttpPost]
        public async Task<ActionResult<CDNPerson>> Register(CDNPerson cdnperson)
        {
            CDNPerson cdnp = cdnperson;
            try
            {
                var parameterReturn = new SqlParameter
                {
                    ParameterName = "ReturnValue",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                };
                await _context.Database.ExecuteSqlRawAsync($"EXECUTE @returnValue = [ExpenseApp].[dbo].[sp_CDNADDPerson] @username={cdnperson.Username} , @email={"'"+cdnp.Email+"'"},@phonenumber={cdnp.PhoneNumber}", parameterReturn);
                int returnValue = (int)parameterReturn.Value;
               
                return cdnp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return cdnp;
            }
        }
        [HttpPost]
        public async Task<ActionResult<CDNPersonDetail>> CDNPersonDetail(CDNPersonDetail cdnpersondetail)
        {
            CDNPersonDetail cdnpd = cdnpersondetail;
            try
            {
                var parameterReturn = new SqlParameter
                {
                    ParameterName = "ReturnValue",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                };
                await _context.Database.ExecuteSqlRawAsync($"EXECUTE @returnValue = [ExpenseApp].[dbo].[sp_CDNPersonDetail] @cdnpersonid={cdnpersondetail.cdnpersonid} , @hobbies={"'" + cdnpersondetail.hobbies + "'"},@skillset={"'" + cdnpersondetail.SkillSet + "'"}", parameterReturn);
                int returnValue = (int)parameterReturn.Value;

                return cdnpd;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return cdnpd;
            }
        }
    }
}
