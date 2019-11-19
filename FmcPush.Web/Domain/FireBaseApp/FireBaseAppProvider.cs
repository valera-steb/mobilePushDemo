using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;

namespace FmcPush.Web.Domain.FireBaseApp
{
    public interface IFireBaseAppProvider
    {
        FirebaseApp Get();
    }

    public class FireBaseAppProvider : IFireBaseAppProvider
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private FirebaseApp app;

        public FireBaseAppProvider(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }


        public FirebaseApp Get()
        {
            //if (app != null)
            //    return app;

            var credentials = GoogleCredential.FromFile(
                hostingEnvironment.ContentRootPath +
                //@"\Properties\test-fda53dfd531f.json" 
                @"\Properties\active-valve-125910-b1c581ae2447.json");
            return app = FirebaseApp.Create(new AppOptions { Credential = credentials });
        }
    }
}
