using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace av2_net.Web
{
    public class Helper
    {
        public static void ResponseText(HttpContext context, int status, string text)
        {
            context.Response.StatusCode = status;
            context.Response.WriteAsync(text);
        }

        public static void ResponsePage(HttpContext context, int status, string page)
        {
            context.Response.StatusCode = status;
            context.Response.WriteAsync(File.ReadAllText(Directory.GetCurrentDirectory() + page));
        }

        public static void ResponsePage(HttpContext context, int status, string page, string content){
            var fileStr = File.ReadAllText(Directory.GetCurrentDirectory() + page);
            context.Response.WriteAsync(fileStr + content);
        }
    }
}



