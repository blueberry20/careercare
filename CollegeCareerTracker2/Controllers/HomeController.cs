using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollegeCareerTracker2.CloudStorage.Parent;
using CollegeCareerTracker2.CloudStorage.Student;
using Newtonsoft.Json;
using CollegeCareerTracker2.Helpers;
using System.Threading.Tasks;


namespace CollegeCareerTracker2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult getParentResponses(Parent pParent)
        {
            try
            {

                ParentClient tableStorage = new ParentClient();
                tableStorage.Add(pParent);
                string emailTemplate = EmailTemplateHelper.GetTemplate("ParentEmail");
                string emailBody = string.Format(emailTemplate, pParent.FirstName);
                EmailHelper.SendEmail(pParent.Email, "no-reply@Career.care", "Your Registration Follow up", emailBody, true);
                return Content(JsonConvert.SerializeObject(new { }), "application/json");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, ex.Message);
            }

        }

        [HttpPost]
        public ActionResult getStudentResponses(Student pStudent)
        {
            try
            {
                StudentClient tableStorage = new StudentClient();
                tableStorage.Add(pStudent);
                //email to student
                string emailBody = EmailTemplateHelper.GetTemplate("StudentEmail");
                emailBody = string.Format(emailBody, pStudent.FirstName);
                EmailHelper.SendEmail(pStudent.Email, "no-reply@Career.care", "Your Registration Follow up", emailBody, true);
                //email to student's parent
                string emailBody2 = EmailTemplateHelper.GetTemplate("Parent_InitiatedByStudent");
                emailBody2 = string.Format(emailBody2, pStudent.FirstParentFirstName, pStudent.FirstName);
                EmailHelper.SendEmail(pStudent.FirstParentEmail, "no-reply@Career.care", "Following up on behalf of " + pStudent.FirstName, emailBody2, true);

                //if second parent's info was filled out, send email to second parent
                if (pStudent.SecondParentEmail != null)
                {
                    string emailBody3 = EmailTemplateHelper.GetTemplate("Parent_InitiatedByStudent");
                    emailBody3 = string.Format(emailBody3, pStudent.SecondParentFirstName, pStudent.FirstName);
                    EmailHelper.SendEmail(pStudent.SecondParentEmail, "no-reply@Career.care", "Following up on behalf of " + pStudent.FirstName, emailBody3, true);
                }
                return Content(JsonConvert.SerializeObject(new { }), "application/json");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, ex.Message);
            }
        }

        public ActionResult DeleteStudents()
        {
            try
            {
                StudentClient tableStorage = new StudentClient();
                tableStorage.DeleteTable();
                return Content(JsonConvert.SerializeObject(new { }), "application/json");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, ex.Message);
            }
        }
        public ActionResult DeleteParents()
        {
            try
            {
                ParentClient tableStorage = new ParentClient();
                tableStorage.DeleteTable();
                return Content(JsonConvert.SerializeObject(new { }), "application/json");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, ex.Message);
            }
        }

        public ActionResult PrivacyPolicy()
        {
            ViewBag.Message = "Privacy Policy";
            return View();
        }

        public ActionResult Sandbox()
        {
            ViewBag.Message = "Sandbox";
            return View();
        }

        public ActionResult TermsOfUse()
        {
            ViewBag.Message = "Terms Of Use";
            return View();
        }
        public ActionResult User_Dashboard2017()
        {
            ViewBag.Message = "User Dashboard 2017";
            return View();
        }
    }
}