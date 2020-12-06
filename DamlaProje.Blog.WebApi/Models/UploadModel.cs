using DamlaProje.Blog.WebApi.Enums;

namespace DamlaProje.Blog.WebApi.Models
{
    public class UploadModel
    {
        public string NewName { get; set; }
        public string ErrorMessage { get; set; }
        public UploadState UploadState { get; set; }
    }
}
