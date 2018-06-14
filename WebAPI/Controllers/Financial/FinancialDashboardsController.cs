using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Financial;

namespace WebAPI.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialDashboardsController : ControllerBase
    {
        private readonly FinancialContext _context;

        public FinancialDashboardsController(FinancialContext context)
        {
            _context = context;
        }

        // GET: api/FinancialDashboards
        [HttpGet]
        public IEnumerable<FinancialDashboard> GetFinancialDashboards()
        {
            return _context.FinancialDashboards;
        }

        // GET: api/FinancialDashboards/5
        [HttpGet("{id}")]
        public IEnumerable<FinancialDashboard> GetFinancialDashboard([FromRoute] int id)
        {

            return  _context.FinancialDashboards.Where(x => x.ParticipantID.Equals(id));
        }

        private bool FinancialDashboardExists(int id)
        {
            return _context.FinancialDashboards.Any(e => e.ID == id);
        }
    }
}