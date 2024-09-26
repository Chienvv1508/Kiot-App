using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    interface IShelvesServices
    {
        /// <summary>
        /// Lấy shelf. Trả về null nếu ko tìm thấy
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Shelf GetShelf(Expression<Func<Shelf, bool>> expression);
        public List<Shelf> GetShelves();
        public List<Shelf> GetShelves(Expression<Func<Shelf, bool>> expression);
        void Insert(Shelf shelf);
        void Update(Shelf existedShelf);
    }
}
