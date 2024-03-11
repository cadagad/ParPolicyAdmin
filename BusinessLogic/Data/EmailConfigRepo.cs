using BusinessLogic.Models;
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

            emailConfigList.Where(ecl => ecl.Name == "Todays Date").FirstOrDefault().Value = DateTime.Now.ToString("MMMM dd, yyyy");

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
    }
}
