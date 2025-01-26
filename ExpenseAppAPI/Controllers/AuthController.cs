using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseAppAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Net;

namespace ExpenseAppAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Global Variables

        /// <summary>
        /// Declared variables for db context and logger
        /// </summary>
        private readonly ExpenseAppContext _context;
        private readonly ILogger<ExpenseAppContext> _logger;
        #endregion

        #region constructure

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public AuthController(ExpenseAppContext context, ILogger<ExpenseAppContext> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        #region Actions

        /// <summary>
        /// First running API action to show text on browser
        /// </summary>
        /// <returns>Its void</returns>
        [HttpGet]
        public string Get()
        {
            return "API is running";
        }

        /// <summary>
        /// Its used for error logging
        /// </summary>
        /// <param name="ErrorText"></param>
        [HttpGet]
        public void ErrorLog(string ErrorText)
        {
            try
            {
                _logger.LogError(ErrorText);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Its used for the new user registration
        /// </summary>
        /// <param name="auth_"></param>
        /// <returns>Authentication</returns>

        [HttpPost]
        public async Task<ActionResult<Authentication>> Register(Authentication auth_)
        {
            Authentication authentication = auth_;
            try
            {


                var parameterReturn = new SqlParameter
                {
                    ParameterName = "ReturnValue",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                };
                await _context.Database.ExecuteSqlRawAsync($"EXECUTE @returnValue = [ExpenseApp].[dbo].[sp_VPRegistration] @username={auth_.Username} , @password={auth_.Password},@role={auth_.Role},@managerusername={auth_.Manager_Username}", parameterReturn);
                int returnValue = (int)parameterReturn.Value;
                if (returnValue == 0)
                {
                    authentication.IsAuthenticated = false;
                }
                return auth_;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return auth_;
            }
        }
        /// <summary>
        /// This function using for authentication of user
        /// </summary>
        /// <param name="auth_"></param>
        /// <returns>Authentication</returns>
        [HttpPost]
        public async Task<ActionResult<Authentication>> GetUserData(Authentication auth_)
        {
            Authentication authentication = auth_;
           
            try
            {
                if (_context.VPAuthentication == null)
                {
                    return NotFound();
                }
                else
                {
                    //authentication = await _context.VPAuthentication.Where(a => (a.Username == auth_.Username) && (a.Password == auth_.Password)).SingleAsync();
                    
                    var username = auth_.Username;
                    var password = auth_.Password;
                    var login_ = await _context.VPAuthentication.FromSql($"EXECUTE [ExpenseApp].[dbo].[sp_VPLoginAuthentication] @username={username} , @password={password}").ToListAsync();
                    if (login_.Count != 0)
                    {
                        authentication = login_[0];
                    }
                    else
                    {
                        authentication.IsAuthenticated = false;
                    }

                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message.ToString());

            }
            return authentication;
            
        }
        /// <summary>
        /// This is the master data of role
        /// </summary>
        /// <returns>Role</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> RoleList()
        {
            List<Role> role=new List<Role>();
            try
            {
                role = await _context.Database.SqlQuery<Role>($"EXECUTE [ExpenseApp].[dbo].[sp_VPRoleList]").ToListAsync();
                return role;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return role;
            }
        }
        #endregion
    }
}
