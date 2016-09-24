using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace av2_net.Web
{
    public class Router
    {
        public static void HandleRequest(HttpContext context)
        {
            
            try{
                if(context.Request.Path.ToString() == "/")
                    Helper.ResponsePage(context, 200, "/web/views/index.html");
                if(context.Request.Path.ToString().StartsWith("/supplier"))
                    SupplierDomain.Handler.Handle(context);
                else
                    Helper.ResponseText(context, 404, "page not found");
            }catch(Exception){
                Helper.ResponseText(context, 500, "internal server error");
            }
        }

    }
}