using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ImageService
{
    public class AlreadyLikedException : Exception
    {
        private readonly long userIdentifier;

        private readonly long imageIdentifier;

        #region Properties Region

        public long UserIdentifier
        {
            get { return userIdentifier; }
        }

        public long ImageIdentifier
        {
            get { return imageIdentifier; }
        }


        #endregion Properties Region


        public AlreadyLikedException(long userIdentifier, long imageIdentifier)
            : base("Already liked exception => " +
            "userIdentifier = " + userIdentifier + " | " +
            "imageIdentifier = " + imageIdentifier)
        {
            this.userIdentifier = userIdentifier;
            this.imageIdentifier = imageIdentifier;

        }

        #region Test code. Uncomment for testing.

        //public static void Main()
        //{
        //    try
        //    {
        //        throw new AlreadyLikedException(1, 1000, 1500);
        //    }
        //    catch (Exception e)
        //    {
        //        LogManager.RecordMessage("Message: " + e.Message,
        //            MessageType.Info);

        //        LogManager.RecordMessage("StacTrace: " + e.StackTrace,
        //            MessageType.Info);

        //        Console.ReadLine();
        //    }
        //}

        #endregion Test code. Uncomment for testing.
    }
}