namespace ECOLAB.IOT.ChatGPT.Common
{
    using ECOLAB.IOT.ChatGPT.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Reflection;
    using System.Text;

    public static class Utilities
    {
        public static string DynamicToCSVString<T>(this List<T> values)
        {
            if (values == null || values.Count==0)
                return null;

            StringBuilder sb_Text = new StringBuilder();
            sb_Text.Append(PickUpHeader(JsonConvert.SerializeObject(values[0]))).Append("\n"); 
            foreach (T value in values)
            {
                var csvValue = PickUpRowValue(JsonConvert.SerializeObject(value));
                if (sb_Text.Length + csvValue.Length >= 4000)
                {
                    break;
                }

                sb_Text.Append(csvValue).Append("\n");
               
            }
            
            return sb_Text.ToString();
        }

        private static string PickUpHeader(string str)
        {
            StringBuilder strColumn = new StringBuilder();
            var jObject = JObject.Parse(str);

            var propertyies = jObject.Properties();
            foreach (var property in propertyies)
            {
                strColumn.Append(property.Name).Append(",");
            }

            return strColumn.ToString().Substring(0, strColumn.Length - 1);
        }

        private static string PickUpRowValue(string str)
        {
            StringBuilder strValue = new StringBuilder();
            var jObject = JObject.Parse(str);

            var propertyies = jObject.Properties();
            foreach (var property in propertyies)
            {
                strValue.Append(property.Value).Append(",");
            }

            return strValue.ToString().Substring(0,strValue.Length-1);
        }

        public static string ToCSVString<T>(this List<T> values)
        {
            if (values == null)
                return null;
            StringBuilder sb_Text = new StringBuilder();
            StringBuilder strColumn = new StringBuilder();
            StringBuilder strValue = new StringBuilder();
            var tp = typeof(T);
            PropertyInfo[] props = tp.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            try
            {
                for (int i = 0; i < props.Length; i++)
                {
                    var itemPropery = props[i];
                    AttrForCsvColumnLabel labelAttr = itemPropery.GetCustomAttributes(typeof(AttrForCsvColumnLabel), true).FirstOrDefault() as AttrForCsvColumnLabel;
                    if (labelAttr != null && labelAttr.Ignore == true)
                    {
                        continue;
                    }
                    strColumn.Append(props[i].Name);
                    strColumn.Append(",");
                }
                strColumn.Remove(strColumn.Length - 1, 1);
                strColumn.Append("\n");
                sb_Text.AppendLine(strColumn.ToString());

                for (int i = 0; i < values.Count; i++)
                {
                    var model = values[i];
                    strValue.Clear();
                    var firstIndex = 0;
                    for (int m = 0; m < props.Length; m++)
                    {
                        var itemPropery = props[m];
                        AttrForCsvColumnLabel labelAttr = itemPropery.GetCustomAttributes(typeof(AttrForCsvColumnLabel), true).FirstOrDefault() as AttrForCsvColumnLabel;
                        if (labelAttr != null && labelAttr.Ignore == true)
                        {
                            continue;
                        }
                        var val = itemPropery.GetValue(model, null);
                        if (firstIndex == 0)
                        {
                            strValue.Append(val);
                        }
                        else
                        {
                            strValue.Append(",");
                            strValue.Append(val);
                        }

                        firstIndex++;
                    }

                    if (firstIndex != props.Length - 1)
                    {
                        strValue.Append("\n");
                    }

                    if (sb_Text.Length + strValue.Length >=4000)
                    {
                        break;
                    }

                    sb_Text.AppendLine(strValue.ToString());
                }

                return sb_Text.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
