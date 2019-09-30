using System.Collections.Generic;

namespace MailSenderLib.Services
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        int Create(T item);

        void Edit(int id, T item);

        bool Remove(int id);

        void SaveChanges();
    }
}
