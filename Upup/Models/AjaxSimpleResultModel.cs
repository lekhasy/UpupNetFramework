namespace Upup.Models
{
    public class AjaxSimpleResultModel
    {
        public bool ResultValue { get; set; }
        public string Message { get; set; }
    }
    public class AjaxSimpleResultModel<T> : AjaxSimpleResultModel
    {
        public T Data { get; set; }
    }
}