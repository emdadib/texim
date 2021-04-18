using texim.Data.DAL;
using texim.Data.IDAL;
using texim.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace texim.Data.Services
{
    public class TagService
    {
        // static IUnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());
        static IUnitOfWork unitOfWork;
        public TagService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public static async Task<IEnumerable<Tag>> GetTags()
        {
            return await unitOfWork.Repository<Tag>().GetAllAsync();
        }
        public static List<Tag> GetTagList()
        {
            return unitOfWork.Repository<Tag>().GetAll().ToList();
        }

        public static Tag GetTag(int id)
        {
            return unitOfWork.Repository<Tag>().GetById(id);
        }

        public static bool SeparateTagFromJson(string tags = "")
        {
            bool result = false;
            if (!string.IsNullOrEmpty(tags))
            {
                var tagsJson = JsonConvert.DeserializeObject<dynamic>(tags);
                foreach (var item in tagsJson)
                {
                    Tag tag = new Tag
                    {
                        TagName = Convert.ToString(item.tag)
                    };

                    try
                    {
                        result = SaveTag(tag);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        result = false;
                        return result;
                    }
                }

                return result;
            }
            else return result;

        }
        public static bool SaveTag(Tag model)
        {
            var result = unitOfWork.Repository<Tag>().Insert(model);
            if (result != null) return true;
            return false;
        }

        public static bool UpdateTag(int id, string tag)
        {
            Tag tagExist = GetTag(id);
            tagExist.TagName = tag;
            try
            {
                unitOfWork.Repository<Tag>().Update(tagExist);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
        public static async Task<bool> RemoveTag(int id)
        {
            Tag tagExist = GetTag(id);
            var result = await unitOfWork.Repository<Tag>().DeleteAsync(tagExist);
            if (result != 0) return true;
            return false;
        }

        public static async Task<bool> RemoveBlogTag(int id)
        {
            BlogTag tagExist = await unitOfWork.Repository<BlogTag>().GetByIdAsync(id);

            var result = await unitOfWork.Repository<BlogTag>().DeleteAsync(tagExist);
            if (result != 0) return true;
            return false;
        }


    }
}