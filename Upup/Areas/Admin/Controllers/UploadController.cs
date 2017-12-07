using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;

namespace Upup.Areas.Admin.Controllers
{

    public class UploadController : AdminControllerBase
    {
        public ActionResult SaveUploadedFile(string folderName) {
            var isSavedSuccessfully = true;
            var newFileName = string.Empty;
            var path = string.Empty;
            try {
                foreach (string fileName in Request.Files) {
                    var file = Request.Files[fileName];
                    //Save file content goes here
                    if (file != null && file.ContentLength > 0) {
                        
                        newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + "." + file.FileName.Split('.')[1];
                        var originalDirectory = new DirectoryInfo(string.Format("{0}Images", Server.MapPath(@"\")));

                        var pathString = Path.Combine(originalDirectory.ToString(), folderName);

                        var isExists = Directory.Exists(pathString);

                        if (!isExists)
                            Directory.CreateDirectory(pathString);

                        path = string.Format("{0}\\{1}", pathString, newFileName);
                        file.SaveAs(path);

                    }

                }

            } catch (Exception ex) {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully) {
                return Json(new { Message = newFileName, FilePath = path });
            } else {
                return Json(new { Message = "Error in saving file" });
            }
        }

        public void DeleteUploadedFile(string filePath)
        {
            if(System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        public void UploadNow(HttpPostedFileWrapper upload) {
            if (upload != null) {
                var imageName = upload.FileName;
                var path = Path.Combine(Server.MapPath("~/Images/UploadEditorImage"), imageName);
                upload.SaveAs(path);
            }
        }

        public ActionResult UploadPartial() {
            var appData = Server.MapPath("~/Images/UploadEditorImage");
            var images = Directory.GetFiles(appData).Select(x => new ImagesViewModel {
                Url = Url.Content("/images/UploadEditorImage/" + Path.GetFileName(x))
            });
            return View(images);
        }

        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            var path = string.Empty;
            //Save file content goes here
            if (upload != null && upload.ContentLength > 0)
            {
                var newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + "." + upload.FileName.Split('.')[1];
                var originalDirectory = new DirectoryInfo(string.Format("{0}Images", Server.MapPath(@"\")));

                var pathString = Path.Combine(originalDirectory.ToString(), "UploadedImages");

                var isExists = Directory.Exists(pathString);

                if (!isExists)
                    Directory.CreateDirectory(pathString);

                path = string.Format("{0}\\{1}", pathString, newFileName);
                upload.SaveAs(path);
                var message = "Hình ảnh đã được tải lên thành công";

                var url = string.Format("{0}/{1}", "/Images/UploadedImages/", newFileName); 

                // since it is an ajax request it requires this string
                string output = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\", \"" + message + "\");</script></body></html>";
                return Content(output);
            }
            return Json(new { Message = "Error in saving file" });
        }
    }
}
