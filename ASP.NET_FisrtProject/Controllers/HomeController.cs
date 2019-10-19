using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_FisrtProject.Models;

namespace ASP.NET_FisrtProject.Controllers
{
    public class HomeController : Controller
    {
        AddressBookContext db;
        public HomeController(AddressBookContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        [HttpGet]
        [ActionName("Add")]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Contacts contact)
        {
            try
            {
                db.Contacts.Add(contact);
                // сохраняем в бд все изменения
                db.SaveChanges();
                Contacts last = db.Contacts.Last();
                ViewBag.Message = "Контакт с ID " + last.Id + " успешно добавлен!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Операция отменена.\n" + ex.Message;
            }


            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public string DeleteContact()
        {
            //int id = int.Parse(Request.Form.ToList()[0].Value);
            int id = int.Parse(Request.Form.FirstOrDefault(p => p.Key == "id").Value);
            try
            {
                Contacts o = db.Contacts.First(p => p.Id == id);
                db.Contacts.Remove(o);
                db.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return "Операция не выполнена\nКонтакта с таким ID не существует.";
            }
            catch (Exception ex)
            {
                return "Операция не выполнена\n" + ex.Message;
            }


            return "Ok";
        }
    }
}
