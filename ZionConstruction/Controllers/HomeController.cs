using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ZionConstruction.Models;

namespace ZionConstruction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Photos()
        {
            var images = new List<ImageGroupViewModel>();

            DirectoryInfo imageDir = null;
            FileInfo[] imageFiles = null;

            string dirPath = @"/WorkImages/";
            imageDir = new DirectoryInfo(Server.MapPath(dirPath));

            var imageChildren = imageDir.GetDirectories();

            foreach (var imageDirectory in imageChildren)
            {

                var DirectoryName = imageDirectory.Name;
                if (DirectoryName != "clients" && DirectoryName != "backgrounds")
                {
                    var imagefilePath = "";

                    foreach (var image in imageDirectory.GetFiles())
                    {
                        imagefilePath = @"/WorkImages/" + DirectoryName + "/" + image.Name;
                        images.Add(new ImageGroupViewModel { Group = DirectoryName, Image = imagefilePath });
                    }
                }

            }
            //imageFiles = imageDir.GetFiles();



            ViewBag.Images = images;

            return View(images);
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Your services page.";

            return View();
        }

        public ActionResult SendEmail(string Name, string Phone, string Message, string Email, string Subject)
        {

            var passWord = "Test";
            var email = new MailAddress("Test@gmail.com", "Jeff");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email.Address, passWord)
            };

            using (var mess = new System.Net.Mail.MailMessage(email, email)
            {
                Subject = Subject,
                Body = "From: " + Name + "\n Phone Number: " + Phone + "\n Job Description: " + Message + "\n Email: " + Email
            })
            {
                smtp.Send(mess);
            }




            //System.Web.Mail.SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            //SmtpMail.Send(emailmessage);
            MessageBox("Email sent successfully!");


            return new EmptyResult();
        }
        public EmptyResult MessageBox(string s)
        {
            Response.Write("<script type=\"text/javascript\">alert('" + s + "');</script>");
            return null;
        }


    }
}