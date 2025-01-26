using ExpenseAppAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseAppAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
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
        public ExpenseController(ExpenseAppContext context, ILogger<ExpenseAppContext> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        #region Actions

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
        /// Its fetching all detail of expense detail with multiple record against single expense
        /// </summary>
        /// <param name="expenseid"></param>
        /// <returns>ExpenseDetailList</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable< ExpenseDetailList>>> ExpenseDetailList(int expenseid)
        {
            List<ExpenseDetailList> expeDetList = new List<ExpenseDetailList>();
            try
            {
                int expenseid_ = expenseid;
               
                 expeDetList = await _context.Database.SqlQuery<ExpenseDetailList>($"EXECUTE [ExpenseApp].[dbo].[sp_VPExpenseDetailList] @expenseid={expenseid_} ").ToListAsync();
                return expeDetList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return expeDetList;
            }
        }
        /// <summary>
        /// Its return list of manager
        /// </summary>
        /// <returns>Authentication</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authentication>>> ManagerList()
        {
            List<Authentication> auth=new List<Authentication>();
            try
            {
                auth = await _context.Database.SqlQuery<Authentication>($"EXECUTE [ExpenseApp].[dbo].[sp_VPManagerList]").ToListAsync();
                return auth;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return auth;
            }
        }
        /// <summary>
        /// List of expense type (e.g; food, travel)
        /// </summary>
        /// <returns>ExpenseList</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseList>>> ExpenseList()
        {
            List<ExpenseList> expList=new List<ExpenseList>();
            try
            {
                expList = await _context.Database.SqlQuery<ExpenseList>($"EXECUTE [ExpenseApp].[dbo].[sp_VPExpenseTypeList]").ToListAsync();
                return expList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return expList;
            }
        }
        /// <summary>
        /// Its getting all the data of expense without detail, Its only return the master and summarize data of expense
        /// </summary>
        /// <param name="role"></param>
        /// <param name="managerusername"></param>
        /// <returns>Expense</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> ExpenseStatusChangeData(string role, string managerusername)
        {
            List<Expense> ExpenseStatusChangeData=new List<Expense>();
            try
            {
                 ExpenseStatusChangeData = await _context.Database.SqlQuery<Expense>($"EXECUTE [ExpenseApp].[dbo].[sp_VPExpenseStatus] @managerusername={managerusername},@role={role} ").ToListAsync();
                return ExpenseStatusChangeData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return ExpenseStatusChangeData;
            }
          
        }
        /// <summary>
        /// This function is using for change request of expense status
        /// </summary>
        /// <param name="exp"></param>
        /// <returns>Expense</returns>
        [HttpPost]
        public async Task<ActionResult<Expense>> StatusChangeRequest(Expense exp)
        {
            Expense e = new Expense();
            try
            {
                await _context.Database.ExecuteSqlAsync($"EXECUTE [ExpenseApp].[dbo].[sp_VPExpenseStatusChange] @expenseid={exp.Id},@role={exp.Role},@changerequestid={exp.ChangeRequestID},@note={exp.Notes},@modifiedby={exp.ModifiedBy}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                
            }
            return e;
        }
        /// <summary>
        /// Save the detail of expense
        /// </summary>
        /// <param name="expDet"></param>
        /// <returns>ExpenseDetail</returns>
        [HttpPost]
        public async Task<ActionResult<ExpenseDetail>> ExpenseDetail(ExpenseDetail expDet)
        {
            ExpenseDetail expdetail = expDet;
            try
            {
                var parameterReturn = new SqlParameter
                {
                    ParameterName = "ReturnValue",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                };
                await _context.Database.ExecuteSqlRawAsync($"EXECUTE @returnValue = [ExpenseApp].[dbo].[sp_VPInsertExpenseDetail] @expenseid={expdetail.ExpenseId} , @expensetype={expdetail.Expensetype}, @amount={expdetail.Amount},@expensedate={"'" + expdetail.ExpenseDate.ToString("yyyy-MM-dd") + "'"}, @purposeofexpense={"'"+expdetail.PurposeOfExpense+"'"}, @createby={expdetail.CreateBy}", parameterReturn);
                int returnValue = (int)parameterReturn.Value;
                if (returnValue != 0)
                {
                    expdetail.Id = returnValue;
                }
                return expdetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return expdetail;
            }
           
        }
        /// <summary>
        /// Its create the single master record of expense
        /// </summary>
        /// <param name="exp_"></param>
        /// <returns>Expense</returns>
        [HttpPost]
        public async Task<ActionResult<Expense>> InitiateExpense(Expense exp_)
        {
            Expense expense = exp_;
            try
            {
                var parameterReturn = new SqlParameter
                {
                    ParameterName = "ReturnValue",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                };
                await _context.Database.ExecuteSqlRawAsync($"EXECUTE @returnValue = [ExpenseApp].[dbo].[sp_VPInsertExpenseMaster] @username={exp_.Username} , @role={exp_.Role},@currencytype={exp_.CurrencyType}", parameterReturn);
                int returnValue = (int)parameterReturn.Value;
                if (returnValue != 0)
                {
                    expense.Id = returnValue;
                }
                return expense;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return expense;
            }

        }
        #endregion
    }

    #region Its class for Expense Detail List
    public class ExpenseDetailList {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int Expensetype { get; set; }
        public string? Expensename {get;set;}
        public decimal? Amount { get; set; }
        public string? ExpenseDate { get; set; }
        public string? PurposeOfExpense { get; set; }
    }
    #endregion
}
