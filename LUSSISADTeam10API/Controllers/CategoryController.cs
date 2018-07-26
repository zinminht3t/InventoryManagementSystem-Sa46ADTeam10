using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace LUSSISADTeam10API.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        //to get all categories
        [HttpGet]
        [Route("api/Categories")]
        public IHttpActionResult GetAllCategory()
        {            
            string error = "";
            List<CategoryModel> catm = CategoryRepo.GetAllCategory(out error);
            // if the erorr is not blank or the category list is null
            if (error != "" || catm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Category Is Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(catm);
        }

        // to get category by category id
        [HttpGet]
        [Route("api/category/{catid}")]
        public IHttpActionResult GetCategoryByCatId(int catid)
        {
            string error = "";
            CategoryModel catm = CategoryRepo.GetCategoryByCatId(catid, out error);
            if (error != "" || catm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Category Is Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(catm);
        }

        //to get category by item id
        [HttpGet]
        [Route("api/category/item/{itemid}")]
        public IHttpActionResult GetCategoryByItemId(int itemid)
        {
            string error = "";
            CategoryModel catm = CategoryRepo.GetCategoryByItemId(itemid, out error);
            if (error != "" || catm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Category Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(catm);
        }

        // to get category by category name
        [HttpGet]
        [Route("api/category/{catname}")]
        public IHttpActionResult GetCategoryByCatName(string catname)
        {
            string error = "";
            CategoryModel cpm = CategoryRepo.GetCategorybyCatName(catname, out error);
            if (error != "" || cpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Category Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(cpm);
        }


        // to update category
        [HttpPost]
        [Route("api/category/update")]
        public IHttpActionResult UpdateCategory(CategoryModel cat)
        {
            string error = "";
            CategoryModel catm = CategoryRepo.UpdateCategory(cat, out error);
            if (error != "" || catm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Category Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(catm);
        }
        //to create category
        [HttpPost]
        [Route("api/category/create")]
        public IHttpActionResult CreateCategory(CategoryModel cat)
        {
            string error = "";
            CategoryModel catm =CategoryRepo.CreateCategory(cat, out error);
            if(error !="" || catm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(catm);
        }
    }
}