using CoreLayer.Interfaces;
using DataLayer.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InspeccoDB _inspeccoDB;

        public UnitOfWork(InspeccoDB inspeccoDB)
        {
            _inspeccoDB = inspeccoDB;
        }

        public void Commit()
        {
            _inspeccoDB.SaveChanges();
        }

        public async Task CommitAsync()
        {
             await _inspeccoDB.SaveChangesAsync();
        }
    }
}
