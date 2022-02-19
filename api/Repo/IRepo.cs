using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repo
{
    public interface IRepo<T>
    {
        public void Add(T p);
        public void Delete(string id);
        public List<T> Get();
        public T GetById(string id);

        public void Update(T f);
    }
}
