using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class DataController : Controller
    {
        private MbrContext MbrContext = new MbrContext();

        /// <summary>
        /// 查詢頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var vm = new List<DataVM>();
            var datas = MbrContext.Data.ToList();  //後端連到資料庫，取得資料

            foreach (var data in datas)            //將資料打包成物件
            {
                vm.Add(new DataVM()
                {
                    Id = data.Id,
                    Context = data.Context
                });
            }
            return View(vm);                      //將物件回傳至前端
        }

        /// <summary>
        /// 新增頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 編輯頁面
        /// </summary>
        public ActionResult Edit(int id)          //撈取單一筆資料
        {
            var data = MbrContext.Data.FirstOrDefault(x => x.Id == id);
            var vm = new DataVM()                //進入該Action，做宣告
            {
                Id = data.Id,
                Context = data.Context
            };
            return View(vm);
        }
        /// <summary>
        /// 存取資料
        /// </summary>
        public ActionResult Access(DataDTO dto)
        {
            Data entity = null;
            switch (dto.AccessType)
            {
                case "Create":
                    MbrContext.Data.Add(new Data { Context = dto.Context });
                    break;

                case "Update":
                    entity = MbrContext.Data.FirstOrDefault(x => x.Id == dto.Id);
                    entity.Context = dto.Context;  //存取動作
                    break;

                case "Delete":
                    entity = MbrContext.Data.FirstOrDefault(x => x.Id == dto.Id);
                    MbrContext.Data.Remove(entity); //刪除資料
                    break;
            }
            MbrContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}