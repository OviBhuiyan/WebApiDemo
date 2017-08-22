using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Net;

namespace WebApiDemo
{
    //public class CustomJsonFormatter : JsonMediaTypeFormatter
    //{
    //    //Custom Media Type formetter
    //    public CustomJsonFormatter()
    //    {
    //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

    //    }

    //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    //    {
    //        base.SetDefaultContentHeaders(type, headers, mediaType);
    //        headers.ContentType = new MediaTypeHeaderValue("application/json");
    //    }
    //}

    //#region Custom Media Type CSV
    //public class CSVMediaTypeFormatter : MediaTypeFormatter
    //{

    //    public CSVMediaTypeFormatter()
    //    {

    //        SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
    //    }

    //    public CSVMediaTypeFormatter(
    //        MediaTypeMapping mediaTypeMapping) : this()
    //    {

    //        MediaTypeMappings.Add(mediaTypeMapping);
    //    }

    //    public CSVMediaTypeFormatter(
    //        IEnumerable<MediaTypeMapping> mediaTypeMappings) : this()
    //    {

    //        foreach (var mediaTypeMapping in mediaTypeMappings)
    //        {
    //            MediaTypeMappings.Add(mediaTypeMapping);
    //        }
    //    }

    //    public override bool CanReadType(Type type)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool CanWriteType(Type type)
    //    {
    //        if (type == null)
    //            throw new ArgumentNullException("type");

    //        return isTypeOfIEnumerable(type);
    //    }

    //    private bool isTypeOfIEnumerable(Type type)
    //    {

    //        foreach (Type interfaceType in type.GetInterfaces())
    //        {

    //            if (interfaceType == typeof(IEnumerable))
    //                return true;
    //        }

    //        return false;
    //    }

    //    //protected override Task OnWriteToStreamAsync(Type type,object value,Stream stream,HttpContentHeaders contentHeaders,TransportContext transportContext)
    //    //{

    //    //    writeStream(type, value, stream, contentHeaders);
    //    //    var tcs = new TaskCompletionSource<int>();
    //    //    tcs.SetResult(0);
    //    //    return tcs.Task;
    //    //}
    ////    protected override Task OnWriteToStreamAsync(
    ////Type type,
    ////object value,
    ////Stream stream,
    ////HttpContentHeaders contentHeaders,
    ////FormatterContext formatterContext,
    ////TransportContext transportContext)
    ////    {

    ////        writeStream(type, value, stream, contentHeaders);
    ////        var tcs = new TaskCompletionSource<int>();
    ////        tcs.SetResult(0);
    ////        return tcs.Task;
    ////    }

    //    private void writeStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders)
    //    {

    //        //NOTE: We have check the type inside CanWriteType method
    //        //If request comes this far, the type is IEnumerable. We are safe.

    //        Type itemType = type.GetGenericArguments()[0];

    //        StringWriter _stringWriter = new StringWriter();

    //        _stringWriter.WriteLine(
    //            string.Join<string>(
    //                ",", itemType.GetProperties().Select(x => x.Name)
    //            )
    //        );

    //        foreach (var obj in (IEnumerable<object>)value)
    //        {

    //            var vals = obj.GetType().GetProperties().Select(
    //                pi => new
    //                {
    //                    Value = pi.GetValue(obj, null)
    //                }
    //            );

    //            string _valueLine = string.Empty;

    //            foreach (var val in vals)
    //            {

    //                if (val.Value != null)
    //                {

    //                    var _val = val.Value.ToString();

    //                    //Check if the value contans a comma and place it in quotes if so
    //                    if (_val.Contains(","))
    //                        _val = string.Concat("\"", _val, "\"");

    //                    //Replace any \r or \n special characters from a new line with a space
    //                    if (_val.Contains("\r"))
    //                        _val = _val.Replace("\r", " ");
    //                    if (_val.Contains("\n"))
    //                        _val = _val.Replace("\n", " ");

    //                    _valueLine = string.Concat(_valueLine, _val, ",");

    //                }
    //                else
    //                {

    //                    _valueLine = string.Concat(string.Empty, ",");
    //                }
    //            }

    //            _stringWriter.WriteLine(_valueLine.TrimEnd(','));
    //        }

    //        var streamWriter = new StreamWriter(stream);
    //        streamWriter.Write(_stringWriter.ToString());
    //    }











    //}



    //#endregion



    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           // config.Formatters.Add(new CustomJsonFormatter());
           // config.Formatters.Add(new CSVMediaTypeFormatter());
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();



        }
    }
}
