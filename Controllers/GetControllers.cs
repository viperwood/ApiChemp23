using System.Diagnostics.Contracts;
using Chempionat23Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chempionat23Api.Controllers;
[Route("Api/[controller]")]
[Controller]
public class GetControllers : Controller
{
    //get info
    [HttpGet("GetInfo")]
    public IActionResult GetInfo()
    {
        return Ok(Helper.Database.Users.Where(x => x.Datadrop == new DateTime(9999,01,01)).Select(x => new
        {
            x.Datadrop,
            x.Id,
            x.Fio,
            x.Login,
            x.Passworduser
        }));
    }
    
    //get histori
    [HttpGet("GetHistori")]
    public IActionResult GetHistori()
    {
        return Ok(Helper.Database.Historis.Where(x => x.Datadrop == new DateTime(9999,01,01)).Join(Helper.Database.Users,
            u => u.Userid,
            x => x.Id,
            (u,x) => new
            {
                x.Login,
                x.Ip,
                u.Datahistori,
                u.Connectuser
            }));
    }

    
    //get login
    [HttpGet("GetLogin")]
    public IActionResult GetLogin(string login, string password)
    {
        Histori histori = new Histori();
        if (string.IsNullOrEmpty(login) == false)
        {
            if (string.IsNullOrEmpty(password) == false)
            {
                var connect = Helper.Database.Users.Where(x => x.Login == login && x.Passworduser == password).Select(x => new
                {
                    x.Login,
                    x.Id,
                    x.Fio,
                    x.Roleuser,
                    x.Passworduser
                }).ToList();
                if (connect.Count() == 1)
                {
                    
                    histori.Datahistori = DateTime.Now;
                    histori.Connectuser = true;
                    histori.Userid = connect[0].Id;
                    Helper.Database.Add(histori);
                    Helper.Database.SaveChanges();
                    return Ok(connect);
                }
            }   
        }
        histori.Datahistori = DateTime.Now;
        histori.Connectuser = false;
        var idsave = Helper.Database.Users.Where(x => x.Login == login).Select(x => x.Id).ToList();
        histori.Userid = idsave[0];
        Helper.Database.Add(histori);
        Helper.Database.SaveChanges();
        return Ok();
    }
}