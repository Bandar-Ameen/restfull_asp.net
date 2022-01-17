
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using System.Data;
using Newtonsoft.Json;
using AstoolTechRestFullAPI.Models;
using AstoolTechRestFullAPI.customclass;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Security.Principal;

namespace AstoolTechRestFullAPI.Controllers
{
    public class TestController : ApiController
    {
        //This resource is For all types of role
        [Authorize(Roles = "SuperAdmin, Admin, User")]     
        [HttpGet]
      
        [Route("api/test/resource1")]
        public IHttpActionResult GetResource1()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello: " + identity.Name);
        }
        //This resource is only For Admin and SuperAdmin role
      //  [Authorize(Roles = "SuperAdmin, Admin")]
       // 
       //هنا يتم التحقق إذا تم الدخول مع الاكسس توكن
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
      //  [baciAthuntication]
        [Route("api/test/resource2")]
        public IHttpActionResult GetResource2()
        {
            string hashedTokenId = this.Request.Headers.GetValues("usernamee").First();
            string hashedTokenId1 = this.Request.Headers.Authorization.Parameter.ToString();
            string title = "";
            string message = "";
            if (cechusernameActive(hashedTokenId).Equals(1))
            {
                var identity = (ClaimsIdentity)User.Identity;
                var Email = identity.Claims
                          .FirstOrDefault(c => c.Type == "Email").Value;
                var UserName = identity.Name;
                title = UserName;
                message = hashedTokenId1;
            }else if (cechusernameActive(hashedTokenId).Equals(0))
            {
                title = "موقف";
                message = "تم إقاف المستخدم";
            }
            else
            {
                title = "خطأ";
                message = "لا يوجد";
            }

            return Ok("" + title + "," + message);
 
        }
        //This resource is only For SuperAdmin role
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        [Route("api/test/resource3")]
        public IHttpActionResult GetResource3()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + "Your Role(s) are: " + string.Join(",", roles.ToList()));
        }


        //تسجيل مستخدم
        [Route("api/test/register")]
        public IHttpActionResult POSTregister()
        {
            
            string username = this.Request.Headers.GetValues("usernamee").First();
            string password = this.Request.Headers.GetValues("passwordd").First();
           // string hashedTokenId1 = this.Request.Headers.Authorization.Parameter.ToString();
            ClientMaster__Rf ddv = new ClientMaster__Rf();
            UserMaster mm = new UserMaster();

         
            ddv.ClientID = username;
            ddv.Active = true;
            ddv.ClientName = username + "1";
            ddv.RefreshTokenLifeTime = 170;
            ddv.AllowedOrigin = "*";
            mm.UserPassword = password;
            mm.UserName = username;
            mm.UserRoles = "Admin";
            mm.UserEmailID = "sss@ss.com";
            string scrit = Helper.GetHash(password);
            ddv.ClientSecret = scrit;
            Models.orderapiEntities1 context = new Models.orderapiEntities1();
            // Models.orderapiEntities context2 = new Models.orderapiEntities();
            string title = "ScritID";
            string message = scrit;
            if (cechusername(username, context))
            {
                context.ClientMaster__Rf.Add(ddv);
                context.UserMaster.Add(mm);

                context.SaveChanges();
              
              //  message = scrit;
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return StatusCode(HttpStatusCode.Found);
               // message = "موجود بالفعل";
            }
               
          
           
         
           
            
          
        }

     


  //دخول المستخدم وجلب الاكسس توكن
        private async Task<IHttpActionResult> loginAndGetAcessToken(string username,string password,string psswordwithname)
        {
            try {
              
                string type = "http://";
                if (HttpContext.Current.Request.IsSecureConnection)
                {
                    type = "https://";
                }
                string baseAddress = type+Request.RequestUri.Host+":"+Request.RequestUri.Port+"/Token";

                using (var client = new HttpClient())
                {
                    var form = new Dictionary<string, string>
               {
                   {"grant_type", "password"},
                   {"username",username},
                   {"password", password},
               };

                    client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Basic", psswordwithname);
                    var hh= client.PostAsync(baseAddress, new FormUrlEncodedContent(form)).Result;  
                    var token = hh.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                    string fff =  hh.RequestMessage.ToString();


                    var gg = (new Responselogin { AccessToken = token.AccessToken, TokenType = token.TokenType,clientid=token.clientid,expires=token.expires,
                        RefreshToken =token.RefreshToken,userName=token.userName,Error= "no error",
                        ExpiresIn=token.ExpiresIn});
                    return Ok(gg);

                }
            }
            catch (Exception ex)
            {
                 return StatusCode(HttpStatusCode.BadRequest);//Ok(new ResponsesLogin { scritkey = "vvvv", username = ex.Message });
            }
    }

     
        [AllowAnonymous]
        [HttpGet]
        [Route("api/test/login")]
        public async Task<IHttpActionResult>  POSTLogin()
        {
            try
            {
                string acess = this.Request.Headers.Authorization.Parameter;

                string decode = acess.DecodeBase64();

                string[] arraypass = decode.Split(':');
                string username = arraypass[0];
                string password = arraypass[1];
                ClientMaster__Rf ddv = new ClientMaster__Rf();
                UserMaster mm = new UserMaster();
                string scrit = Helper.GetHash(password);
                Models.orderapiEntities1 context = new Models.orderapiEntities1();
                string title = "ScritID";
                string message = scrit;
                if (!cechusername(username, scrit, password, context))
                {
                    if (!cechusernameActive(username).Equals(0))
                    {

                        string resultwith=username+":"+scrit;
                        string mmv = resultwith.EncodeBase64();
                        var ff = await loginAndGetAcessToken(username, password, mmv);


                        return ff;
                    }
                    else
                    {
                        return StatusCode(HttpStatusCode.Forbidden);
                    }
                }
                else
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }


            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }




        }

        //التاكيد من اسم المستخدم
        private bool cechusername(string usernamee, Models.orderapiEntities1 context)
        {
            try {
                var ddx = context.UserMaster.FirstOrDefault(t => t.UserName == usernamee);
                if (string.IsNullOrEmpty(ddx.UserName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {

                return true;
            }
            }

        //التاكيد من اسم المستخدم
        private bool cechusername(string usernamee,string scritky,string password ,Models.orderapiEntities1 context)
        {
            try
            {
                var ddx = context.UserMaster.FirstOrDefault(t => t.UserName == usernamee && t.UserPassword==password);
                if (string.IsNullOrEmpty(ddx.UserName))
                {
                    return true;
                }
                else
                {
                    string mmuser = usernamee+"1";
                    var ddx1 = context.ClientMaster__Rf.FirstOrDefault(t => t.ClientID == usernamee && t.ClientName == mmuser && t.ClientSecret==scritky);
                    if (string.IsNullOrEmpty(ddx1.ClientSecret))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (NullReferenceException)
            {

                return true;
            }
        }
        //التاكيد من تفعيل المستخدم
        private int cechusernameActive(string usernamee)
        {
            try
            {
                ClientMaster__Rf client = (new ClientMasterRepository()).ValidateClient(usernamee);

              

                if (client.Active)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                 
            }
            catch (NullReferenceException)
            {

                return 2;
            }
        }





        private orderapiEntities1 db = new orderapiEntities1();

        // GET: api/prodact
    /*    public IQueryable<prodactacoun> Getprodactacouns()
        {
            return db.prodactacouns;
        }*/



        //عرض جميع الاصناف

        //هنا يتم التحقق إذا تم الدخول مع الاكسس توكن
         [Authorize(Roles = "SuperAdmin, Admin")]
         [HttpGet]
        // [NoresponseCokie]
          [Route("api/test/prodactacouns")]

        public async Task<IHttpActionResult> Getprodactacouns()
        {

            
              string hashedTokenId = this.Request.Headers.GetValues("usernamee").First();
              string hashedTokenId1 = this.Request.Headers.Authorization.Parameter.ToString();
            MyAuthorizationServerProvider bb = new MyAuthorizationServerProvider();
            
          //  bb.AuthorizationEndpointResponse(this.RequestContext.Principal.Identity.AuthenticationType);
            //  AuthenticationRepository gg = new AuthenticationRepository();
          //  gg.Dispose();
            // AuthenticationManager.Unregister(AuthenticationManager.RegisteredModules.Current.ToString());//.Authenticate();
              string title = "";
              string message = "";
              if (cechusernameActive(hashedTokenId).Equals(1))
              {
                  
                return Ok(db.prodactacoun);
            }
              else if (cechusernameActive(hashedTokenId).Equals(0))
              {
               title = "موقف";
               message = "تم إقاف المستخدم";
            this.Request.Headers.Add("title",title);
            this.Request.Headers.Add("message", message);
            return StatusCode (HttpStatusCode.Forbidden);

            
            }
              else
              {
                title = "خطأ";
                message = "غير موجود المستخدم";
              this.Request.Headers.Add("title", title);
              this.Request.Headers.Add("message", message);
                return StatusCode(HttpStatusCode.NotFound);

                //  return Ok(new Respones { Status = title, Message = message });
            }
            
            //  return StatusCode(HttpStatusCode.NoContent);
          //  HttpActionContext bb = new HttpActionContext();
          // HttpContext.Current.SkipAuthorization = true;
            //this.ControllerContext.Configuration. = null;
            // return Ok(this.RequestContext.Principal.Identity.Name);

        }

      /*  [Authorize]
        [HttpPost]
        [Route("api/test/logout")]
        public void logoutt()
        {
            this.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
        }*/


        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost]
        [Route("api/test/prodactacouns")]

        public async Task<IHttpActionResult> POSTprodactacouns([FromBody] prodactacoun bb)
        {
             

            string hashedTokenId = this.Request.Headers.GetValues("usernamee").First();
            string hashedTokenId1 = this.Request.Headers.Authorization.Parameter.ToString();
            string title = "تم";
            string message = "تم الحفظ";
            if (cechusernameActive(hashedTokenId).Equals(1))
            {
                Models.orderapiEntities1 context = new Models.orderapiEntities1();
                if (cechprodactname(bb.namear, context))
                {
                    db.prodactacoun.Add(bb);
                    db.SaveChanges();
                    return StatusCode(HttpStatusCode.Created);
                }
                else
                {
                    return StatusCode(HttpStatusCode.Found);
                }
                
               

               
            }
            else if (cechusernameActive(hashedTokenId).Equals(0))
            {
                title = "موقف";
                message = "تم إيقاف المستخدم";
                this.Request.Headers.Add("title", title);
                this.Request.Headers.Add("message", message);
                return StatusCode(HttpStatusCode.Forbidden);


            }
            else
            {
                title = "خطأ";
                message = "غير موجود المستخدم";
                this.Request.Headers.Add("title", title);
                this.Request.Headers.Add("message", message);
                return StatusCode(HttpStatusCode.NotFound);

                //  return Ok(new Respones { Status = title, Message = message });
            }
            //  return StatusCode(HttpStatusCode.NoContent);
            //  return Ok("" + title + "," + message);

        }

        //هنا عملية الحذف
        /*http://localhost:11677/api/test/prodactacouns?bb=4044*/
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpDelete]
        [Route("api/test/prodactacouns")]
        public async Task<IHttpActionResult> Deleteprodactacouns(int bb)
        {


            string hashedTokenId = this.Request.Headers.GetValues("usernamee").First();
            string hashedTokenId1 = this.Request.Headers.Authorization.Parameter.ToString();
            string title = "تم";
            string message = "تم الحفظ";
            if (cechusernameActive(hashedTokenId).Equals(1))
            {
                Models.orderapiEntities1 context = new Models.orderapiEntities1();
                
                if (!cechprodactname(bb, context))
                {
                    prodactacoun prodactacoun = db.prodactacoun.Find(bb);
                    db.prodactacoun.Remove(prodactacoun);
                    db.SaveChanges();
                    return StatusCode(HttpStatusCode.OK);
                }
                else
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }




            }
            else if (cechusernameActive(hashedTokenId).Equals(0))
            {
                title = "موقف";
                message = "تم إيقاف المستخدم";
                this.Request.Headers.Add("title", title);
                this.Request.Headers.Add("message", message);
                return StatusCode(HttpStatusCode.Forbidden);


            }
            else
            {
                title = "خطأ";
                message = "غير موجود المستخدم";
                this.Request.Headers.Add("title", title);
                this.Request.Headers.Add("message", message);
                return StatusCode(HttpStatusCode.NotFound);

                //  return Ok(new Respones { Status = title, Message = message });
            }
            //  return StatusCode(HttpStatusCode.NoContent);
            //  return Ok("" + title + "," + message);

        }




        //هنا عملية التعديل
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPut]
        [Route("api/test/prodactacouns")]
        public async Task<IHttpActionResult> PUTprodactacouns([FromBody] prodactacoun dd,int bb)
        {


            string hashedTokenId = this.Request.Headers.GetValues("usernamee").First();
            string hashedTokenId1 = this.Request.Headers.Authorization.Parameter.ToString();
            string title = "تم";
            string message = "تم الحفظ";
            if (cechusernameActive(hashedTokenId).Equals(1))
            {
                Models.orderapiEntities1 context = new Models.orderapiEntities1();

                if (!cechprodactname(bb, context))
                {
                
                  // prodactacoun prodactacoun = db.prodactacouns.Find(bb);
                   // db.prodactacouns.Remove(prodactacoun);
                    db.Entry(dd).State = EntityState.Modified;
                    db.SaveChanges();
                    return StatusCode(HttpStatusCode.OK);
                }
                else
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }




            }
            else if (cechusernameActive(hashedTokenId).Equals(0))
            {
                title = "موقف";
                message = "تم إيقاف المستخدم";
                this.Request.Headers.Add("title", title);
                this.Request.Headers.Add("message", message);
                return StatusCode(HttpStatusCode.Forbidden);


            }
            else
            {
                title = "خطأ";
                message = "غير موجود المستخدم";
                this.Request.Headers.Add("title", title);
                this.Request.Headers.Add("message", message);
                return StatusCode(HttpStatusCode.NotFound);

                //  return Ok(new Respones { Status = title, Message = message });
            }
            //  return StatusCode(HttpStatusCode.NoContent);
            //  return Ok("" + title + "," + message);

        }


        //هناعملية جلب صنف معين

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        [Route("api/test/prodactacouns")]
        public IHttpActionResult Getprodactacoun(int bb)
        {
            prodactacoun prodactacoun = db.prodactacoun.Find(bb);
            if (prodactacoun == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            return Ok(prodactacoun);
        }

        private bool cechprodactname(string prodactnam, Models.orderapiEntities1 context)
        {
            try
            {
                var ddx = context.prodactacoun.FirstOrDefault(t => t.namear == prodactnam);
                if (string.IsNullOrEmpty(ddx.namear))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {

                return true;
            }
        }

        private bool cechprodactname(int prodactID, Models.orderapiEntities1 context)
        {
            try
            {
                var ddx = context.prodactacoun.FirstOrDefault(t => t.ID == prodactID);
                if (string.IsNullOrEmpty(ddx.namear))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {

                return true;
            }
        }



        //هنا إرسال البيانات علي شكل json من العميل الي السرفر
        [HttpGet]
        [Route("api/test/resource1v")]
        public IHttpActionResult Getmyarry([FromBody]JArray aray)
        {
          string bb;
            DataTable dattabkle = (DataTable)JsonConvert.DeserializeObject(aray.ToString(), (typeof(DataTable)));
            // aray.Count().ToString();
            string mmnamee="";
            for(int aa = 0; aa < dattabkle.Rows.Count; aa++)
            {
                if (aa == 2)
                {
                    mmnamee = dattabkle.Rows[aa][1].ToString();
                }
              //  mmnamee = dattabkle.Rows[aa][0].ToString();
                  //  mmnamee = dattabkle.Rows[aa][1].ToString();
               // }
               
            }
            return Ok("Hello:"+ dattabkle.Rows.Count + ": " + mmnamee);
        }




    }

  
}
