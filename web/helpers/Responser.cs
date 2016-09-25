using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace av2_net.Web.Helpers
{
    public class Responser
    {
        public static void ResponseText(HttpContext context, string text)
        {
            context.Response.WriteAsync(text);
        }

        public static void ResponseText(HttpContext context, int status, string text)
        {
            context.Response.StatusCode = status;
            context.Response.WriteAsync(text);
        }

        public static void ResponsePage(HttpContext context, string page){
            var fileStr = File.ReadAllText(Directory.GetCurrentDirectory() + page);
            context.Response.WriteAsync(fileStr);
        }

        public static void ResponsePage(HttpContext context, string page, string content){
            var fileStr = File.ReadAllText(Directory.GetCurrentDirectory() + page);
            context.Response.WriteAsync(fileStr + content);
        }

        public static void ResponsePage(HttpContext context, int status, string page, string content){
            var fileStr = File.ReadAllText(Directory.GetCurrentDirectory() + page);
            context.Response.WriteAsync(fileStr + content);
        }

        
    }
}



