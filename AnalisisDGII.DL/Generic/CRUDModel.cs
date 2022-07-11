using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Generic
{
    public class CRUDModel<T> : ICRUDModel<T> where T : class
    {
        #region Config
#pragma warning disable IDE0044 // Add readonly modifier
        private DGIIEntities dataContext = null;
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning disable IDE0044 // Add readonly modifier
        private DbSet<T> dbSet = null;
#pragma warning restore IDE0044 // Add readonly modifier

        public CRUDModel()
        {
            this.dataContext = new DGIIEntities();
            dbSet = dataContext.Set<T>();
        }

        public CRUDModel(DGIIEntities _context)
        {
            this.dataContext = _context;
            dbSet = _context.Set<T>();
        }

        #endregion


        #region CRUD

        #region Select
        public IEnumerable<T> GetAll()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T Get(int id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public T Get(string id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Insert
        public virtual bool Insert(T entity)
        {
            using (var tran = dataContext.Database.BeginTransaction())
            {
                try
                {
                    dbSet.Add(entity);
                    dataContext.SaveChanges();
                    tran.Commit();
                    return true;
                }
                catch (SqlException s)
                {
                    tran.Rollback();
                    return false;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    return false;
                }

            }
        }
        public bool Insert(List<T> entity)
        {
            using (var tran = dataContext.Database.BeginTransaction())
            {
                foreach (var item in entity)
                {
                    try
                    {
                        dbSet.Add(item);
                        dataContext.SaveChanges();
                        tran.Commit();
                        return true;

                    }
                    catch (SqlException s)
                    {
                        tran.Rollback();
                        return false;
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        return false;
                    }
                }
                return false;
            }
        }
        public virtual T AddGetObject(T entity)
        {
            using (var tran = dataContext.Database.BeginTransaction())
            {
                try
                {
                    var res = dbSet.Add(entity);
                    dataContext.SaveChanges();
                    tran.Commit();
                    return res;
                    //                    return res;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    return null;
                }
            }
        }

        #endregion


        #region Update

        public bool Update(T nuevo)
        {
            try
            {
                dbSet.Attach(nuevo);
                dataContext.Entry(nuevo).State = EntityState.Modified;
                return dataContext.SaveChanges() > 0;
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        /*public bool Actualizar(T nuevo)
        {
            try
            {
                dbSet.(nuevo);
                return dataContext.SaveChanges() > 0;
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }*/
        /*public bool Actualizar(IEnumerable<T> nuevo)
        {
            try
            {
                foreach (var item in nuevo)
                {
                    dbSet.Update(item);
                }
                return dataContext.SaveChanges() > 0;
            }
            catch (SqlException s)
            {
                throw s;
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }*/

        public bool Actualizaaar(IEnumerable<T> nuevo)
        {
            foreach (var item in nuevo)
            {
                try
                {
                    dbSet.Attach(item);
                    dataContext.Entry(item).State = EntityState.Modified;
                    dataContext.SaveChanges();
                }
                catch (SqlException s)
                {
                    throw s;
                }
                catch (Exception e)
                {
                    throw e.InnerException ?? e;
                }
            }
            return true;
        }

        #endregion


        #region Delete


        public bool Delete(int id)
        {
            using (var n = dataContext.Database.BeginTransaction())
            {
                try
                {
                    var res = dbSet.Find(id);
                    if (res != null)
                    {
                        dbSet.Remove(res);
                        var save = dataContext.SaveChanges();
                        n.Commit();
                        return save > 0;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException s)
                {
                    n.Rollback();
                    throw s;
                }
                catch (Exception e)
                {
                    n.Rollback();
                    throw e.InnerException ?? e;
                }
            }
        }

        public bool Delete(T id)
        {
            using (var n = dataContext.Database.BeginTransaction())
            {
                try
                {
                    var res = dbSet.Find(id);
                    if (res != null)
                    {
                        dbSet.Remove(res);
                        var save = dataContext.SaveChanges();
                        n.Commit();
                        return save > 0;
                    }
                    else
                    {
                        throw new Exception("Objeto no encontrado en base de datos");
                    }
                }
                catch (SqlException s)
                {
                    n.Rollback();
                    throw s;
                }
                catch (Exception e)
                {
                    n.Rollback();
                    throw e.InnerException ?? e;
                }
            }
        }

        public bool Delete(string id)
        {
            using (var n = dataContext.Database.BeginTransaction())
            {
                try
                {
                    var res = dbSet.Find(id);
                    if (res != null)
                    {
                        dbSet.Remove(res);
                        var save = dataContext.SaveChanges();
                        n.Commit();
                        return save > 0;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException s)
                {
                    n.Rollback();
                    throw s;
                }
                catch (Exception e)
                {
                    n.Rollback();
                    throw e.InnerException ?? e;
                }
            }
        }

        public bool Delete(List<int> ids)
        {
            using (var n = dataContext.Database.BeginTransaction())
            {
                try
                {

                    foreach (var id in ids)
                    {
                        var res = dbSet.Find(id);
                        if (res != null)
                        {
                            dbSet.Remove(res);
                            var save = dataContext.SaveChanges();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    var savee = dataContext.SaveChanges();
                    n.Commit();
                    return savee > 0;

                }
                catch (SqlException s)
                {
                    n.Rollback();
                    throw s;
                }
                catch (Exception e)
                {
                    n.Rollback();
                    throw e.InnerException ?? e;
                }
            }
        }

        public bool Delete(IEnumerable<T> entities)
        {
            using (var tran = dataContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in entities)
                    {
                        var obj = dbSet.Find(item);
                        var del = dbSet.Remove(obj);
                    }
                    var ok = dataContext.SaveChanges();
                    tran.Commit();
                    return ok > 0;
                }
                catch (SqlException s)
                {
                    throw s;
                }
                catch (Exception e)
                {
                    throw e.InnerException ?? e;
                }
            }
        }

        #endregion

        #endregion
    }
}

