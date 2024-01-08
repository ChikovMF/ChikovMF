using System.ComponentModel.DataAnnotations;

namespace ChikovMF.MVC.Models.Form.Home
{
    public class MessageMeFormModel
    {
        [Display(Name = "Ваше имя")]
        public string? Name { get; set; }
        [Display(Name = "Ваши контакты")]
        public string? Contacts { get; set; }
        [Display(Name = "Ваше сообщение")]
        public string? Message { get; set; }
    }
}
