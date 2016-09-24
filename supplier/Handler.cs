using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using av2_net.Persistence;
using av2_net.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace av2_net.SupplierDomain
{
    public class Handler
    {
        public static void Handle(HttpContext context)
        {
            Console.WriteLine(context.Request.Method);
            switch (context.Request.Method)
            {
                case "GET":
                    get(context);
                    break;
                case "POST":
                    post(context);
                    break;
                default:
                    get(context);
                    break;
            }
        }

        private static void get(HttpContext context) 
        {
            if (context.Request.Path.ToString().Contains("/new")) {
                Helper.ResponsePage(context, 200, "/supplier/views/form.html");
            } else {
                var resp = new StringBuilder();
                SupplierTable.Instance.FindAll().ForEach(s => resp.Append("<li>" + s.ToString() + "</li>"));

                Helper.ResponsePage(context, 200, "/supplier/views/list.html", resp.Append("</ul>").ToString());
            }
        }

        private static void post(HttpContext context) 
        {
            try{
                var supplier = parseForm(context.Request);
                SupplierTable.Instance.Add(supplier);
                context.Response.Redirect("/supplier");
            }
            catch(ArgumentException e){
                Helper.ResponsePage(context, 400, "/supplier/views/form.html", e.Message);
            }
            catch(FormatException){
                Helper.ResponsePage(context, 400, "/supplier/views/form.html", "Insira um numero valido para Receita");
            }
            catch(Exception e){
                Helper.ResponseText(context, 400, e.Message);
            }
        }

        private static Supplier parseForm(HttpRequest req) 
        {
            var cnpj = req.Form["cnpj"];
            var name = req.Form["name"];
            var registration = req.Form["registration"];
            var earnings = req.Form["earnings"];
            
            return new Supplier(cnpj, name, registration, float.Parse(earnings));
        }
    }
}
