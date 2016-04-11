using System;
using System.Data.SqlClient;
using Tamir.SharpSsh;

namespace SKU_Manager.AdminModules.ImportUpdate
{
    /* 
     * An abstract class that define some fields and methods for all ImportUpdate channel classes
     */
    public abstract class ImportUpdate
    {
        // field for database connection
        protected readonly SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs);

        // field for sftp connection
        protected Sftp sftp;

        // field for showing the progress
        public int Total { get; protected set; } = 1;
        public int Current { get; protected set; }

        /* a method that update new channel's merchant sku from the excel import */
        public abstract void Update(string xlPath);

        #region Supporting Method
        /* a PUBLIC supporting method that set the given sku to discontine in database for sears */
        public abstract void Discontinue(string sku);

        /* a supporting method that create the po number for the channel */
        protected static string createPoNumber(string channelNo)
        {
            return channelNo + '-' + DateTime.Today.ToString("yyyyMMdd");
        }

        /* a supporting method that release the excel object */
        protected static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion
    }
}
