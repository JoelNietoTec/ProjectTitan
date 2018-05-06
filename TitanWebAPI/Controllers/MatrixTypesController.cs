using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TitanWebAPI.Models.Params;

namespace TitanWebAPI.Controllers
{
     [EnableCors(origins: "http://localhost:4200, http://procompliance.azurewebsites.net, http://procompliancesoft.net", headers: "*", methods: "*")]
    public class MatrixTypesController : ApiController
    {
        private ParamsModel db = new ParamsModel();

        // GET: api/MatrixTypes
        public IQueryable<MatrixType> GetMatrixTypes()
        {
            return db.MatrixTypes;
        }

        // GET: api/MatrixTypes/5
        [ResponseType(typeof(MatrixType))]
        public IHttpActionResult GetMatrixType(int id)
        {
            MatrixType matrixType = db.MatrixTypes.Find(id);
            if (matrixType == null)
            {
                return NotFound();
            }

            return Ok(matrixType);
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatrixTypeExists(int id)
        {
            return db.MatrixTypes.Count(e => e.ID == id) > 0;
        }
    }
}