using texim.Data;
using texim.Helper;
using texim.Data.DAL;
using texim.Data.IDAL;
using texim.Models;
using texim.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using texim.Areas.Admin.Models;

namespace texim.Logic.Services
{
    public class BlogService
    {
        static IUnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        public static async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await unitOfWork.Repository<Blog>().FindAllAsync(x => x.Status);
        }
        public static Blog GetBlog(int id)
        {
            return unitOfWork.Repository<Blog>().GetById(id);
        }
        public static Blog GetBlogBySlug(string slug = "")
        {
            return unitOfWork.Repository<Blog>().Find(x => x.Slug == slug && x.Status);
        }

        public static Blog GetBlogForPreviewBySlug(string slug = "")
        {
            return unitOfWork.Repository<Blog>().Find(x => x.Slug == slug);
        }
        public static async Task<int> SaveBlog(Blog model)
        {
            model.BlogKey = Guid.NewGuid();
            model.PostedAt = DateTime.Now;
            model.LastModified = DateTime.Now;
            var result = await unitOfWork.Repository<Blog>().InsertAsync(model);
            if (result != null) return result.BlogId;
            return 0;
        }
        public static async Task<bool> UpdateBlog(Blog model)
        {
            Blog blog = GetBlog(model.BlogId);
            if (blog == null) return false;

            blog.LastModified = DateTime.Now;
            blog.BigDetails = model.BigDetails;
            blog.SubTitle = model.SubTitle;
            blog.BlogCategoryId = model.BlogCategoryId;
            blog.SmallDetails = model.SmallDetails;
            blog.Status = model.Status;
            blog.Title = model.Title;
            blog.Slug = model.Slug;
            blog.PublishDate = model.PublishDate;
            blog.Image = !string.IsNullOrEmpty(model.Image) ? model.Image : blog.Image;
            blog.FeaturedImage = !string.IsNullOrEmpty(model.FeaturedImage) ? model.FeaturedImage : blog.FeaturedImage;
            blog.Video = !string.IsNullOrEmpty(model.Video) ? model.Video : blog.Video; ;
            blog.AuthorName = model.AuthorName;
            blog.AboutAuthor = model.AboutAuthor;

            //SEO
            blog.Keyword = model.Keyword;
            blog.MetaDescription = model.MetaDescription;
            blog.MetaTitle = model.MetaTitle;
            blog.OgTitle = model.OgTitle;
            blog.OgDescription = model.OgDescription;
            blog.Canonical = model.Canonical;
            blog.OgImage = !string.IsNullOrEmpty(model.OgImage) ? model.OgImage : blog.OgImage;



            var result = await unitOfWork.Repository<Blog>().UpdateAsync(blog);
            if (result != null) return true;
            return false;
        }

        public static BlogViewModel GetBlogViewModel(int id)
        {
            var blog = GetBlog(id);
            BlogViewModel blogVm = new BlogViewModel();
            if (blog == null) return blogVm;

            blogVm.BigDetails = blog.BigDetails;
            blogVm.SubTitle = blog.SubTitle;
            blogVm.BlogCategoryId = blog.BlogCategoryId;
            blogVm.SmallDetails = blog.SmallDetails;
            blogVm.Status = blog.Status;
            blogVm.Title = blog.Title;
            blogVm.Slug = blog.Slug;
            blogVm.PublishDate = blog.PublishDate;
            blogVm.Image = blog.Image;
            blogVm.FeaturedImage = blog.FeaturedImage;
            blogVm.Video = blog.Video;
            blogVm.AuthorName = blog.AuthorName;
            blogVm.AboutAuthor = blog.AboutAuthor;

            //SEO
            blogVm.Keyword = blog.Keyword;
            blogVm.MetaDescription = blog.MetaDescription;
            blogVm.MetaTitle = blog.MetaTitle;
            blogVm.OgTitle = blog.OgTitle;
            blogVm.OgDescription = blog.OgDescription;
            blogVm.Canonical = blog.Canonical;
            blogVm.OgImage = blog.OgImage;

            return blogVm;
        }
        public static Blog BlogViewModelToModel(BlogViewModel viewModel)
        {

            Blog blog = new Blog
            {
                BlogId = viewModel.BlogId,

                LastModified = DateTime.Now,
                BigDetails = viewModel.BigDetails,
                SubTitle = viewModel.SubTitle,
                BlogCategoryId = viewModel.BlogCategoryId,
                SmallDetails = viewModel.SmallDetails,
                Status = viewModel.Status,
                Title = viewModel.Title,
                Slug = viewModel.Slug,
                PublishDate = viewModel.PublishDate.HasValue ? viewModel.PublishDate.Value : DateTime.Now,
                Image = viewModel.Image,
                FeaturedImage = viewModel.FeaturedImage,
                Video = viewModel.Video,
                AuthorName = viewModel.AuthorName,
                AboutAuthor = viewModel.AboutAuthor,

                //SEO
                Keyword = viewModel.Keyword,
                MetaDescription = viewModel.MetaDescription,
                MetaTitle = viewModel.MetaTitle,
                OgTitle = viewModel.OgTitle,
                OgDescription = viewModel.OgDescription,
                Canonical = viewModel.Canonical,
                OgImage = viewModel.OgImage
            };

            return blog;
        }

        public static BlogViewModel BlogModelToViewModel(Blog blog)
        {

            BlogViewModel blogVm = new BlogViewModel
            {
                BlogId = blog.BlogId,
                BigDetails = blog.BigDetails,
                SubTitle = blog.SubTitle,
                BlogCategoryId = blog.BlogCategoryId,
                SmallDetails = blog.SmallDetails,
                Status = blog.Status,
                Title = blog.Title,
                Slug = blog.Slug,
                PublishDate = blog.PublishDate,
                Image = blog.Image,
                FeaturedImage = blog.FeaturedImage,
                Video = blog.Video,
                AuthorName = blog.AuthorName,
                AboutAuthor = blog.AboutAuthor,

                //SEO
                Keyword = blog.Keyword,
                MetaDescription = blog.MetaDescription,
                MetaTitle = blog.MetaTitle,
                OgTitle = blog.OgTitle,
                OgDescription = blog.OgDescription,
                Canonical = blog.Canonical,
                OgImage = blog.OgImage,
                //Tags
                TagList = GetBlogTags(blog.BlogId)
            };

            return blogVm;
        }
        public static List<Blog> BlogByCategory(int catId)
        {
            List<Blog> BlogList = new List<Blog>();
            List<Blog> blogs = unitOfWork.Repository<Blog>().FindAll(x => x.BlogCategoryId == catId).ToList();
            foreach (var blog in blogs)
            {
                BlogList.Add(blog);
            }

            return BlogList;
        }
        public static CategoryWithBlog GetCategoryWithBlogs(string slug)
        {
            List<Blog> BlogList = new List<Blog>();
            var category = BlogCategoryService.GetCategoryBySlug(slug);

            List<Blog> Blogs = unitOfWork.Repository<Blog>().FindAll(x => x.BlogCategoryId == category.BlogCategoryId).Where(x => x.Status).ToList();
            foreach (var blog in Blogs)
            {
                BlogList.Add(blog);
            }
            CategoryWithBlog cwb = new CategoryWithBlog
            {
                CategoryName = category.CategoryName,
                Slug = category.Slug,
                Keyword = category.Keyword,
                BlogCategoryId = category.BlogCategoryId,
                MetaDescription = category.MetaDescription,
                MetaTitle = category.MetaTitle,
                Canonical = category.Canonical,
                OgDescription = category.OgDescription,
                OgImage = category.OgImage,
                OgTitle = category.OgTitle,
                Blogs = BlogList,
                Status = category.Status
            };
            return cwb;
        }

        public static async Task<bool> RemoveBlog(Blog model)
        {
            var result = await unitOfWork.Repository<Blog>().DeleteAsync(model);
            if (result != 0) return true;
            return false;
        }

        public static List<BlogTag> GetBlogTags(int blogId)
        {
            return unitOfWork.Repository<BlogTag>().FindAll(x => x.BlogId == blogId).ToList() ?? new List<BlogTag>();
        }

        public static async Task<bool> BlogTagSave(string[] tags, int blogId)
        {

            BlogTag blogTag = new BlogTag();
            foreach (var i in tags)
            {
                blogTag.BlogId = blogId;
                blogTag.TagName = i;
                blogTag.Slug = SlugHelper.GetEncodedTitle(i);

                try
                {
                    await unitOfWork.Repository<BlogTag>().InsertAsync(blogTag);
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;

        }

        //public static async Task<bool> BlogTagUpdate(string[] tags, int blogId)
        //{
        //    var blogTags = GetBlogTags(blogId);
        //    foreach (var item in blogTags)
        //    {
        //        if (!tags.Contains(item.TagName))
        //        {
        //          await BlogTagRemove(item);
        //        }
        //        else
        //        {

        //        }
        //    }

        //}

        public static async Task<int> BlogTagRemove(BlogTag blogTag)
        {
            return await unitOfWork.Repository<BlogTag>().DeleteAsync(blogTag);
        }

        #region Web
        public static IEnumerable<Blog> GetTopBlogs()
        {
            return unitOfWork.Repository<Blog>().FindAll(x => x.Status).OrderByDescending(x => x.PublishDate).Take(5);
        }

        public static IEnumerable<Blog> GetCategoryWiseBlogs(int categoryId)
        {
            return unitOfWork.Repository<Blog>().FindAll(x => x.Status && x.BlogCategoryId == categoryId).OrderByDescending(x => x.PublishDate).Take(5);
        }

        #endregion



    }
}