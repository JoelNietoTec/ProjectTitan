using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TitanWebAPI.Models.Financial;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class FinancialDashboardController : ApiController
    {

        private FinancialModel db = new FinancialModel();

        // GET: api/FinancialDashboard
        public IQueryable<FinancialDashboard> GetDashboards()
        {
            return db.FinancialDashboards;
        }

        // GET: api/FinancialDashboard/5
        public IQueryable<FinancialDashboard> GetDashboard(int id)
        {
            return db.FinancialDashboards.Where(x => x.ParticipantID == id);
        }

    }
}
