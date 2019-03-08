using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace WebApplication1
{
    public interface ITransientService { }
    public interface IScopedService { }
    public interface IFilterEntity
    {
        int Take { get; set; }
        int Skip { get; set; }
    }
    #region Common
    public static class Common
    {
        public static readonly List<CommonHandler> Handlers;
        public static string Host { get; set; }
        private static string _Resource;
        public static string Resource
        {
            get
            {
                return _Resource;
            }
            set
            {
                object sync = new object();
                lock (sync)
                {
                    _Resource = value;
                    var init = BaseEntity.ErrorResource;
                }
            }
        }
        static Common()
        {
            Handlers = new List<CommonHandler>();

        }
        public static void Copy<T>(T From, T To)
        {
            List<PropertyInfo> sources = From.GetType().GetProperties().ToList();
            List<PropertyInfo> destinations = To.GetType().GetProperties().ToList();
            foreach (PropertyInfo source in sources)
                if ((!source.Name.ToLower().Equals("Cx".ToLower()) && !source.Name.ToLower().Equals("ClusteredIndex".ToLower())) && source.PropertyType.IsPublic)
                    if (source.PropertyType == typeof(Guid) ||
                        source.PropertyType == typeof(Guid?) ||
                        source.PropertyType == typeof(string) ||
                        source.PropertyType == typeof(int) ||
                        source.PropertyType == typeof(int?) ||
                        source.PropertyType == typeof(long) ||
                        source.PropertyType == typeof(long?) ||
                        source.PropertyType == typeof(byte) ||
                        source.PropertyType == typeof(byte[]) ||
                        source.PropertyType == typeof(byte?) ||
                        source.PropertyType == typeof(double) ||
                        source.PropertyType == typeof(double?) ||
                        source.PropertyType == typeof(decimal) ||
                        source.PropertyType == typeof(decimal?) ||
                        source.PropertyType == typeof(DateTime) ||
                        source.PropertyType == typeof(DateTime?) ||
                        source.PropertyType == typeof(Array) ||
                        source.PropertyType == typeof(bool) ||
                        source.PropertyType == typeof(bool?))
                    {
                        PropertyInfo destination = destinations.Where(d => d.Name.Equals(source.Name)).FirstOrDefault();
                        if (destination != null && destination.CanWrite && (
                            destination.PropertyType == typeof(Guid) ||
                            destination.PropertyType == typeof(Guid?) ||
                            destination.PropertyType == typeof(string) ||
                            destination.PropertyType == typeof(int) ||
                            destination.PropertyType == typeof(int?) ||
                            destination.PropertyType == typeof(long) ||
                            destination.PropertyType == typeof(long?) ||
                            destination.PropertyType == typeof(byte) ||
                            destination.PropertyType == typeof(byte[]) ||
                            destination.PropertyType == typeof(byte?) ||
                            destination.PropertyType == typeof(double) ||
                            destination.PropertyType == typeof(double?) ||
                            destination.PropertyType == typeof(decimal) ||
                            destination.PropertyType == typeof(decimal?) ||
                            destination.PropertyType == typeof(DateTime) ||
                            destination.PropertyType == typeof(DateTime?) ||
                            destination.PropertyType == typeof(Array) ||
                            destination.PropertyType == typeof(bool) ||
                            destination.PropertyType == typeof(bool?)
                        )) destination.SetValue(To, source.GetValue(From));
                    }
        }

        public static string ConvertToUnsign(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            string[] signs = new string[] {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };
            for (int i = 1; i < signs.Length; i++)
            {
                for (int j = 0; j < signs[i].Length; j++)
                {
                    str = str.Replace(signs[i][j], signs[0][i - 1]);
                }
            }

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c.Equals(' ') || ('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z') || c.Equals(',') || c.Equals('.') || ('0' <= c && c <= '9'))
                {
                    continue;
                }
                else
                {
                    str = str.Replace(c, ' ');
                }
            }
            return str;
        }

        //    public static bool Publish<T>(EmployeeEntity EmployeeEntity, string Type, T obj)
        //    {
        //        ConnectionFactory factory = new ConnectionFactory();
        //        factory.UserName = "dev";
        //        factory.Password = "dev";
        //        factory.HostName = "10.1.3.180";
        //        factory.Port = 5672;
        //        factory.VirtualHost = "/";
        //        factory.RequestedHeartbeat = 60;
        //        IConnection connection = factory.CreateConnection();
        //        IModel channel = connection.CreateModel();
        //        channel.ExchangeDeclare("Entities", ExchangeType.Fanout);
        //        channel.QueueDeclare(queue: "Center",
        //                             durable: true,
        //                             exclusive: false,
        //                             autoDelete: false,
        //                             arguments: null);
        //        channel.QueueBind("Center", "Entities", "", null);
        //        string message = JsonConvert.SerializeObject(obj);
        //        var body = Encoding.UTF8.GetBytes(message);
        //        IBasicProperties basicProperties = channel.CreateBasicProperties();
        //        basicProperties.Headers = new Dictionary<string, object>();
        //        basicProperties.Headers.Add("Type", Type);
        //        basicProperties.Headers.Add("JWT", EmployeeEntity.Token);
        //        channel.BasicPublish(exchange: "Entities",
        //                             routingKey: "",
        //                             basicProperties: basicProperties,
        //                             body: body);
        //        channel.Close(200, "Goodbye!");
        //        connection.Close();
        //        return true;
        //    }
    }
    #endregion

    #region CommonHandler
    public abstract class CommonHandler
        {
            public string Name { get; set; }
            public abstract void Handle(string json);
        }
        #endregion

        #region Enumeration
        public abstract class Enumeration : IComparable
        {
            public Guid Id { get; private set; }
            public string Code { get; private set; }
            public string Name { get; private set; }
            public int Order { get; private set; }
            protected Enumeration() { }
            protected Enumeration(Guid Id, string Code, string Name, int Order)
            {
                this.Id = Id;
                this.Code = Code;
                this.Name = Name;
                this.Order = Order;
            }

            public static int Count<T>() where T : Enumeration, new()
            {
                List<T> Ts = ToList<T>();
                return Ts.Count;
            }
            public static List<T> ToList<T>() where T : Enumeration, new()
            {
                var type = typeof(T);
                var fields = type.GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                List<T> result = new List<T>();
                foreach (var info in fields)
                {
                    var instance = new T();
                    var locatedValue = info.GetValue(instance) as T;
                    if (locatedValue != null)
                    {
                        result.Add(locatedValue);
                    }
                }
                return result;
            }

            public static T Get<T>(Guid Id) where T : Enumeration, new()
            {
                List<T> Ts = ToList<T>();
                foreach (T t in Ts)
                {
                    if (t.Id == Id)
                        return t;
                }
                return Ts.FirstOrDefault();
            }

            public static T Parse<T>(string arg) where T : Enumeration, new()
            {
                List<T> Ts = ToList<T>();
                foreach (T t in Ts)
                {
                    if (t.Code == arg)
                        return t;
                }
                return Ts.FirstOrDefault();
            }

            public override string ToString()
            {
                return Code;
            }

            public override bool Equals(object obj)
            {
                var otherValue = obj as Enumeration;
                if (otherValue == null) return false;
                var typeMatches = GetType().Equals(obj.GetType());
                var valueMatches = Id.Equals(otherValue.Id);
                return typeMatches && valueMatches;
            }
            public int CompareTo(object other)
            {
                return Id.CompareTo(((Enumeration)other).Id);
            }

            public override int GetHashCode()
            {
                var hashCode = 1460282102;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
                hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
                return hashCode;
            }
        }
        #endregion

        #region Base
        public abstract class Base : IEquatable<Base>
        {
            internal abstract string _Id { get; }
            [NotMapped]
            public bool Deleted { get; set; }
            public Base() { }
            public Base(object obj)
            {
                Common.Copy<object>(obj, this);
            }
            public bool Equals(Base other)
            {
                if (other == null) return false;
                else return other._Id.Equals(this._Id);
            }
        }

        public class BaseEntity
        {
            public bool Deleted { get; set; }
            private static object sync = new object();
            private static Dictionary<string, JObject> _ErrorResource;
            internal static Dictionary<string, JObject> ErrorResource
            {
                get
                {
                    if (_ErrorResource == null)
                    {
                        lock (sync)
                        {
                            _ErrorResource = new Dictionary<string, JObject>();
                            string folder = Common.Resource;
                            if (Directory.Exists(folder))
                            {
                                List<string> files = Directory.GetFiles(folder).ToList();
                                foreach (string file in files)
                                {
                                    string content = File.ReadAllText(file);
                                    ErrorResource.Add(Path.GetFileNameWithoutExtension(file), JObject.Parse(content));
                                }
                            }
                        }
                    }
                    return _ErrorResource;
                }
            }

            private string _ErrorPath;
            private string ErrorPath
            {
                get
                {
                    if (string.IsNullOrEmpty(_ErrorPath))
                        return this.GetType().Name;
                    else
                        return _ErrorPath;
                }
                set
                {
                    _ErrorPath = value + "." + this.GetType().Name;
                }
            }

            private string _BaseLanguage = "VIE";
            internal string BaseLanguage
            {
                get
                {
                    return _BaseLanguage;
                }
                set
                {
                    _BaseLanguage = value;
                    List<PropertyInfo> PropertyInfoes = this.GetType().GetProperties().ToList();
                    foreach (PropertyInfo PropertyInfo in PropertyInfoes)
                    {
                        if (PropertyInfo.PropertyType.IsGenericType && PropertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            IEnumerable<BaseEntity> BaseEntities = PropertyInfo.GetValue(this) as IEnumerable<BaseEntity>;
                            if (BaseEntities != null)
                                foreach (BaseEntity BaseEntity in BaseEntities)
                                {
                                    BaseEntity.ErrorPath = this.ErrorPath;
                                    BaseEntity.BaseLanguage = this._BaseLanguage;
                                }
                        }
                        if (PropertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntity)))
                        {
                            BaseEntity BaseEntity = PropertyInfo.GetValue(this) as BaseEntity;
                            if (BaseEntity != null)
                            {
                                BaseEntity.ErrorPath = this.ErrorPath;
                                BaseEntity.BaseLanguage = this._BaseLanguage;
                            }
                        }
                    }
                }
            }

            private bool _IsValidated = true;
            internal bool IsValidated
            {
                get
                {
                    if (Errors != null && Errors.Count > 0) return _IsValidated = false;
                    List<PropertyInfo> PropertyInfoes = this.GetType().GetProperties().ToList();
                    foreach (PropertyInfo PropertyInfo in PropertyInfoes)
                    {
                        if (PropertyInfo.PropertyType.IsGenericType && PropertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            IEnumerable<BaseEntity> BaseEntities = PropertyInfo.GetValue(this) as IEnumerable<BaseEntity>;
                            if (BaseEntities != null)
                                foreach (BaseEntity BaseEntity in BaseEntities)
                                {
                                    this._IsValidated = this._IsValidated & BaseEntity.IsValidated;
                                }
                        }
                        if (PropertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntity)))
                        {
                            BaseEntity BaseEntity = PropertyInfo.GetValue(this) as BaseEntity;
                            if (BaseEntity != null)
                            {
                                this._IsValidated = this._IsValidated & BaseEntity.IsValidated;
                            }
                        }
                    }
                    return this._IsValidated;
                }
            }

            public Dictionary<string, string> Errors { get; private set; }

            public BaseEntity()
            {
            }
            public BaseEntity(object obj)
            {
                if (Errors == null) Errors = new Dictionary<string, string>();
                Common.Copy(obj, this);
            }

            public void AddError(string Key, ERROR_CODE Value)
            {
                if (string.IsNullOrEmpty(BaseLanguage)) BaseLanguage = "VN";
                if (Errors == null) Errors = new Dictionary<string, string>();
                string content = "";
                try
                {
                    JToken token = ErrorResource[_BaseLanguage].SelectToken(ErrorPath + "." + Key + "." + Value.ToString());
                    content = token.ToString();
                }
                catch
                {
                    content = "Lack definition of " + ErrorPath + "." + Key + "." + Value.ToString();
                }

                if (Errors.ContainsKey(Key))
                    Errors[Key] = content;
                else
                    Errors.Add(Key, content);

            }
        }
        #endregion

        #region Exception
        public class ExceptionResponseAttribute : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                if (context.Exception is BadRequestException)
                {
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    response.ReasonPhrase = "Wrong paramenters";

                }
                if (context.Exception is ConflictException)
                {
                    response = new HttpResponseMessage(HttpStatusCode.Conflict);
                    response.ReasonPhrase = "Conflict data";
                }

                if (context.Exception is ForbiddenException)
                {
                    response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    response.ReasonPhrase = "Forbidden";
                }
                if (context.Exception is NotFoundException)
                {
                    response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    response.ReasonPhrase = "Not Found";
                }
                response.Content = new StringContent(context.Exception.Message);
                context.Response = response;
            }
        }
        public class BadRequestException : Exception
        {
            public BaseEntity BaseEntity { get; set; }
            private static string Convert(BaseEntity BaseEntity)
            {
                return JsonConvert.SerializeObject(BaseEntity);
            }
            private static string ConvertString(string Message)
            {
                object obj = new
                {
                    Message = Message
                };
                return JsonConvert.SerializeObject(obj);
            }
            public BadRequestException(string Message) : base(ConvertString(Message)) { }
            public BadRequestException(BaseEntity BaseEntity) : base(Convert(BaseEntity)) { }
        }

        public class ForbiddenException : Exception
        {
            public ForbiddenException(string Message) : base(Message) { }
        }

        public class NotFoundException : Exception
        {
            public NotFoundException() : base() { }
        }

        public class ConflictException : Exception
        {
            public ConflictException(string Message) : base(Message) { }
        }
        public class UnauthorizedException : Exception
        {
            public UnauthorizedException(string Message) : base(Message) { }
        }
        #endregion

        #region Filter
        public class FilterEntity : IFilterEntity
        {
            public Guid? CurrentUserId;
            public int Take { get; set; }
            public int Skip { get; set; }
            public FilterEntity()
            {
                if (Take == 0) Take = int.MaxValue;
                if (Skip == 0) Skip = 0;
            }

            public override string ToString()
            {
                string str = JsonConvert.SerializeObject(this);
                return str;
            }
        }

        public class StringFilter
        {
            // contains
            public string ct { get; set; }
            // not contains
            public string nc { get; set; }
            // starts with
            public string sw { get; set; }
            // ends with
            public string ew { get; set; }
            // equals
            public string eq { get; set; }
            // not equals
            public string ne { get; set; }
        }

        public class IntFilter
        {
            // less than
            public int? lt { get; set; }
            // less than or equals
            public int? le { get; set; }
            // greater than
            public int? gt { get; set; }
            // greater than or equals
            public int? ge { get; set; }
            // equals
            public int? eq { get; set; }
            // not equals
            public int? ne { get; set; }
        }

        public class DoubleFilter
        {
            // less than
            public double? lt { get; set; }
            // less than or equals
            public double? le { get; set; }
            // greater than
            public double? gt { get; set; }
            // greater than or equals
            public double? ge { get; set; }
            // equals
            public double? eq { get; set; }
            // not equals
            public double? ne { get; set; }
        }

        public class DecimalFilter
        {
            // less than
            public decimal? lt { get; set; }
            // less than or equals
            public decimal? le { get; set; }
            // greater than
            public decimal? gt { get; set; }
            // greater than or equals
            public decimal? ge { get; set; }
            // equals
            public decimal? eq { get; set; }
            // not equals
            public decimal? ne { get; set; }
        }

        public class DateFilter
        {
            // less than
            public DateTime? lt { get; set; }
            // less than or equals
            public DateTime? le { get; set; }
            // greater than
            public DateTime? gt { get; set; }
            // greater than or equals
            public DateTime? ge { get; set; }
            // equals
            public DateTime? eq { get; set; }
            // not equals
            public DateTime? ne { get; set; }
        }
        #endregion

        #region ERROR_CODE
        public enum ERROR_CODE
        {
            Empty,
            NotExisted,
            Existed,
            NoPermission,
            IsMax,
            IsMin,
            NoFormat,
            Used,
            NoChange,
            Duplicated,
            IsOver,
            HasReference
        }
        #endregion


    }