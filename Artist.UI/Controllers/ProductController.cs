using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Artist.DAO.Implementations;
using Artist.DAO.EntityFrameWork;
using Artist.UI.ViewModels;

namespace Artist.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;

        public ProductController()
        {
            _repository = new ProductRepository();
        }

        public ActionResult Index()
        {
            IEnumerable<Product> products = _repository.List();
            var productViewModels = new List<ProductViewModel>();
            foreach (Product product in products)
            {
                var productViewModel = new ProductViewModel
                                           {
                                               Id = product.Id,
                                               Image = product.Image,
                                               MimeType = product.MimeType,
                                               Name = product.Name,
                                               Description = product.Description,
                                               Length = product.Length,
                                               Width = product.Width,
                                               Material = product.Material,
                                               ModifiedDate = product.ModifiedDate
                                           };
                productViewModels.Add(productViewModel);
            }
            return products.Count() > 0 ? View(productViewModels) : View("No data found");
        }

        public ActionResult Details(int id)
        {
            //           Bitmap b = (Bitmap)Bitmap.FromStream( new MemoryStream(byte[]));
            //Bitmap output = new Bitmap(b, new Size(320, 240);
            Product product = _repository.Get(id);
            var productViewModel = new ProductViewModel
                                       {
                                           Id = product.Id,
                                           Image = ByteArrayToImageResized(product.Image, 5),
                                           MimeType = product.MimeType,
                                           Name = product.Name,
                                           Description = product.Description,
                                           Length = product.Length,
                                           Width = product.Width,
                                           Material = product.Material,
                                           ModifiedDate = product.ModifiedDate
                                       };

            //var productViewModel = new ProductViewModel
            //{
            //    Id = product.Id,
            //    Image = BytesFromBitmap(BitmapFromBytes(product.Image)),
            //    MimeType = product.MimeType,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Length = product.Length,
            //    Width = product.Width,
            //    Material = product.Material,
            //    ModifiedDate = product.ModifiedDate
            //};

            //var productViewModel2 = new ProductViewModel
            //{
            //    Id = product.Id,
            //    Image = product.Image,
            //    MimeType = product.MimeType,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Length = product.Length,
            //    Width = product.Width,
            //    Material = product.Material,
            //    ModifiedDate = product.ModifiedDate
            //};

            return productViewModel.Id > 0 ? View(productViewModel) : View("No data found");
        }

        public Image Resize(Image img, int percentage)
        {
            //get the height and width of the image
            int originalW = img.Width;
            int originalH = img.Height;

            //get the new size based on the percentage change
            int resizedW = (int)(originalW * percentage/100);
            int resizedH = (int)(originalH * percentage/100);

            //create a new Bitmap the size of the new image
            Bitmap bmp = new Bitmap(resizedW, resizedH);
            //create a new graphic from the Bitmap
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //draw the newly resized image
            graphic.DrawImage(img, 0, 0, resizedW, resizedH);
            //dispose and free up the resources
            graphic.Dispose();
            //return the image
            return (Image)bmp;
        }
        public byte[] imageToByteArray2(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public byte[] ByteArrayToImageResized(byte[] byteArrayIn, int percentage)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            //resize the image here
            Image newResizedImage = Resize(returnImage, 5);
            MemoryStream ms2 = new MemoryStream();
            newResizedImage.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms2.ToArray();

        }

        public Image byteArrayToImage2(byte[] byteArrayIn, int percentage)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            //resize the image here
            Image newResizedImage = Resize(returnImage, 10);

            return newResizedImage;
        }

        private Bitmap BitmapFromBytes(byte[] image)
        {
            Bitmap b = (Bitmap) Bitmap.FromStream(new MemoryStream(image));
            Bitmap output = new Bitmap(b, new Size(1, 1));
            return output;
        }

        private byte[] BytesFromBitmap(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();
            return bitmapData;
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(HttpPostedFileBase uploadFile, decimal length, decimal width, string description,
                                   string material)
        {
            string _mimeType = String.Empty;
            string _fileName = String.Empty;
            byte[] _fileData = null;

            if (uploadFile.ContentLength > 0)
            {
                _mimeType = uploadFile.ContentType;
                Stream fileStream = uploadFile.InputStream;
                _fileName = Path.GetFileName(uploadFile.FileName);
                int fileLength = uploadFile.ContentLength;
                _fileData = new byte[fileLength];
                fileStream.Read(_fileData, 0, fileLength);

                _repository.UploadOrUpdateProduct(_fileName, _mimeType, _fileData, description, length, width, material);
            }
            // var productViewModels = new List<ProductViewModel>();

            //get value for key from database after insert or update
            var productViewModel = new ProductViewModel
                                       {
                                           Image = _fileData,
                                           MimeType = _mimeType,
                                           Name = _fileName,
                                           Description = description,
                                           Length = length,
                                           Width = width,
                                           Material = material,
                                           ModifiedDate = DateTime.Now
                                       };
            //productViewModels.Add(productViewModel);
            return RedirectToAction("Index", productViewModel);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int Id, Product product)
        {
            try
            {
                Product productToDelete = _repository.Get(Id);
                _repository.Delete(Id, productToDelete);

                var productViewModel = new ProductViewModel
                                           {
                                               Id = productToDelete.Id,
                                               Image = productToDelete.Image,
                                               MimeType = productToDelete.MimeType,
                                               Name = productToDelete.Name,
                                               Description = productToDelete.Description,
                                               Length = productToDelete.Length,
                                               Width = productToDelete.Width,
                                               Material = productToDelete.Material,
                                               ModifiedDate = productToDelete.ModifiedDate
                                           };
                return RedirectToAction("Index", productViewModel);
            }
            catch
            {
                return View();
            }
        }

        #region Miscellaneous

        public ActionResult GetImage(int Id)
        {
            Product product = _repository.Get(Id);
            return File(product.Image, product.MimeType, product.Name);
        }

        public FileContentResult DownloadImageStream(int Id)
        {
            Product product = _repository.Get(Id);
            return File(product.Image, product.MimeType);
        }


        #endregion
    }
}