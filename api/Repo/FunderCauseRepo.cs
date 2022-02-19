using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repo
{
    public class FunderCauseRepo : ICRepo<FunderCause>
    {
        private readonly DatabaseTrainingContext dt;
        public FunderCauseRepo()
        {

        }
        public FunderCauseRepo(DatabaseTrainingContext _dt)
        {
            dt = _dt;
        }

        public void Add(FunderCause f) {
            dt.FunderCauses.Add(f);
            dt.SaveChanges();
        }
        public void Delete(int id) {
            FunderCause c = dt.FunderCauses.Find(id);
            dt.FunderCauses.Remove(c);
            dt.SaveChanges();
        }
        public List<FunderCause> Get(){
            return dt.FunderCauses.ToList();
        }
        public FunderCause GetById(int id) {
            FunderCause f = dt.FunderCauses.Find(id);
            return f;
        }

        public void Update(FunderCause c) {
            dt.FunderCauses.Update(c);
            dt.SaveChanges();
        }
    }
}
