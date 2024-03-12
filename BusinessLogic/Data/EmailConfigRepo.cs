using BusinessLogic.Models;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class EmailConfigRepo
    {
        private readonly AppDbContext _appDbContext;

        public EmailConfigRepo()
        {
            _appDbContext = new AppDbContext();
        }

        public List<EmailConfig> GetAllEmailConfig()
        {
            List<EmailConfig> emailConfigList = _appDbContext.EmailConfig.AsNoTracking().OrderBy(ec => ec.Name).ToList();

            Project activeProject = _appDbContext.Projects.Where(p => p.IsActive).FirstOrDefault();
            if (activeProject != null ) 
            {
                emailConfigList.Where(ecl => ecl.Name == "Project Description").FirstOrDefault().Value = activeProject.Name;
                emailConfigList.Where(ecl => ecl.Name == "Due Date").FirstOrDefault().Value = activeProject.DueDate.ToString("MMMM dd, yyyy");
            }

            Project latest = _appDbContext.Projects.OrderByDescending(p => p.CreatedDate).FirstOrDefault();
            if (latest != null)
            {
                emailConfigList.Where(ecl => ecl.Name == "Latest Project").FirstOrDefault().Value = latest.Name;
            }

            emailConfigList.Where(ecl => ecl.Name == "Todays Date").FirstOrDefault().Value = DateTime.Now.ToString("MMMM dd, yyyy");

            return emailConfigList;
        }

        public List<EmailConfig> GetEmailTemplate()
        {
            List<EmailConfig> emailConfigList = _appDbContext.EmailConfig
                .AsNoTracking()
                .Where(ecl => 
                    ecl.Name.Equals("Email Body") || 
                    ecl.Name.Equals("Email Subject") ||
                    ecl.Name.Equals("Email To") ||
                    ecl.Name.Equals("Email Cc"))
                .OrderBy(ec => ec.Name).ToList()
                .ToList();
            return emailConfigList;
        }

        public void AddEmailTemplate(string name, string value)
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrEmpty(name))
            {
                throw new Exception("Email config requires a Name and Value");
            }

            EmailConfig emailConfig = _appDbContext.EmailConfig.Where(e => e.Name.Equals(name)).FirstOrDefault();
            if (emailConfig != null)
            {
                throw new Exception("Email config already exist");
            }

            EmailConfig newItem = new EmailConfig()
            {
                Name = name,
                Type = "Assigned",
                Value = value
            };

            _appDbContext.EmailConfig.Add(newItem);
            _appDbContext.SaveChanges();
        }
        public void UpdateEmailTemplate(string name, string value)
        {
            EmailConfig emailConfig = _appDbContext.EmailConfig.Where(e => e.Name.Equals(name.Trim())).FirstOrDefault();
            if (emailConfig != null)
            {
                emailConfig.Value = value.Trim();
                _appDbContext.SaveChanges();
            }
        }

        public void SaveEmailTemplate(string to, string cc, string subject, string body)
        {
            bool hasValue = false;

            EmailConfig ecTo = _appDbContext.EmailConfig.Where(e => e.Name.Equals("Email To")).FirstOrDefault();
            if (ecTo != null ) 
            {
                ecTo.Value = to.Trim();
                hasValue = true;
            }
            

            EmailConfig ecCc = _appDbContext.EmailConfig.Where(e => e.Name.Equals("Email Cc")).FirstOrDefault();
            if (ecCc != null)
            {
                ecCc.Value = cc.Trim();
                hasValue = true;
            }

            EmailConfig ecSubject = _appDbContext.EmailConfig.Where(e => e.Name.Equals("Email Subject")).FirstOrDefault();
            if (ecSubject != null)
            {
                ecSubject.Value = subject.Trim();
                hasValue = true;
            }

            EmailConfig ecBody = _appDbContext.EmailConfig.Where(e => e.Name.Equals("Email Body")).FirstOrDefault();
            if (ecBody != null)
            {
                ecBody.Value = body.Trim();
                hasValue = true;
            }

            if (hasValue)
                _appDbContext.SaveChanges();
        }

        public string getActualEmailBody()
        {
            var template = _appDbContext.EmailConfig.Where(ec => ec.Name == "Email Body").FirstOrDefault();
            if (template == null)
                return null;

            string emailTemplate = template.Value;
            var arr = _COM.EnclosedStrings(emailTemplate, "<<", ">>");
            var confAll = GetAllEmailConfig();

            foreach (string s in arr)
            {
                string placeholder = s;
                string actualValue = String.Empty;
                var eCon = confAll.Where(ec => ec.Name == placeholder).FirstOrDefault();
                if (eCon != null)
                    actualValue = eCon.Value;
                emailTemplate = emailTemplate.Replace("<<" + s + ">>", actualValue);
            }

            return emailTemplate;
        }
    }
}
