using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class SourceRepo
    {
        private readonly AppDbContext _appDbContext;

        public SourceRepo()
        {
            _appDbContext = new AppDbContext();
        }

        public List<VwSourceSummaryByProject> GetAllSources_WithCount(int projectId)
        {
            List<VwSourceSummaryByProject> output = new List<VwSourceSummaryByProject>();

            var result =
                (from s in _appDbContext.Sources.Where(s1 => s1.IsActive && s1.Code != "Undefined")
                 join p in _appDbContext.Policy.Where(p1 => p1.PolicyFeed.ProjectId == projectId)
                    on s.Code equals p.SystemCode into j1
                 from j2 in j1.DefaultIfEmpty()
                 group j2 by s.Code into grouped
                 orderby grouped.Key
                 select new
                 {
                     Code = grouped.Key,
                     Records = grouped.Count(p => p.SystemCode != null)
                 }).ToList();

            foreach (var r in result)
            {
                output.Add(new VwSourceSummaryByProject
                {
                    Code = r.Code,
                    Records = r.Records
                });
            }

            return output;
        }
    }
}
