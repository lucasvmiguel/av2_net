using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using av2_net.Persistence;
using av2_net.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace av2_net.SupplierDomain
{
    public class SupplierHandler : Handler
    {
        protected override void get(HttpContext context) 
        {
            if (context.Request.Path.ToString().Contains("/new")) {
                Responser.ResponsePage(context, "/supplier/views/form.html");
            } else {
                var resp = new StringBuilder();
                SupplierTable.Instance.FindAll().ForEach(s => resp.Append("<li>" + s.ToString() + "</li>"));

                Responser.ResponsePage(context, "/supplier/views/list.html", resp.Append("</ul>").ToString());
            }
        }

        protected override void post(HttpContext context) 
        {
            try{
                var supplier = parseForm(context.Request);
                SupplierTable.Instance.Add(supplier);
                context.Response.Redirect("/supplier");
            }
            catch(ArgumentException e){
                Responser.ResponsePage(context, "/supplier/views/form.html", e.Message);
            }
            catch(FormatException){
                Responser.ResponsePage(context, "/supplier/views/form.html", "Insira um numero valido para Receita");
            }
            catch(Exception e){
                Responser.ResponseText(context, e.Message);
            }
        }

        private static Supplier parseForm(HttpRequest req) 
        {
            var cnpj = req.Form["cnpj"];
            var name = req.Form["name"];
            var registration = req.Form["registration"];
            var earnings = req.Form["earnings"];
            
            return new Supplier(cnpj, name, registration, float.Parse(earnings), null);
        }
    }
}
