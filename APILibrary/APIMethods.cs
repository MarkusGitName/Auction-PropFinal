﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace APILibrary
{
    public class APIMethods
    {
      //  public static string url = "https://auction-prop-api.azurewebsites.net/api/";
       // public static string url = "https://localhost:44320/api/";
        public static string url = "http://api.auction-prop.com/api/";
      // public static string url = "https://localhost:44320/api/";


        public static T APIPost<T>(object model, string APIAddress)
        {
            object ad = new object();
            string ResponseString = "";
            HttpWebResponse response = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url + APIAddress);
                request.Accept = "application/json"; //"application/xml"; 
                request.Method = "POST";

                JavaScriptSerializer jss = new JavaScriptSerializer();
                // serialize into json string 
                var myContent = jss.Serialize(model);

                var data = Encoding.ASCII.GetBytes(myContent);

                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                response = (HttpWebResponse)request.GetResponse();

                ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                ad = jss.Deserialize<T>(ResponseString);
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)ex.Response;
                    throw new Exception(ResponseString = "Some error occured: " + response.StatusCode.ToString());

                }
                else
                {

                    throw new Exception(ResponseString = "Some error occured: " + response.StatusCode.ToString());
                }
            }
            if (response.StatusCode == HttpStatusCode.Created)
            {
                //int a = ad.AddressID;
                return (T)ad;
            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {

                return (T)ad;

            }
            else
            {
                // return ResponseString;
                return (T)ad;

            }
        }

        public static T APIGet<T>(string id, string APIAddress)
        {
            //  try
            //     {
            // TODO: Add insert logic here

            object model = new object();
            string ResponseString = "";
            HttpWebResponse response = null;
        
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url + APIAddress + "/" + id);
                request.Accept = "application/json"; //"application/xml"; 
                request.Method = "GET";

                JavaScriptSerializer jss = new JavaScriptSerializer();


                response = (HttpWebResponse)request.GetResponse();

                ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                model = jss.Deserialize<T>(ResponseString);

            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)ex.Response;
                    ResponseString = "Some error occured: " + response.StatusCode.ToString();
                }
                else
                {
                    ResponseString = "Some error occured: " + ex.Status.ToString();
                }
            }
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (T)model;
            }
            else
            {
                throw new Exception(""+response.StatusCode);

            }
        }

        public static T APIPut<T>(object model, string id, string APIAddress)
        {
            object ad = new object();
            string ResponseString = "";
            HttpWebResponse response = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url + APIAddress + "/" + id);
                request.Accept = "application/json"; //"application/xml"; 
                request.Method = "PUT";

                JavaScriptSerializer jss = new JavaScriptSerializer();
                // serialize into json string 
                var myContent = jss.Serialize(model);

                var data = Encoding.ASCII.GetBytes(myContent);

                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                response = (HttpWebResponse)request.GetResponse();

                ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                ad = jss.Deserialize<T>(ResponseString);
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)ex.Response;
                    throw new Exception(ResponseString = "Some error occured: " + response.StatusCode.ToString());

                }
                else
                {

                    throw new Exception(ResponseString = "Some error occured: " + response.StatusCode.ToString());
                }
            }
            if (response.StatusCode == HttpStatusCode.Created)
            {
                //int a = ad.AddressID;
                return (T)ad;
            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {

                return (T)ad;

            }
            else
            {
                // return ResponseString;
                return (T)ad;

            }

        }

        public static T APIDelete<T>(string id, string APIAddress)
        {
            object ad = new object();
            string ResponseString = "";
            HttpWebResponse response = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url + APIAddress + "/" + id);
                request.Accept = "application/json"; //"application/xml"; 
                request.Method = "DELETE";

                JavaScriptSerializer jss = new JavaScriptSerializer();
                // serialize into json string 


                response = (HttpWebResponse)request.GetResponse();

                ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                ad = jss.Deserialize<T>(ResponseString);
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)ex.Response;
                    throw new Exception(ResponseString = "Some error occured: " + response.StatusCode.ToString());

                }
                else
                {

                    throw new Exception(ResponseString = "Some error occured: " + response.StatusCode.ToString());
                }
            }
            if (response.StatusCode == HttpStatusCode.Created)
            {
                //int a = ad.AddressID;
                return (T)ad;
            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {

                return (T)ad;

            }
            else
            {
                // return ResponseString;
                return (T)ad;

            }

        }


        public static T APIGetALL<T>( string APIAddress)
        {
            //  try
            //     {
            // TODO: Add insert logic here

            object model = new object();
            string ResponseString = "";
         HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(url + APIAddress );
         
            try
            {   
            request.Accept = "application/json"; //"application/xml"; 
            request.Method = "GET";

                 JavaScriptSerializer jss = new JavaScriptSerializer();


                    jss.MaxJsonLength = 10 * 2024 * 2024;
                response = (HttpWebResponse)request.GetResponse();

                ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                model = jss.Deserialize<T>(ResponseString);

            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)ex.Response;
                    ResponseString = "Some error occured: " + response.StatusCode.ToString();
                }
                else
                {
                    ResponseString = "Some error occured: " + ex.Status.ToString();
                }
            }
            catch(NullReferenceException ex)
            {

                ResponseString = "Some error occured: " + ex.ToString();
            }
            catch(System.StackOverflowException Stack)
            {

            }
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (T)model;
            }
            else
            {
                throw new Exception(response.StatusDescription+ url + APIAddress);

            }
        }

    }
}

