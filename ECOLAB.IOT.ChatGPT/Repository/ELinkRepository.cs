namespace ECOLAB.IOT.ChatGPT.Repository
{
    using Dapper;
    using ECOLAB.IOT.ChatGPT.Models.Entities;

    public interface IELinkRepository
    {
        public List<Data_Collection_History> GetList(string sqlStr = "SELECT TOP (10) *  FROM [dbo].[data_collection_history_202211]");
        public List<dynamic> GetListByDynamicSql(string sqlStr);
    }

    public class ELinkRepository: BaseRepository,IELinkRepository
    {
        public List<Data_Collection_History> GetList(string sqlStr = "SELECT TOP (10) *  FROM [dbo].[data_collection_history_202211]") {
            return Execute((conn) =>
            {
                var list = conn.Query<Data_Collection_History>(sqlStr).ToList();
                return list;
            });
        }


        public List<dynamic> GetListByDynamicSql(string sqlStr)
        {
            if (string.IsNullOrEmpty(sqlStr))
                return null;

            try
            {
                return Execute((conn) =>
                {
                    var list = conn.Query<dynamic>(sqlStr).ToList();
                    return list;
                });
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
