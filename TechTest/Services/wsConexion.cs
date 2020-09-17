using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TechTest.Services
{
	public class wsConexion
	{
        public string Respuesta = string.Empty;
        public async Task<string> GetDataRestAsync(string moviestype)
        {
            //ResponseBase<T> ro = new ResponseBase<T>();
            try
            {
              
                //string urlbase = String.Format("http://192.168.1.70:8045/Service1.svc/");
                //urlbase = urlbase + method;
                using (HttpClient client = new HttpClient())
                {
                   
                    using (HttpResponseMessage res = await client.GetAsync("https://api.themoviedb.org/3/movie/"+ moviestype + "?api_key=2c6be4393fe87c4526caff5678154649&language=en-US&page=1"))
                    {
                        Respuesta = res.Content.ReadAsStringAsync().Result;
                        return Respuesta;
                        //JsonConvert.PopulateObject(tem, ro);
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }

		internal async Task<string> GetDataRestAsyncCredits(int iMovie)
		{
            //ResponseBase<T> ro = new ResponseBase<T>();
            try
            {

                //string urlbase = String.Format("http://192.168.1.70:8045/Service1.svc/");
                //urlbase = urlbase + method;
                using (HttpClient client = new HttpClient())
                {

                    using (HttpResponseMessage res = await client.GetAsync("https://api.themoviedb.org/3/movie/" + iMovie + " /credits?api_key=2c6be4393fe87c4526caff5678154649&language=en-US&page=1"))
                    {
                        Respuesta = res.Content.ReadAsStringAsync().Result;
                        return Respuesta;
                        //JsonConvert.PopulateObject(tem, ro);
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
	}
}
