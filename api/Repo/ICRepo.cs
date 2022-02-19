using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repo
{
    public interface ICRepo<T>
    {
        public void Add(T p);
        public void Delete(int id);
        public List<T> Get();
        public T GetById(int id);

        public void Update(T f);
    }
}
