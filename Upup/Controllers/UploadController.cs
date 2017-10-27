using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upup.Models;

namespace Upup.Controllers
{
    public class UploadController : Controller
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
    }
}
