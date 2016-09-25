using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using av2_net.Persistence;
using av2_net.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace av2_net.ProcessDomain
{
    public class ProcessHandler : Handler
    {
        protected override void get(HttpContext context) 
        {
            if (context.Request.Path.ToString().Contains("/new")) 
                Responser.ResponsePage(context, "/process/views/form.html");
            else if (context.Request.Path.ToString().Contains("/edit"))
                Responser.ResponsePage(context, "/process/views/form_edit.html");
            else {
                var resp = new StringBuilder();
                ProcessTable.Instance.FindAll().ForEach(s => resp.Append("<li>" + s.ToString() + " <a href=\"/process/edit?id=" + s.id + "\">editar</a><form action=\"/process\" method=\"delete\"><input type=\"submit\" value=\"deletar\"></form></li>"));

                Responser.ResponsePage(context, "/process/views/list.html", resp.Append("</ul>").ToString());
            }
        }

        protected override void post(HttpContext context) 
        {
            try{
                var Process = parseForm(context.Request);
                ProcessTable.Instance.Add(Process);
                context.Response.Redirect("/process");
            }
            catch(ArgumentException e){
                Responser.ResponsePage(context, "/process/views/form.html", e.Message);
            }
            catch(FormatException){
                Responser.ResponsePage(context, "/process/views/form.html", "Insira uma data válida");
            }
            catch(Exception e){
                Responser.ResponseText(context, e.Message);
            }
        }

        protected override void put(HttpContext context) 
        {
            try{
                var process = parseForm(context.Request);
                ProcessTable.Instance.Edit(process);
                context.Response.Redirect("/process");
            }
            catch(ArgumentException e){
                Responser.ResponsePage(context, "/process/views/form.html", e.Message);
            }
            catch(FormatException){
                Responser.ResponsePage(context, "/process/views/form.html", "Insira uma data válida");
            }
            catch(Exception e){
                Responser.ResponseText(context, e.Message);
            }
        }

        protected override void delete(HttpContext context) 
        {
            try{
                var id = uint.Parse(context.Request.Query["id"]);
                ProcessTable.Instance.Remove(id);
                context.Response.Redirect("/process");
            }
            catch(Exception e){
                Responser.ResponseText(context, e.Message);
            }
        }

        private static Process parseForm(HttpRequest req) 
        {
            var report = req.Form["report"];
            var date = req.Form["date"];
            var reporter = req.Form["reporter"];
            
            return new Process(report, DateTime.Parse(date), reporter, null);
        }
    }
}
