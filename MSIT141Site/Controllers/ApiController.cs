using Microsoft.AspNetCore.Mvc;
using MSIT141Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{

    public class ApiController : Controller
    {
        private readonly DemoContext _context;   //注入
        public ApiController(DemoContext context)
        {
            _context = context;
        }
        //用GET method:

        public IActionResult Index(/*string name, int age=0*/User user) //"/Api/Index?name=May&age=25"  使參數name與age變數名稱相同 才能自動抓到
        {
            //return Content("Hello Ajax!!");  //Hello Ajax!!
            //return Content("<h1>Hello Ajax!!</h1>"); //<h1>Hello Ajax!!</h1>
            //return Content("<h1>Hello Ajax!!</h1>", "text/html"); //Hello Ajax!!
            //return Content("Hello Ajax!! 你好!");
            //return Content("Hello Ajax!! 你好!", "text/html", System.Text.Encoding.UTF8);


            //System.Threading.Thread.Sleep(5000); //停止5秒鐘

            //if (string.IsNullOrEmpty(name)) 
            //{
            //    name = "Ajax";
            //}
            //return Content($"{name}你好, 你的年紀是{age}!!", "text/plain", System.Text.Encoding.UTF8);

            //例子2:接收AjaxPost view的表單
            if (string.IsNullOrEmpty(user.name))
            {
                user.name = "Ajax";
            }
            return Content($"{user.name }你好, 你的年紀是{user.age}, 電子信箱為{user.email}!!", "text/plain", System.Text.Encoding.UTF8);
        }
        public IActionResult checkName(Member user) //"/Api/Index?name=May&age=25"  使參數name與age變數名稱相同 才能自動抓到
        {
            string message = "";
            Member member = _context.Members.FirstOrDefault(x => x.Name == user.Name);

            if (member == null)
            {
                message = "此名字不存在";
            }
            else 
            {
                message = "此名字存在"; 
            }
            
            return Content(message);
        }

        }
}
