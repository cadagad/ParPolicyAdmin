using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;

namespace BusinessLogic.Data
{
    public class BarcodeFeedRepo
    {
        private readonly AppDbContext _appDbContext;

        public BarcodeFeedRepo()
        {
            _appDbContext = new AppDbContext();
        }

        public List<BarcodeFeed> GetBarcodeFeeds_ByProjectId(int projectId)
        {
            List<BarcodeFeed> barcodeFeeds = _appDbContext.BarcodeFeeds
                .Where(pf => pf.ProjectId == projectId &&
                             pf.IsValid == true)
                .ToList();
            return barcodeFeeds;
        }
    }
}
