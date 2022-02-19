using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repo
{
    public class CauseRepo : ICRepo<Cause>
    {
        private readonly DatabaseTrainingContext dt;
        public CauseRepo()
        {

        }
        public CauseRepo(DatabaseTrainingContext _dt)
        {
            dt = _dt;
        }

        public void Add(Cause C) {
            dt.Causes.Add(C);
            dt.SaveChanges();
        }
        public void Delete(int id) {
            Cause c = dt.Causes.Find(id);
            dt.Causes.Remove(c);
            dt.SaveChanges();
        }
        public List<Cause> Get(){
            return dt.Causes.ToList();
        }
        public Cause GetById(int id) {
            Cause f = dt.Causes.Find(id);
            return f;
        }

        public void Update(Cause c) {
            dt.Causes.Update(c);
            dt.SaveChanges();
        }
    }
}
