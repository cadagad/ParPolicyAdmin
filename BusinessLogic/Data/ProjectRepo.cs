using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class ProjectRepo
    {
        private readonly AppDbContext _appDbContext;

        public ProjectRepo()
        {
            _appDbContext = new AppDbContext();
        }

        public bool AddProject(Project project)
        {
            _appDbContext.Projects.Add(project);
            _appDbContext.SaveChanges();
            return true;
        }

        public List<Project> GetAllProjects()
        {
            List<Project> ProjectList = _appDbContext.Projects.ToList();
            return ProjectList;
        }

        public bool SetActive(int projectId)
        {
            Project project = _appDbContext.Projects.Where(p => p.IsActive == true).FirstOrDefault();
            if (project != null)
                return false;

            Project activeProject = _appDbContext.Projects.Where(p => p.ProjectId == projectId).FirstOrDefault();
            if (activeProject == null)
                return false;

            activeProject.IsActive = true;
            _appDbContext.SaveChanges();
            return true;
        }

        public bool SetArchived(int projectId)
        {
            Project project = _appDbContext.Projects.Where(p => p.ProjectId == projectId).FirstOrDefault();
            if (project == null)
                return false;

            project.IsActive = false;
            project.IsArchived = true;
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
