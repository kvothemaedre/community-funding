using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repo
{
    public class FunderRepo : IRepo<Funder>
    {
        private readonly DatabaseTrainingContext dt;
        public FunderRepo()
        {

        }
        public FunderRepo(DatabaseTrainingContext _dt)
        {
            dt = _dt;
        }

        public void Add(Funder f) {
            
            dt.Funders.Add(f);
            dt.SaveChanges();
        }
        public void Delete(string id) {
            Funder f = dt.Funders.Find(id);
            dt.Funders.Remove(f);
            dt.SaveChanges();
        }
        public List<Funder> Get(){
            return dt.Funders.ToList();
        }
        public Funder GetById(string id) {
            Funder f = dt.Funders.Find(id);
            if (f == null) {
                return null;
            }
            return f;
        }

        public void Update(Funder f) {
            dt.Funders.Update(f);
            dt.SaveChanges();
            
        }
    }
}
