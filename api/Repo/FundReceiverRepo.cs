using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repo
{
    public class FundReceiverRepo : IRepo<FundReceiver>
    {
        private readonly DatabaseTrainingContext dt;
        public FundReceiverRepo()
        {

        }
        public FundReceiverRepo(DatabaseTrainingContext _dt)
        {
            dt = _dt;
        }

        public void Add(FundReceiver f) {
            dt.FundReceivers.Add(f);
            dt.SaveChanges();
        }
        public void Delete(string id) {
            FundReceiver f = dt.FundReceivers.Find(id);
            dt.FundReceivers.Remove(f);
            dt.SaveChanges();
        }
        public List<FundReceiver> Get(){
            return dt.FundReceivers.ToList();
        }
        public FundReceiver GetById(string id) {
            FundReceiver f = dt.FundReceivers.Find(id);
            return f;
        }

        public void Update(FundReceiver f) {
            dt.FundReceivers.Update(f);
            dt.SaveChanges();
            
        }
    }
}
