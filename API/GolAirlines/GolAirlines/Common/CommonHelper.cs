using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GolAirlines.Common
{
    public class CommonHelper
    {
        private static CommonHelper _instance;

        public static CommonHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommonHelper();
                }

                return _instance;
            }
        }

        private CommonHelper()
        {

        }

        public string SerializerObjectToJson(object obj)
        {
            var convertObjToJson = JsonConvert.SerializeObject(
            obj,
            Newtonsoft.Json.Formatting.None,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });

            return convertObjToJson;
        }

        public T DeserializerJsonToObject<T>(string obj)
        {
            var convertJsonToObj = JsonConvert.DeserializeObject<T>(obj);
            return convertJsonToObj;
        }

        public List<T> DeserializerJsonToListObject<T>(string obj)
        {
            var convertJsonToObj = JsonConvert.DeserializeObject<List<T>>(obj);
            return convertJsonToObj;
        }

        public T BuildResultComponent<T>(object obj)
        {
            object objCurrent = null;
            try
            {
                if (obj != null)
                {
                    var typeObj = typeof(T);
                    var fullName = typeObj.FullName;
                    Assembly assem = typeObj.Assembly;
                    objCurrent = assem.CreateInstance(fullName);

                    var convertToJson = CommonHelper.Instance.SerializerObjectToJson(obj);
                    if (!string.IsNullOrEmpty(convertToJson))
                    {
                        var convertJsonToObj = CommonHelper.Instance.DeserializerJsonToObject<T>(convertToJson);
                        if (convertJsonToObj != null)
                        {
                            objCurrent = convertJsonToObj;
                        }
                    }
                }
                return (T)Convert.ChangeType(objCurrent, typeof(T));
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }
    }
}
