using Es.Udc.DotNet.PracticaMaD.Model.ImageDao;
using Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao;

using Es.Udc.DotNet.PracticaMaD.Model.ImageService;
using Es.Udc.DotNet.PracticaMaD.Model.UserService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Transactions;

/// TODO: Comentar con el profesor para eliminar esto
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.TagDao;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMaD.Model.UserProfileDao;
using Es.Udc.DotNet.PracticaMaD.Model.CategoryDao;

namespace Es.Udc.DotNet.PracticaMaD.UnitTest
{
    /// <summary>
    /// Descripción resumida de IImageServiceTest
    /// </summary>
    [TestClass]
    public class IImageServiceTest
    {

        private const string loginName = "loginNameTest";
        private const string clearPassword = "password";
        private const string firstName = "name";
        private const string lastName = "lastName";
        private const string email = "user@udc.es";

        private const string loginName2 = "loginNameTest2";
        private const string clearPassword2 = "password2";
        private const string firstName2 = "name2";
        private const string lastName2 = "lastName2";
        private const string email2 = "user2@udc.es";

        private const string language = "es";
        private const string country = "ES";

        private const long NON_EXISTENT_USER_ID = -1;
        private static IKernel kernel;
        private static IUserProfileDao userProfileDao;

        private static IImageService imageService;
        private static IImageDao imageDao;
        private static ITagDao tagDao;
        private static IComentarioDao comentarioDao;


        private static ICategoryDao categoryDao;


        private static IUserService userService;
        public IImageServiceTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TransactionScope transactionScope;

        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();
            imageService = kernel.Get<IImageService>();
            userService = kernel.Get<IUserService>();
            imageDao = kernel.Get<IImageDao>();
            comentarioDao = kernel.Get<IComentarioDao>();
            categoryDao = kernel.Get<ICategoryDao>();
            tagDao = kernel.Get<ITagDao>();
            userProfileDao = kernel.Get<IUserProfileDao>();
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            transactionScope = new TransactionScope();
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get; set;
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateImage()
        {

            using (var scope = new TransactionScope())
            {
                ImageSet imagen = new ImageSet();

                Category category = new Category();
                category.Nombre = "categoria";

                var userId = userService.RegisterUser(loginName, clearPassword,
                    new UserProfileDetails(firstName, lastName, email, language, country));

                categoryDao.Create(category);

                Category categoryAux = categoryDao.FindByName(category.Nombre);

                EXIF exif = new EXIF();
                exif.Apertura = "a";
                exif.WB = "b";
                exif.ISO = "c";
                exif.TExposicion = "d";

                // ---- Atributos imagen ------
                imagen.Titulo = "titulo";
                imagen.Descripcion = "descripción";
                imagen.FechaDeSubida = DateTime.Now;
                imagen.EXIF = exif;
                imagen.usrId = userId;
                imagen.CategoríaId = categoryAux.Id;
                imagen.author = loginName;


                // --- DATA -----------------------
                //byte[] data = { 0x44 };
                imagen.Data = System.Text.Encoding.UTF8.GetBytes("Hola qué tal");



                ImageSet img = imageService.CreateImage(imagen, exif);

                ImageSet expected = imageService.FindImage(imagen.Id);

                Assert.AreEqual(expected.Id, imagen.Id);
                Assert.AreEqual(expected.EXIFId, imagen.EXIFId);
            }
        }

        [TestMethod()]
        public void FindImageTest()
        {

            using (var scope = new TransactionScope())
            {
                ImageSet expected = new ImageSet();

                Category category = new Category();
                category.Nombre = "categoria";

                var userId = userService.RegisterUser(loginName, clearPassword,
                    new UserProfileDetails(firstName, lastName, email, language, country));

                categoryDao.Create(category);

                Category categoryAux = categoryDao.FindByName(category.Nombre);

                EXIF exif = new EXIF();
                exif.Apertura = "a";
                exif.WB = "b";
                exif.ISO = "c";
                exif.TExposicion = "d";

                // ---- Atributos imagen ------
                expected.Titulo = "titulo";
                expected.Descripcion = "descripción";
                expected.FechaDeSubida = DateTime.Now;
                expected.EXIF = exif;
                expected.usrId = userId;
                expected.CategoríaId = categoryAux.Id;
                expected.author = loginName;


                // --- DATA -----------------------
                //byte[] data = { 0x44 };
                expected.Data = System.Text.Encoding.UTF8.GetBytes("Hola qué tal");



                ImageSet img = imageService.CreateImage(expected, exif);

                ImageSet actual = imageService.FindImage(expected.Id);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.EXIFId, actual.EXIFId);
            }
        }





        [TestMethod]
        public void LikeImage()
        {

            using (var scope = new TransactionScope())
            {
                ImageSet imagen = new ImageSet();

                Category category = new Category();
                category.Nombre = "categoria";

                var userId = userService.RegisterUser(loginName, clearPassword,
                    new UserProfileDetails(firstName, lastName, email, language, country));


                categoryDao.Create(category);

                Category categoryAux = categoryDao.FindByName(category.Nombre);

                EXIF exif = new EXIF();
                exif.Apertura = "a";
                exif.WB = "b";
                exif.ISO = "c";
                exif.TExposicion = "d";

                // ---- Atributos imagen ------
                imagen.Titulo = "titulo";
                imagen.Descripcion = "descripción";
                imagen.FechaDeSubida = DateTime.Now;
                imagen.EXIF = exif;
                imagen.usrId = userId;
                imagen.CategoríaId = categoryAux.Id;
                imagen.numLikes = 0;
                imagen.author = loginName;


                // --- DATA -----------------------
                //byte[] data = { 0x44 };
                imagen.Data = System.Text.Encoding.UTF8.GetBytes("Hola qué tal");



                ImageSet img = imageService.CreateImage(imagen, exif);

                imageService.LikeImage(userId, img.Id);

                UserProfile user = userProfileDao.Find(userId);
                Assert.AreEqual(1, imagen.numLikes);
                Assert.IsTrue(imagen.UserProfile1.Contains(user));

            }
        }





        [TestMethod]
        public void CommentImage()
        {

            using (var scope = new TransactionScope())
            {
                ImageSet imagen = new ImageSet();

                Category category = new Category();
                category.Nombre = "categoria";

                var userId = userService.RegisterUser(loginName, clearPassword,
                    new UserProfileDetails(firstName, lastName, email, language, country));


                var userId2 = userService.RegisterUser(loginName2, clearPassword2,
                    new UserProfileDetails(firstName2, lastName2, email2, language, country));


                categoryDao.Create(category);

                Category categoryAux = categoryDao.FindByName(category.Nombre);

                EXIF exif = new EXIF();
                exif.Apertura = "a";
                exif.WB = "b";
                exif.ISO = "c";
                exif.TExposicion = "d";

                // ---- Atributos imagen ------
                imagen.Titulo = "titulo";
                imagen.Descripcion = "descripción";
                imagen.FechaDeSubida = DateTime.Now;
                imagen.EXIF = exif;
                imagen.usrId = userId;
                imagen.CategoríaId = categoryAux.Id;
                imagen.author = loginName;


                // --- DATA -----------------------
                //byte[] data = { 0x44 };
                imagen.Data = System.Text.Encoding.UTF8.GetBytes("Hola qué tal");



                ImageSet img = imageService.CreateImage(imagen, exif);

                DateTime date = DateTime.Now;

                long commentId = imageService.CommentImage(userId2, img.Id, "texto");

                Comment comment = comentarioDao.Find(commentId);

                Assert.AreEqual(comment.comentarioId, commentId);
                Assert.AreEqual(comment.UserProfile_usrId, userId2);
                Assert.AreEqual(comment.ImagenSetId, img.Id);
                Assert.AreEqual(comment.Texto, "texto");
                Assert.AreEqual(comment.Date, date);


            }
        }

        [TestMethod()]
        public void CreateAndFindTag()
        {
            using (var scope = new TransactionScope())
            {
                imageService.CreateTag("tag1");
                Tag tag = tagDao.findByTitle("tag1");
                Assert.AreEqual(tag.title, "tag1");
            }
        }

        [TestMethod()]
        public void AddImageTag()
        {
            using (var scope = new TransactionScope())
            {
                ImageSet imagen = new ImageSet();

                List<String> tagNames = new List<string>();
                Category category = new Category();
                category.Nombre = "categoria";

                var userId = userService.RegisterUser(loginName, clearPassword,
                    new UserProfileDetails(firstName, lastName, email, language, country));


                categoryDao.Create(category);

                Category categoryAux = categoryDao.FindByName(category.Nombre);

                EXIF exif = new EXIF();
                exif.Apertura = "a";
                exif.WB = "b";
                exif.ISO = "c";
                exif.TExposicion = "d";

                // ---- Atributos imagen ------
                imagen.Titulo = "titulo";
                imagen.Descripcion = "descripción";
                imagen.FechaDeSubida = DateTime.Now;
                imagen.EXIF = exif;
                imagen.usrId = userId;
                imagen.CategoríaId = categoryAux.Id;
                imagen.author = loginName;


                // --- DATA -----------------------
                //byte[] data = { 0x44 };
                imagen.Data = System.Text.Encoding.UTF8.GetBytes("Hola qué tal");

                ImageSet img = imageService.CreateImage(imagen, exif);

                imageService.CreateTag("tag1");
                Tag tag = tagDao.findByTitle("tag1");
                List<Tag> tagListAux = new List<Tag>();
                tagListAux.Add(tag);

                foreach (Tag tagAux in tagListAux)
                {
                    tagNames.Add(tagAux.title);
                }

                imageService.AddTags(tagNames, img.Id);
                Assert.AreEqual(tagListAux, imagen.Tag);
                Assert.AreEqual(tagListAux.Count, imagen.Tag.Count);
            }
        }

        [TestMethod()]
        public void RemoveImageTag()
        {
            using (var scope = new TransactionScope())
            {
                ImageSet imagen = new ImageSet();

                List<String> tagNames = new List<string>();


                Category category = new Category();
                category.Nombre = "categoria";

                var userId = userService.RegisterUser(loginName, clearPassword,
                    new UserProfileDetails(firstName, lastName, email, language, country));

                categoryDao.Create(category);

                Category categoryAux = categoryDao.FindByName(category.Nombre);


                EXIF exif = new EXIF();
                exif.Apertura = "a";
                exif.WB = "b";
                exif.ISO = "c";
                exif.TExposicion = "d";

                // ---- Atributos imagen ------
                imagen.Titulo = "titulo";
                imagen.Descripcion = "descripción";
                imagen.FechaDeSubida = DateTime.Now;
                imagen.EXIF = exif;
                imagen.usrId = userId;
                imagen.CategoríaId = categoryAux.Id;
                imagen.Data = System.Text.Encoding.UTF8.GetBytes("Hola qué tal");
                imagen.author = loginName;


                ImageSet img = imageService.CreateImage(imagen, exif);

                imageService.CreateTag("tag1");
                Tag tag = tagDao.findByTitle("tag1");
                List<Tag> tagList = new List<Tag>();
                tagList.Add(tag);


                foreach (Tag tagAux in tagList)
                {
                    tagNames.Add(tagAux.title);
                }

                imageService.AddTags(tagNames, img.Id);

                ImageSet imagen1 = imageService.FindImage(img.Id);
                Console.WriteLine(imagen1.Tag.Count);

                imageService.RemoveTags(tagNames, img.Id);
                List<Tag> tagListAux2 = new List<Tag>();
                ImageSet imagen2 = imageService.FindImage(img.Id);

                Assert.AreEqual(imagen2.Tag.Count, tagListAux2.Count);
            }
        }

        [TestMethod()]
        public void MostUsedTags()
        {
            using (var scope = new TransactionScope())
            {
                List<String> tagNames1 = new List<string>();

                List<String> tagNames2 = new List<string>();

                List<String> tagNames3 = new List<string>();

                Category category = new Category();

                category.Nombre = "categoria";

                var userId = userService.RegisterUser(loginName, clearPassword,
                    new UserProfileDetails(firstName, lastName, email, language, country));


                categoryDao.Create(category);

                Category categoryAux = categoryDao.FindByName(category.Nombre);

                EXIF exif = new EXIF();
                exif.Apertura = "a";
                exif.WB = "b";
                exif.ISO = "c";
                exif.TExposicion = "d";

                ImageSet imagen1 = new ImageSet();
                imagen1.Titulo = "titulo";
                imagen1.Descripcion = "descripción";
                imagen1.FechaDeSubida = DateTime.Now;
                imagen1.EXIF = exif;
                imagen1.usrId = userId;
                imagen1.CategoríaId = categoryAux.Id;
                imagen1.Data = System.Text.Encoding.UTF8.GetBytes("Hola qué tal");
                imagen1.author = loginName;


                ImageSet imagen2 = new ImageSet();
                imagen2.Titulo = "titulo";
                imagen2.Descripcion = "descripción";
                imagen2.FechaDeSubida = DateTime.Now;
                imagen2.EXIF = exif;
                imagen2.usrId = userId;
                imagen2.CategoríaId = categoryAux.Id;
                imagen2.Data = System.Text.Encoding.UTF8.GetBytes("Hola qué tal");
                imagen2.author = loginName;


                ImageSet imagen3 = new ImageSet();
                imagen3.Titulo = "titulo";
                imagen3.Descripcion = "descripción";
                imagen3.FechaDeSubida = DateTime.Now;
                imagen3.EXIF = exif;
                imagen3.usrId = userId;
                imagen3.CategoríaId = categoryAux.Id;
                imagen3.Data = System.Text.Encoding.UTF8.GetBytes("Hola qué tal");
                imagen3.author = loginName;

                ImageSet img1 = imageService.CreateImage(imagen1, exif);
                ImageSet img2 = imageService.CreateImage(imagen2, exif);
                ImageSet img3 = imageService.CreateImage(imagen3, exif);


                imageService.CreateTag("tag1");
                imageService.CreateTag("tag2");
                imageService.CreateTag("tag3");
                imageService.CreateTag("tag4");
                imageService.CreateTag("tag5");
                imageService.CreateTag("tag6");
                imageService.CreateTag("tag7");
                imageService.CreateTag("tag8");
                imageService.CreateTag("tag9");
                imageService.CreateTag("tag10");

                Tag tag1 = tagDao.findByTitle("tag1");
                Tag tag2 = tagDao.findByTitle("tag2");
                Tag tag3 = tagDao.findByTitle("tag3");
                Tag tag4 = tagDao.findByTitle("tag4");
                Tag tag5 = tagDao.findByTitle("tag5");
                Tag tag6 = tagDao.findByTitle("tag6");
                Tag tag7 = tagDao.findByTitle("tag7");
                Tag tag8 = tagDao.findByTitle("tag8");
                Tag tag9 = tagDao.findByTitle("tag9");
                Tag tag10 = tagDao.findByTitle("tag10");

                List<Tag> tagList1 = new List<Tag>();
                List<Tag> tagList2 = new List<Tag>();
                List<Tag> tagList3 = new List<Tag>();
                List<Tag> tagListResult = new List<Tag>();

                tagList1.Add(tag1);
                tagList1.Add(tag2);
                tagList1.Add(tag3);
                tagList1.Add(tag4);
                tagList1.Add(tag5);
                tagList1.Add(tag6);
                tagList1.Add(tag7);
                tagList1.Add(tag8);
                tagList1.Add(tag9);
                tagList1.Add(tag10);


                foreach (Tag tagAux1 in tagList1)
                {

                    tagNames1.Add(tagAux1.title);
                }


                tagList2.Add(tag2);
                tagList2.Add(tag4);
                tagList2.Add(tag6);
                tagList2.Add(tag8);
                tagList2.Add(tag10);




                foreach (Tag tagAux2 in tagList2)
                {

                    tagNames1.Add(tagAux2.title);

                }


                tagList3.Add(tag2);
                tagList3.Add(tag4);
                tagList3.Add(tag8);
                tagList3.Add(tag10);




                foreach (Tag tagAux3 in tagList3)
                {
                    tagNames1.Add(tagAux3.title);

                }



                imageService.AddTags(tagNames1, img1.Id);
                imageService.AddTags(tagNames2, img2.Id);
                imageService.AddTags(tagNames3, img3.Id);


                tagListResult.Add(tag2);
                tagListResult.Add(tag4);
                tagListResult.Add(tag8);
                tagListResult.Add(tag10);
                tagListResult.Add(tag6);

                foreach (Tag tag in tagListResult)
                {
                    Console.WriteLine(tag.title);
                }

                foreach (Tag tag in tagDao.mostUsedTags())
                {
                    Console.WriteLine(tag.title);
                }

                Assert.AreEqual(tagListResult.ToArray().ToString(), tagDao.mostUsedTags().ToArray().ToString());
            }
        }
    }
}