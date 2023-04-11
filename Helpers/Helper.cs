using dbLogServices.Common;
using Newtonsoft.Json;
using dbLogServices.Models;

namespace dbLogServices.Helpers
{
    public class Helper
    {
       
       
        public Result PostData(string endPoint, string PostedData)
        {
            string _url = GlobalClass.URL;

            StreamReader sr = null;
            System.Net.WebRequest req = null;
            System.Net.WebResponse rsp = null;

            string resopse2 = "";

            Result r = new Result();

            try
            {
                string uri = _url + endPoint;
                req = System.Net.WebRequest.Create(uri);
                req.Headers.Add("Authorization", "Bearer " + StaticData.APIToken);
                req.Method = "POST";
                req.ContentType = "application/json; charset=utf-8";
                req.Timeout = Timeout.Infinite;
                //req.KeepAlive = true;

                System.IO.StreamWriter writer = new System.IO.StreamWriter(req.GetRequestStream());
                writer.WriteLine(PostedData);
                writer.Close();

                rsp = req.GetResponse();

                using (rsp = req.GetResponse())
                {
                    if (rsp != null)
                    {
                        //if main url response then this code execute
                        sr = new StreamReader(rsp.GetResponseStream(), System.Text.Encoding.Default);

                        if (sr != null)
                        {
                            resopse2 = sr.ReadToEnd();
                            r = JsonConvert.DeserializeObject<Result>(resopse2);

                            r.Data = resopse2;

                            sr.Close();
                            sr.Dispose();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message = "API POST FAIL:" + ex.Message + Environment.NewLine + _url + endPoint;
                r.Data = "";

                if (ex.Message == "The remote server returned an error: (401) Unauthorized." || ex.Message.Contains("401"))
                {
                    Result rToken = GetToken();
                    if (!rToken.Status)
                    {
                        r.Message = r.Message + Environment.NewLine + rToken.Message;
                    }
                    else
                    {
                        r = PostData(endPoint, PostedData);
                    }
                }
                //throw;

            }
            finally
            {
            }

            return r;

        }

        public Result GetData(string endPoint)
        {
            string _url = GlobalClass.URL;
            System.Net.WebRequest req = null;

            Result r = new Result();
            try
            {
                string uri = _url + endPoint;
                req = System.Net.WebRequest.Create(uri);
                req.Headers.Add("Authorization", "Bearer " + StaticData.APIToken);
                req.Method = "GET";
                req.Timeout = Timeout.Infinite;

                using (System.Net.WebResponse response = req.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var objText = reader.ReadToEnd();
                        r = JsonConvert.DeserializeObject<Result>(objText);
                    }
                }

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message = "API POST FAIL:" + ex.Message + Environment.NewLine + _url + endPoint;
                r.Data = "";

                if (ex.Message == "The remote server returned an error: (401) Unauthorized." || ex.Message.Contains("401"))
                {
                    Result rToken = GetToken();
                    if (!rToken.Status)
                    {
                        r.Message = r.Message + Environment.NewLine + rToken.Message;
                    }
                    else
                    {
                        r = GetData(endPoint);
                    }
                }

            }


            return r;

        }

        public Result GetToken()
        {

            string userName = GlobalClass.APIUserName;
            string password =GlobalClass.APIPassword;

            string _url = GlobalClass.URL + "/token";

            StreamReader sr = null;
            System.Net.WebRequest req = null;
            System.Net.WebResponse rsp = null;

            string resopse2 = "";

            Result r = new Result();

            try
            {
                string uri = _url + "?username=" + userName + "&password=" + password;
                req = System.Net.WebRequest.Create(uri);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.Timeout = 10000;
                req.ContentLength = 0;
                

                using (rsp = req.GetResponse())
                {
                    if (rsp != null)
                    {
                        //if main url response then this code execute
                        sr = new StreamReader(rsp.GetResponseStream(), System.Text.Encoding.Default);

                        if (sr != null)
                        {
                            resopse2 = sr.ReadToEnd();
                            r.Status = true;

                            User serverResult =JsonConvert.DeserializeObject<User>(resopse2);
                            StaticData.APIToken = serverResult.token;
                            StaticData.APIUserName = serverResult.username;

                            sr.Close();
                            sr.Dispose();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                //throw;
                r.Status = false;
                r.Message = "API POST FAIL:" + ex.Message + Environment.NewLine + _url;
                r.Data = "";
            }
            finally
            {
            }
            return r;
        }

    }
}
