using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using av2_net.Web.Helpers;
using av2_net.SupplierDomain;
using av2_net.ProcessDomain;

namespace av2_net.Web
{
    public class Router
    {
        public static void HandleRequest(HttpContext context)
        {
            try{
                if(context.Request.Path.ToString() == "/" || context.Request.Path.ToString() == "")
                    Responser.ResponsePage(context, "/web/views/index.html");
                else if(context.Request.Path.ToString().StartsWith("/supplier"))
                    new SupplierHandler().Handle(context);
                else if(context.Request.Path.ToString().StartsWith("/process"))
                    new ProcessHandler().Handle(context);
                else
                    Responser.ResponseText(context, "page not found");
            }catch(Exception){
                Responser.ResponseText(context, "internal server error");
            }
        }

    }
}