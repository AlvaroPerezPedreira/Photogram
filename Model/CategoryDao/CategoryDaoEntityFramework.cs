using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;

namespace Es.Udc.DotNet.PracticaMaD.Model.CategoryDao
{
    public class CategoryDaoEntityFramework : GenericDaoEntityFramework<Category, Int64>, ICategoryDao
    {
        public Category FindByName(string name)
        {
            Category category = null;

            #region Option 1: Using Linq.

            DbSet<Category> categories = Context.Set<Category>();

            var result =
                (from c in categories
                 where c.Nombre == name
                 select c);

            category = result.FirstOrDefault();

            #endregion Option 1: Using Linq.

            if (category == null)
                throw new InstanceNotFoundException(name,
                    typeof(UserProfile).FullName);

            return category;
        }

    }
}