using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Common.Web.Mvc.ActionResults
{
    /// <summary>
    /// Résultat JSON formatté avec JSON.NET (corrige notamment le format des dates).
    /// </summary>
    public class JsonNetResult : JsonResult
    {
        /// <summary>
        /// Paramètres de sérialisation.
        /// </summary>
        public JsonSerializerSettings Settings { get; private set; }

        /// <summary>
        /// Initialise une instance de la classe <see cref="JsonNetResult" />.
        /// </summary>
        public JsonNetResult()
        {
            Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Error
            };
        }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the
        /// <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">
        /// The context in which the result is executed. The context information includes the controller,
        /// HTTP content, request context, and route data.
        /// </param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("JSON GET is not allowed");

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = String.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Data == null)
                return;

            JsonSerializer scriptSerializer = JsonSerializer.Create(Settings);

            using (var sw = new StringWriter())
            {
                scriptSerializer.Serialize(sw, Data);
                response.Write(sw.ToString());
            }
        }
    }
}