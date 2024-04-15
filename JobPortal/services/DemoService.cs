using JobPortal.Model;
using JobPortal.Repository;

namespace JobPortal.services
{
    public class DemoService
    {
        private readonly IDemo _demo;
        public DemoService(IDemo demo) 
        {
            _demo = demo;
        }

        public async Task<bool> InsertDemo(Demo demo)
        {
            return await _demo.InsertDemo(demo);
        }
    }
}
