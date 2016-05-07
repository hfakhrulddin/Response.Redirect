using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ResponseRedirection
{
    public static class Redirection
    {
        public static void Redirect(this HttpResponse response, int type, string url)
        {
            response.Clear();

            switch (type)
            {
                case 301:
                    response.StatusCode = (int)HttpStatusCode.MovedPermanently;
                    response.StatusDescription = "Moved Permanently";
                    break;

                case 302:
                    response.StatusCode = (int)HttpStatusCode.Found;
                    response.StatusDescription = "Found";
                    break;

                case 303:
                    response.StatusCode = (int)HttpStatusCode.SeeOther;
                    response.StatusDescription = "See Other";
                    break;

                case 304:
                    response.StatusCode = (int)HttpStatusCode.NotModified;
                    response.StatusDescription = "Not Modified";
                    break;

                case 307:
                    response.StatusCode = (int)HttpStatusCode.TemporaryRedirect;
                    response.StatusDescription = "Temporary Redirect";
                    break;

                default:
                    goto case 302;
            }

            response.RedirectLocation = url;

            response.ContentType = "text/html";
            response.Write("<html><head><title>Object Moved</title></head><body>");
            response.Write("<h2>Object moved to <a href=\"" + HttpUtility.HtmlAttributeEncode(url) + "\">here</a>.</h2>");
            response.Write("</body></html>");

            response.End();
        }
    }
}
