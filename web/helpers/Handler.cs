using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace av2_net.Web.Helpers
{
    public class Handler
    {
        public void Handle(HttpContext context)
        {
            switch (context.Request.Method)
            {
                case "GET":
                    get(context);
                    break;
                case "POST":
                    post(context);
                    break;
                case "PUT":
                    put(context);
                    break;
                case "DELETE":
                    delete(context);
                    break;
                default:
                    get(context);
                    break;
            }
        }

        protected virtual void get(HttpContext context)
        {
            Responser.ResponseText(context, "invalid method");
        }

        protected virtual void post(HttpContext context)
        {
            Responser.ResponseText(context, "invalid method");
        }

        protected virtual void put(HttpContext context)
        {
            Responser.ResponseText(context, "invalid method");
        }

        protected virtual void delete(HttpContext context)
        {
            Responser.ResponseText(context, "invalid method");
        }
    }
}



