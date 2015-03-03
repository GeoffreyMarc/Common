using System.Text;
using System.Web.Mvc;
using Common.Web.Mvc.ActionResults;

namespace Common.Web.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Creates a <see cref="T:System.Web.Mvc.JsonResult" /> object that serializes the specified object to JavaScript Object
        /// Notation (JSON) format using the content type, content encoding, and the JSON request behavior.
        /// </summary>
        /// <param name="data">The JavaScript object graph to serialize.</param>
        /// <param name="contentType">The content type (MIME type).</param>
        /// <param name="contentEncoding">The content encoding.</param>
        /// <param name="behavior">The JSON request behavior</param>
        /// <returns>
        /// The result object that serializes the specified object to JSON format.
        /// </returns>
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding,
            JsonRequestBehavior behavior)
        {
            // On remplace la sérialization Microsoft par une sérialization standard (JSON.NET)
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}
